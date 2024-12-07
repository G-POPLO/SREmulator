using System.Diagnostics;
using System.Text;

namespace SREmulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                if (args.Length is 0)
                {
                    Console.WriteLine(CLI.Help);
                    Console.ReadKey(true);
                    return;
                }

                Stopwatch sw = Stopwatch.StartNew();
                CLI.Execute(CLIArgs.Parse(args));
                Console.WriteLine(sw.Elapsed.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey(true);
        }
    }
}
