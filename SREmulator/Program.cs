using System.Text;

namespace SREmulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (args.Length is 0)
            {
                Console.WriteLine(CLI.Help);
                Console.ReadKey(true);
                return;
            }

            CLI.Execute(CLIArgs.Parse(args));
            Console.ReadKey(true);
        }
    }
}
