// See https://aka.ms/new-console-template for more information
using AutoFunctionCalling;

Console.WriteLine("Is it time to do laundry? Let's ask the AI!");
Console.WriteLine();

bool useAzureOpenAI = true;
Settings.LoadAzureEndpoint(useAzureOpenAI);
Settings.LoadModel(useAzureOpenAI);
Settings.LoadApiKey(useAzureOpenAI);
Console.WriteLine();

var funCalling = new OpenAI_FunctionCalling();
await funCalling.RunAsync();