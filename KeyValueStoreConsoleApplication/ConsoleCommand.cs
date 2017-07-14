﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyValueStoreConsoleApplication
{
    public class ConsoleCommand
    {
        public ConsoleCommand(string input)
        {
			var stringArray = Regex.Split(input, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
			_arguments = new List<string>();
			for (int i = 0; i < stringArray.Length; i++)
			{
				if (i == 0)
				{
					this.Name = stringArray[i];

					this.LibraryClassName = "DefaultCommands";
					string[] s = stringArray[0].Split('.');
					if (s.Length == 2)
					{
						this.LibraryClassName = s[0];
						this.Name = s[1];
					}
				}
				else
				{
					var inputArgument = stringArray[i];
					string argument = inputArgument;

					var regex = new Regex("\"(.*?)\"", RegexOptions.Singleline);
					var match = regex.Match(inputArgument);

					if (match.Captures.Count > 0)
					{
						var captureQuotedText = new Regex("[^\"]*[^\"]");
						var quoted = captureQuotedText.Match(match.Captures[0].Value);
						argument = quoted.Captures[0].Value;
					}
					_arguments.Add(argument);
				}
			}
		}

        public string Name { get; set; }
        public string LibraryClassName { get; set; }

        private List<string> _arguments;
        public IEnumerable<string> Arguments
        {
            get
            {
                return _arguments;
            }
        }
    }
}
