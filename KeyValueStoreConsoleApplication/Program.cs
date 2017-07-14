using System;

namespace KeyValueStoreConsoleApplication
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Title = typeof(MainClass).Name;
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
                    string result = Execute(consoleInput);
                    WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    WriteToConsole(ex.Message);
                }
            }
        }

        static string Execute(string command)
        {
            return string.Format("Executed the {0} Command", command);
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
