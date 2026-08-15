using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;


var chatClient = new OllamaChatClient( new Uri("http://localhost:11434"),"qwen3:4b");

var taskTools = new TaskTools();
var agent = chatClient.AsAIAgent(
    new ChatClientAgentOptions
    {
        Name = "TaskAssistant",
        ChatOptions = new ChatOptions
        {
            Instructions = """
        You are TaskAssistant, an AI task management assistant.

        You can:
        - Add tasks
        - List tasks
        - Complete tasks

        ALWAYS use the appropriate tool when the user asks
        to modify or retrieve their tasks.
        """,

            Tools =
            [
                AIFunctionFactory.Create(taskTools.AddTask),
                AIFunctionFactory.Create(taskTools.ListTasks),
                AIFunctionFactory.Create(taskTools.CompleteTask)
            ]
        }
    }
);

var session = await agent.CreateSessionAsync();

Console.WriteLine("TaskAssistant");
Console.WriteLine("Type 'exit' to quit.");
Console.WriteLine();

while (true)
{
    Console.Write("You: ");

    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    var response = await agent.RunAsync(
        input,
        session);

    Console.WriteLine();
    Console.WriteLine(response.Text);
    Console.WriteLine();
}