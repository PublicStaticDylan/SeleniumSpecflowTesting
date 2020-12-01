using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SeleniumSpecflow
{
    //static class that can be used in all classes to print text to the test output 
    public static class DebugConsole
    {
        static DebugConsole()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));  //creates a trace listener to the currently running test
        }
        //writes string to test output
        public static void Write(string str)
        {
            Trace.Write(str);                                               
        }
        //writes string with a newline to test output
        public static void WriteLine(string str)
        {
            Trace.WriteLine(str);
        }
    }
}
