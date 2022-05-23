// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


await new HostBuilder()
    .ConfigureLogging((context, builder) =>
    {
        builder.AddConsole(opt =>
        {
            opt.TimestampFormat = "[HH:mm:ss]";
        });
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<TestCommand>();
    })
    .RunCommandLineApplicationAsync<App>(args);


[Subcommand(typeof(TestCommand))]
public class App : CommandLineApplication
{
}

[Command(Name = "test")]
public class TestCommand
{
    public void OnExecute()
    {
        Console.WriteLine("hello world.");
    }
}