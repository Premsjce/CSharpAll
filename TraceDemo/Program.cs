using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Windows;

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

            /*FileSystemWatcher fs = new FileSystemWatcher(@"D:\"); DirectoryInfo ds; 
            fs.Changed += Fs_Changed;*/

            DriveInfo drive = new DriveInfo(Path.GetPathRoot(filePath));
            Trace.WriteLine(drive.AvailableFreeSpace.ToString());

            /* string traceFilePath = folder + "\\Demotrace.log";
            TextWriterTraceListener textListener = new TextWriterTraceListener(traceFilePath);
            Trace.Listeners.Add(textListener); 
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.Indent();
            Trace.Indent();*/

            bool isRollingTraceEnable;
            string pathOfRollingTraces;
            //if(Trace.Listeners.Count > 1)
            //{
            //    Console.WriteLine("Please enable only Rolling Trace Listener to enable tracing");
            //}

            foreach (TextWriterTraceListener listener in Trace.Listeners)
            {
                Trace.WriteLine(listener.Name);
                
                if (listener.Name == "RollingTrace")
                {
                    var temp1 = ((listener as RollingTraceListener).Writer) ;
                    var tempStream = temp1 as StreamWriter;
                    isRollingTraceEnable = true;
                    var tempBaseStream = tempStream.BaseStream as FileStream;
                    pathOfRollingTraces = tempBaseStream.Name;
                    Trace.WriteLine(pathOfRollingTraces);

                    var tempSpace = 17179869184;
                    DriveInfo driveInfo = new DriveInfo(pathOfRollingTraces);
                    if(driveInfo.AvailableFreeSpace > tempSpace)
                    {
                        MessageBox.Show("Available Space is lesser than 16GB");
                    }

                }
                else
                {
                    
                }

            }


            var config = ConfigurationManager.AppSettings.AllKeys;


            TraceSource traceSource = new TraceSource("TraceDemo");
            Trace.WriteLineIf(true,"Entering Main from WritelLineIf");
            Trace.WriteLine("Hello World.");
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
