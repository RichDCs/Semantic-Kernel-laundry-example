# SK-laundry-example
Semantic Kernel automated function calling example to determine the right time to hang your laundry.

![Screenshot 1](/SK-laundry-example-screenshot1.png)

## Project Structure

The main entry point of the application is [`Program.cs`](Program.cs), which sets up the necessary settings and initiates the function calling process.

The [`Settings.cs`](Settings.cs) file contains the `Settings` class which is responsible for managing the settings of the application, loading the `settings.json`file containing the Azure endpoint, model, and API key.

The [`LaundryPlugin.cs`](LaundryPlugin.cs) file contains the implementation of the laundry plugin.

The project is built using .NET 8.0, as specified in the [`SK-laundry-example.csproj`](SK-laundry-example.csproj) file.

## Getting Started

To get started with this project:

0. Install Semantic Kernel if necessary. `dotnet add package Microsoft.SemanticKernel --version 1.11.1`

1. Clone the repository.
2. Open the solution file [`SK-laundry-example.sln`](SK-laundry-example.sln) in Visual Studio Code or any IDE of your choice.
3. Copy the `settings.json.azure-example`file, rename it `settings.json` and fill it out with the relevant information. Do the same with the `settings.json.openai-example` if using an OpenAI endpoint. If using an OpenAI endpoint, change the value to `bool useAzureOpenAI = false`in the `Program.cs` file;
3. Build the solution. `dotnet build`
4. Run the application. `dotnet run`

## Contributing

Contributions are welcome. Please open an issue to discuss your ideas before making changes.