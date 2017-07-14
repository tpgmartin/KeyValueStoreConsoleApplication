using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace KeyValueStoreConsoleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;
            Run();
        }

        static void Run()
        {
            while (true)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace((consoleInput))) continue;

                try
                {
                    var cmd = new ConsoleCommand(consoleInput);
                    string result = Execute(cmd);
                    WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    WriteToConsole(ex.Message);
                }
            }
        }

        static string Execute(ConsoleCommand command)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Executed the {0}.{1} Command", command.LibraryClassName, command.Name));
            for (int i = 0; i < command.Arguments.Count(); i++)
            {
                sb.AppendLine(ConsoleFormatting.Indent(4) + string.Format("Argument{0} value: {1}", i, command.Arguments.ElementAt(i)));
            }
            return sb.ToString();
        }

        public static void WriteToConsole(string message = "")
        {
            if(message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        const string _prompt = "keyvaluestore>";
        public static string ReadFromConsole(string promptMessage = "")
        {
            Console.Write(_prompt + promptMessage);
            return Console.ReadLine();
        }
    }
}
