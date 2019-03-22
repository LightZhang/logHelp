using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLog
{
    class Program
    {
        static void Main(string[] args)
        {
            //在bin 目录下log文件夹
            LogHelp.Log.Write("test");

            LogHelp.Log.WriteError("test");

            LogHelp.Log.WriteToFile("222","sdsdsdsd");
        }
    }
}
