# Semantic Kernel Laundry Example

Semantic Kernel automated function calling example to determine the right time to hang your laundry.
The goal of this example is to use the AI model to decide whether it's a good time to hang laundry outside based on the current time and weather.

![Screenshot 1](/SK-laundry-example-screenshot1.png)

## Explaination

The method starts by creating a Kernel object using the `Kernel.CreateBuilder` method. The Kernel is a core component of the Semantic Kernel framework that manages the execution of tasks.

Next, it loads settings from a file using the `Settings.LoadFromFile` method. These settings include whether to use Azure OpenAI, the model to use, the Azure endpoint, the API key, and the organization ID.

The method then imports a plugin named `LaundryPlugin`. This plugin contains several helper functions that the model can use. These functions include `HangLaundry`, `GetUtcTime`, `WaitSomeTime`, and `GetCurrentWeather`.

A `ChatHistory` object is created to keep track of the conversation. The initial message sets the role of the assistant as a friendly helper that follows rules and completes tasks autonomously.

The method then enters a loop where it adds a user message to the chat history giving the instructions to the model. The loop continues until the laundry is hung.

Inside the loop, the method gets the chat completions from the model using the `GetStreamingChatMessageContentsAsync` method on the chat completion service. The results are streamed and printed to the console. The assistant's messages are added to the chat history.

There's also commented-out code that allows the user to provide input if the assistant asks a question. This code can be uncommented to enable user interaction.

## Project Structure

The main entry point of the application is [`Program.cs`](Program.cs), which sets up the necessary settings and initiates the function calling process.

The [`OpenAI_FunctionCalling.cs`](OpenAI_FunctionCalling.cs) file contains the Semantic Kernel initialisation logic (that loads the settings and the laundry plugin) and the main loop that uses the AI model as an orchestrator to execute the necessary functions to complete its goal.

The [`Settings.cs`](Settings.cs) file contains the `Settings` class which is responsible for managing the settings of the application, loading the `settings.json`file containing the Azure endpoint, model, and API key.

The [`LaundryPlugin.cs`](LaundryPlugin.cs) file contains the implementation of the laundry plugin.

The project is built using .NET 8.0, as specified in the [`SK-laundry-example.csproj`](SK-laundry-example.csproj) file.

## Getting Started

To get started with this project:

0. Install Semantic Kernel if necessary. `dotnet add package Microsoft.SemanticKernel --version 1.11.1`

1. Clone the repository.
2. Open the solution file [`SK-laundry-example.sln`](SK-laundry-example.sln) in Visual Studio Code or the IDE of your choice.
3. Copy the `settings.json.azure-example`file, rename it `settings.json` and fill it out with the relevant information. Do the same with the `settings.json.openai-example` if using an OpenAI endpoint. If using an OpenAI endpoint, change the value to `bool useAzureOpenAI = false`in the `Program.cs` file;
4. Build the solution. `dotnet build`
5. Run the application. `dotnet run`

## Models tested

Tested with `gpt-4 turbo-2024-04-09` model hosted on Azure :heart:

## Contributing

Contributions are welcome. Please open an issue to discuss your ideas before making changes.