using Microsoft.Extensions.CommandLineUtils;

namespace Dockerx.Commands.Image
{
    public class ImageCommands
    {
        public void Register(CommandLineApplication cmd)
        {
            cmd.HelpOption("-? | -h | --help");
            cmd.Description = "extension commands for image management";

            cmd.Command("clean", new CleanImagesCommand().Execute);

            cmd.OnExecute(() =>
            {
                cmd.ShowHelp("image");
                return 0;
            });
        }
    }
}