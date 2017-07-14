using System;
namespace KeyValueStoreConsoleApplication.Commands
{
    public static class DefaultCommands
    {
        public DefaultCommands()
        {
            public static string Get(string key)
            {
                return string.Format("Return value of key {0}", key);
            }

            public static string Set(string key, string val)
			{
                return string.Format("Set entry of key {0} with value {1}", key, val);
			}
        }
    }
}
