// See https://aka.ms/new-console-template for more information
using AutoFunctionCalling;

Console.WriteLine("Is it time to do laundry? Let's ask the AI!");
Console.WriteLine();

bool useAzureOpenAI = true;
await Settings.AskAzureEndpoint(useAzureOpenAI);
await Settings.AskModel(useAzureOpenAI);
await Settings.AskApiKey(useAzureOpenAI);
Console.WriteLine();

var funCalling = new OpenAI_FunctionCalling();
await funCalling.RunAsync();