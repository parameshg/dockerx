using System;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.CommandLineUtils;

namespace Dockerx.Commands.Image
{
    public class CleanImagesCommand
    {
        public void Execute(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "removes unnamed and untagged images";

            var force = cmd.Option("--force | -f", "force remove image", CommandOptionType.NoValue);

            cmd.OnExecute(async () =>
            {
                try
                {
                    var docker = new DockerClientConfiguration(new Uri(Environment.GetEnvironmentVariable("DOCKER_ENDPOINT"))).CreateClient();

                    var images = await docker.Images.ListImagesAsync(new ImagesListParameters());

                    foreach (var image in images)
                    {
                        if (image.RepoTags == null || image.RepoTags.Contains("<none>:<none>"))
                        {
                            await docker.Images.DeleteImageAsync(image.ID, new ImageDeleteParameters() { Force = force.HasValue() });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                return 0;
            });
        }
    }
}