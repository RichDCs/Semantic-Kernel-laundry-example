// Copyright (c) Microsoft. All rights reserved.

#pragma warning disable SKEXP0001

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace AutoFunctionCalling;

// This example shows how to use OpenAI's tool calling capability via the chat completions interface.
public class OpenAI_FunctionCalling
{
    public async Task RunAsync()
    {
        // Create kernel.
        IKernelBuilder builder = Kernel.CreateBuilder();

        var (useAzureOpenAI, model, azureEndpoint, apiKey, orgId) = Settings.LoadFromFile();
        builder.AddAzureOpenAIChatCompletion(model, azureEndpoint, apiKey);

        Kernel kernel = builder.Build();

        // Add a plugin with some helper functions we want to allow the model to utilize.
        kernel.ImportPluginFromFunctions("LaundryPlugin",
        [
            kernel.CreateFunctionFromMethod(LaundryPlugin.HangLaundry, "HangLaundry", "Hangs the laundry outside."),
            kernel.CreateFunctionFromMethod(LaundryPlugin.GetUtcTime, "GetUtcTime", "Retrieves the current time in UTC."),
            kernel.CreateFunctionFromMethod(LaundryPlugin.WaitSomeTime, "WaitSomeTime", "Waits some time in order to wait for the time and weather to change."),
            kernel.CreateFunctionFromMethod(LaundryPlugin.GetCurrentWeather, "GetCurrentWeather", "Retrieves the current weather."),
        ]);

        // Chat history to keep track of the conversation.
        ChatHistory chatMessages = new ChatHistory("""You are a friendly assistant who likes to follow the rules. You will complete required steps. You are autonomous and can complete tasks without user input.""");
        
        // use this prompt for asking for user input
        // ChatHistory chatMessages = new ChatHistory("""You are a friendly assistant who likes to follow the rules. You will complete required steps and request approval before taking any consequential actions. If the user doesn't provide enough information for you to complete a task, you will keep asking questions until you have enough information to complete the task.""");

        // Retrieve the chat completion service from the kernel
        IChatCompletionService chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        Console.WriteLine("======== Use automated function calling ========");
        {
            chatMessages.AddUserMessage("Given the current time of day and weather, is it a good time to hang the laundry outside? Laundry can only be hung if weather and time conditions are suitable. I am in Switzerland. If not, wait some time and check again.");
            while(!LaundryPlugin.laundryHung)
            {
                // Get the chat completions
                OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
                {
                    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                    FrequencyPenalty = 1.0,
                };
                var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
                    chatMessages,
                    executionSettings: openAIPromptExecutionSettings,
                    kernel: kernel);

                // Stream the results
                string fullMessage = "";
                await foreach (var content in result)
                {
                    if (content.Role.HasValue)
                    {
                        System.Console.Write("Assistant > ");
                    }
                    System.Console.Write(content.Content);
                    fullMessage += content.Content;
                }
                System.Console.WriteLine();

                // Add the message from the agent to the chat history
                chatMessages.AddAssistantMessage(fullMessage);

                // uncomment the following code to allow the user to provide input
                // if (fullMessage.Contains('?'))
                // {
                //     // If the agent asks a question, we need to provide an answer.
                //     System.Console.Write("User > ");
                //     chatMessages.AddUserMessage(Console.ReadLine()!);
                // }
            }
        }
    }
}

#pragma warning restore SKEXP0001