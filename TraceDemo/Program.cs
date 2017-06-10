using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TraceDemo
{
    /// <summary>
    /// Main Class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string assemblyLocation = assembly.Location;
            string filePath = Path.GetFullPath(assemblyLocation);
            string folder = Path.GetDirectoryName(filePath);
            FileSystemWatcher fs = new FileSystemWatcher(@"D:\"); DirectoryInfo ds; 
            fs.Changed += Fs_Changed;
            System.IO.DriveInfo drive = new DriveInfo(Path.GetPathRoot(filePath));
            Console.WriteLine(drive.AvailableFreeSpace.ToString()); 

            string traceFilePath = folder + "\\Demotrace.log";

            TextWriterTraceListener textListener = new TextWriterTraceListener(traceFilePath);
            Trace.Listeners.Add(textListener);
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.Indent();
            Trace.Indent();
            Trace.WriteLineIf(true,"Entering Main from WritelLineIf");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting the Main method from WritelineIf");
            Trace.WriteLineIf(true,"After the UnIndent");
            Trace.WriteLine(Environment.MachineName);
            Trace.Unindent();
            Trace.Unindent();
            Trace.WriteLineIf(true, "After the UnIndent");
            Trace.Unindent();
            Trace.WriteLineIf(true, "After the UnIndent");

        }

        private static void Fs_Changed(object sender, FileSystemEventArgs e)
        {
            //e.ChangeType;
            throw new NotImplementedException();
        }
    }
}
