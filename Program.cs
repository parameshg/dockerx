using System;
using Dockerx.Commands.Image;
using Microsoft.Extensions.CommandLineUtils;

namespace Dockerx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: true);

            try
            {
                app.Name = "dockerx";
                app.Description = "Docker Extension Commands";
                app.HelpOption("-? | -h | --help");

                app.Command("image", new ImageCommands().Register);

                app.OnExecute(() =>
                {
                    app.ShowHelp("dockerx");

                    return 0;
                });

                app.Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                while (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                    e = e.InnerException;
                }

                app.ShowHelp();
            }
        }
    }
}