#region MS Directive(s)
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
#endregion

namespace TraceDemo
{
    /// <summary>
    /// To roll trace file after specific size
    /// Keeps specified number of Trace Files.
    /// </summary>
    [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
    public class RollingTraceListener : TextWriterTraceListener
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="RollingTextWriterTraceListener"/> 
        /// class by specifying the trace file name.
        /// </summary>
        /// <param name="filename">The trace file name.</param>
        public RollingTraceListener(string filename)
        {
            GenerateLogFile(filename);

            if (!string.IsNullOrEmpty(logFile))
            {
                textWriterTraceListener = new TextWriterTraceListener(logFile);
                CloseStreamWriter();
                IntializeWriter();
                this.Writer = textWriterTraceListener.Writer;
                isFreeDiskSpaceAvailable = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="RollingTextWriterTraceListener"/> 
        /// class by specifying the trace file name and the name of the new instance.
        /// </summary>
        /// <param name="filename">
        /// The trace file name.
        /// </param>
        /// <param name="name">
        /// The name of the new instance.
        /// </param>
        public RollingTraceListener(string filename, string name)
            : this(filename)
        {
            textWriterTraceListener.Name = name;
            this.Name = textWriterTraceListener.Name;
        }
        #endregion

        #region Private Member(s)

        /// <summary>
        /// LogFile name
        /// </summary>
        private string logFile = string.Empty;

        /// <summary>
        /// Trace listener instance
        /// </summary>
        TextWriterTraceListener textWriterTraceListener = null;

        /// <summary>
        /// The size in MB of a trace file before a new file is created. 
        /// The default value is 40 MB
        /// </summary>
        private double maxTraceFileSize = maxRollupTraceFileSize;

        /// <summary>
        /// the number of trace files to be retained
        /// the default value is 5 numbers
        /// </summary>
        private int maxTraceFiles = maxNumberOfTraceFiles;

        /// <summary>
        /// This field will be used to remember whether or not 
        /// we have loaded the custom attributes from the config yet. 
        /// The initial value is, of course, false.
        /// </summary>
        private bool attributesLoaded = false;

        /// <summary>
        /// The default size of the trace file.
        /// </summary>
        private const double maxRollupTraceFileSize = 40;

        /// <summary>
        /// The default number of Trace Files
        /// </summary>
        private const int maxNumberOfTraceFiles = 5;

        /// <summary>
        /// size of kilo byte
        /// </summary>
        private const int kiloByteSize = 1024;

        /// <summary>
        /// This Flag is Set when an IOException occurs because of Disk space full
        /// </summary>
        /// <c>true</c> if free space available; otherwise, <c>false</c>.
        private bool isFreeDiskSpaceAvailable;
        #endregion

        #region Public Member(s)

        /// <summary>
        /// Flag to check if there is any free disk space available for the Traces to Write
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is free disk space available; otherwise, <c>false</c>.
        /// </value>
        public bool IsFreeDiskSpaceAvailable
        {
            get
            {
                return isFreeDiskSpaceAvailable;
            }
            private set
            {
                isFreeDiskSpaceAvailable = value;
            }
        }


        /// <summary>
        /// Gets or sets the maximum size of the trace file.
        /// </summary>
        /// <value>The maximum size of the trace file.</value>
        public double MaxTraceFileSize
        {
            get
            {
                if (!this.attributesLoaded)
                {
                    this.LoadAttributes();
                }

                return this.maxTraceFileSize;
            }

            set
            {
                if (!this.attributesLoaded)
                {
                    this.LoadAttributes();
                }

                this.maxTraceFileSize = value;
            }
        }

        /// <summary>
        /// Gets or Sets the maximum number of Trace Files to be created
        /// </summary>
        public int MaxTraceFiles
        {
            get
            {
                if (!this.attributesLoaded)
                {
                    this.LoadAttributes();
                }

                return this.maxTraceFiles;
            }

            set
            {
                if (!this.attributesLoaded)
                {
                    this.LoadAttributes();
                }

                this.maxTraceFiles = value;
            }
        }

        /// <summary>
        /// Emits an error message to the listener.
        /// </summary>
        /// <param name="message">A message to emit.</param>
        public override void Fail(string message)
        {

            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }

                try
                {
                    base.Fail(message);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Emits an error message and a detailed message to the listener.
        /// </summary>
        /// <param name="message">
        /// The error message to write.
        /// </param>
        /// <param name="detailMessage">
        /// The detailed error message to append to the error message.
        /// </param>
        public override void Fail(string message, string detailMessage)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }

                try
                {
                    base.Fail(message, detailMessage);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes trace information, a data object, and event information to the file or stream.
        /// </summary>
        /// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache"/>
        /// that contains the current process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">The source name.</param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values.
        /// </param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="data">A data object to emit.</param>
        public override void TraceData(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, object data)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes trace information, data objects, and event information to the file or stream.
        /// </summary>
        /// <param name="eventCache">
        /// A <see cref="T:System.Diagnostics.TraceEventCache"/> that contains the current 
        /// process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">The source name.</param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values.
        /// </param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="data">An array of data objects to emit.</param>
        public override void TraceData(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, params object[] data)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes trace and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache"/>
        /// object that contains the current process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">A name used to identify the output, 
        /// typically the name of the application that generated the trace event.
        /// </param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values specifying the type 
        /// of event that has caused the trace.
        /// </param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <PermissionSet>
        ///     <IPermission class="System.Security.Permissions.EnvironmentPermission,
        ///     mscorlib, Version=2.0.3600.0, Culture=neutral, 
        ///     PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
        ///     <IPermission class="System.Security.Permissions.SecurityPermission, 
        ///     mscorlib, Version=2.0.3600.0, Culture=neutral, 
        ///     PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/>
        /// </PermissionSet>
        public override void TraceEvent(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceEvent(eventCache, source, eventType, id);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }


        }

        /// <summary>
        /// Writes trace information, a message, and event information to the file or stream.
        /// </summary>
        /// <param name="eventCache">
        /// A <see cref="T:System.Diagnostics.TraceEventCache"/> that contains the current 
        /// process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">The source name.</param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values.
        /// </param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="message">The message to write.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, string message)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceEvent(eventCache, source, eventType, id, message);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes trace information, a formatted message, and event information to the file or stream.
        /// </summary>
        /// <param name="eventCache">
        /// A <see cref="T:System.Diagnostics.TraceEventCache"/> that contains the current process ID, 
        /// thread ID, and stack trace information.
        /// </param>
        /// <param name="source">The source name.</param>
        /// <param name="eventType">
        /// One of the <see cref="T:System.Diagnostics.TraceEventType"/> values.
        /// </param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="format">
        /// A format string that contains zero or more format items that correspond to objects
        /// in the <paramref name="args"/> array.
        /// </param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, string format,
            params object[] args)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceEvent(eventCache, source, eventType, id, format, args);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes trace information including the identity of a related activity,
        /// a message, and event information to the file or stream.
        /// </summary>
        /// <param name="eventCache">
        /// A <see cref="T:System.Diagnostics.TraceEventCache"/> that contains the current 
        /// process ID, thread ID, and stack trace information.
        /// </param>
        /// <param name="source">The source name.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="message">A trace message to write.</param>
        /// <param name="relatedActivityId">
        /// A <see cref="T:System.Guid"/> structure that identifies a related activity.
        /// </param>
        public override void TraceTransfer(TraceEventCache eventCache, string source,
            int id, string message, Guid relatedActivityId)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.TraceTransfer(eventCache, source, id, message, relatedActivityId);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes the value of the object's <see cref="M:System.Object.ToString"/> 
        /// method to the listener.
        /// </summary>
        /// <param name="o">
        /// An <see cref="T:System.Object"/> whose fully qualified class name you want to write.
        /// </param>
        public override void Write(object o)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.Write(o);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a category name and the value of the object's 
        /// <see cref="M:System.Object.ToString"/> method to the listener.
        /// </summary>
        /// <param name="o">
        /// An <see cref="T:System.Object"/> whose fully qualified class name you want to write.
        /// </param>
        /// <param name="category">A category name used to organize the output.</param>
        public override void Write(object o, string category)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.Write(o, category);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a verbatim message without any 
        /// additional context information to the file or stream.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string message)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }

                try
                {
                    base.Write(message);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a category name and a message to the listener.
        /// </summary>
        /// <param name="message">A message to write.</param>
        /// <param name="category">A category name used to organize the output.</param>
        public override void Write(string message, string category)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.Write(message, category);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes the value of the object's <see cref="M:System.Object.ToString"/> 
        /// method to the listener.
        /// </summary>
        /// <param name="o">
        /// An <see cref="T:System.Object"/> whose fully qualified class name you want to write.
        /// </param>
        public override void WriteLine(object o)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.WriteLine(o);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a category name and the value of the object's 
        /// <see cref="M:System.Object.ToString"/> method to the listener.
        /// </summary>
        /// <param name="o">
        /// An <see cref="T:System.Object"/> whose fully qualified class name you want to write.
        /// </param>
        /// <param name="category">A category name used to organize the output.</param>
        public override void WriteLine(object o, string category)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }


                try
                {
                    base.WriteLine(o, category);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a verbatim message without any additional context
        /// information followed by the current line
        /// terminator to the file or stream.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string message)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }

                try
                {
                    base.WriteLine(message);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Writes a category name and a message to the listener, followed by a line terminator.
        /// </summary>
        /// <param name="message">A message to write.</param>
        /// <param name="category">A category name used to organize the output.</param>
        public override void WriteLine(string message, string category)
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                if (this.IsRollingConditionReached)
                {
                    this.GenerateFile();
                }

                try
                {
                    base.WriteLine(message, category);
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }

        }

        public override void Flush()
        {
            if (this.isFreeDiskSpaceAvailable)
            {
                try
                {
                    base.Flush();
                }
                catch (Exception ex)
                {
                    if (!CheckIfDiskSpaceIsFull(ex))
                    {
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Private Method(s)
        /// <summary>
        /// Generate Log File name
        /// </summary>
        private void GenerateLogFile(string logFileLocation)
        {
            try
            {
                bool isPathRooted = Path.IsPathRooted(logFileLocation);
                if (!isPathRooted)
                {
                    string assemblyLocation = Assembly.GetEntryAssembly().Location;
                    string assemblyDirectoryName = Path.GetDirectoryName(assemblyLocation);
                    logFileLocation = Path.Combine(assemblyDirectoryName, logFileLocation);
                }

                this.logFile = logFileLocation;
            }
            catch (Exception)
            {
                this.logFile = string.Empty;
            }

        }

        /// <summary>
        /// Roll down the files and allow creation of new file for tracing
        /// </summary>
        private void RollDownTraceFiles()
        {
            string fileExtension = Path.GetExtension(logFile);
            string directoryName = Path.GetDirectoryName(logFile);
            string fileName = Path.GetFileName(logFile);
            string fielNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            DirectoryInfo LogFileLocationToSearch = new DirectoryInfo(directoryName);
            int fileCount = LogFileLocationToSearch.GetFiles
                (fielNameWithoutExtension + "*" + fileExtension).Length;

            // if greater than number of files remove oldest file
            if (fileCount >= MaxTraceFiles)
            {
                fileCount = MaxTraceFiles - 1;
                string oldestFile = Path.Combine(directoryName,
                    fielNameWithoutExtension + "_" + fileCount + fileExtension);
                File.Delete(oldestFile);
            }

            //rename files
            for (int i = (fileCount - 1); i >= 0; i--)
            {
                string currentFile = string.Empty;
                string newFile = string.Empty;

                if (i == 0)
                {
                    currentFile = Path.Combine(directoryName,
                        fielNameWithoutExtension + fileExtension);

                    newFile = Path.Combine(directoryName,
                        fielNameWithoutExtension + "_1" + fileExtension);
                }
                else
                {
                    currentFile = Path.Combine(directoryName,
                        fielNameWithoutExtension + "_" + i.ToString() + fileExtension);

                    newFile = Path.Combine(directoryName,
                        fielNameWithoutExtension + "_" + (i + 1).ToString() + fileExtension);
                }

                if (File.Exists(newFile))
                {
                    File.Delete(newFile);
                }

                File.Move(currentFile, newFile);
            }
        }

        /// <summary>
        /// Initialises Writer stream
        /// </summary>
        private void IntializeWriter()
        {
            // create a new file stream and a new stream writer and pass it to the listener
            try
            {
                textWriterTraceListener.Writer = new StreamWriter(
                    new FileStream(this.logFile, FileMode.Append));
            }
            catch (Exception)
            {
                //ignore exception
            }
        }

        /// <summary>
        /// Closes existing File stream of Trace Listener
        /// </summary>
        private void CloseStreamWriter()
        {
            if (textWriterTraceListener.Writer != null)
            {
                StreamWriter streamWriter = (StreamWriter)textWriterTraceListener.Writer;
                FileStream fileStream = (FileStream)streamWriter.BaseStream;
                fileStream.Close();
            }
        }

        /// <summary>
        /// Generate file base on current datetime and 
        /// re-initialize writer
        /// </summary>
        private void GenerateFile()
        {
            CloseStreamWriter();
            RollDownTraceFiles();
            IntializeWriter();
            this.Writer = textWriterTraceListener.Writer;
        }

        /// <summary>
        /// Reads the custom attributes' values from the configuration file.
        /// We call this method the first time the attributes are accessed.
        /// <remarks>
        /// We do not do this when the listener is constructed 
        /// because the attributes will not yet have been read 
        /// from the configuration file.
        /// </remarks>
        /// </summary>
        private void LoadAttributes()
        {
            if (Attributes.ContainsKey("MaxTraceFileSize") &&
                !String.IsNullOrEmpty(Attributes["MaxTraceFileSize"]))
            {
                double tempLong = 0.0;
                string attributeValue = Attributes["MaxTraceFileSize"];

                if (double.TryParse(attributeValue, out tempLong))
                {
                    this.maxTraceFileSize = double.Parse(Attributes["MaxTraceFileSize"], NumberFormatInfo.InvariantInfo);
                }
            }

            this.maxTraceFileSize = this.maxTraceFileSize * kiloByteSize * kiloByteSize;


            if (Attributes.ContainsKey("MaxTraceFileCount") &&
                !String.IsNullOrEmpty(Attributes["MaxTraceFileCount"]))
            {
                int tempValue = 0;
                string attributeValue = Attributes["MaxTraceFileCount"];

                if (int.TryParse(attributeValue, out tempValue))
                {
                    this.maxTraceFiles =
                            int.Parse(Attributes["MaxTraceFileCount"],
                            NumberFormatInfo.InvariantInfo);
                }
            }

            this.attributesLoaded = true;
        }

        private bool CheckIfDiskSpaceIsFull(Exception ex)
        {
            /*
            bool result = ex.HResult == ErrorCodeConstants.HR_ERROR_DISK_FULL ||
                        ex.HResult == ErrorCodeConstants.HR_ERROR_HANDLE_DISK_FULL;
                        */

            bool result = false;
            if (result)
            {
                isFreeDiskSpaceAvailable = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Protected Member(s)


        /// <summary>
        /// Gets a value indicating whether the condition 
        /// to roll over the trace file is reached.
        /// </summary>
        /// <value>
        /// <c>true</c> if the condition to roll over the trace file is reached; 
        /// otherwise, <c>false</c>.
        /// </value>
        protected bool IsRollingConditionReached
        {
            get
            {
                if (base.Writer == null) return false;
                // go down to the file stream
                StreamWriter streamWriter = (StreamWriter)base.Writer;   //traceWriter;
                FileStream fileStream = (FileStream)streamWriter.BaseStream;
                string traceFileName = fileStream.Name;

                FileInfo traceFileInfo = new FileInfo(traceFileName);

                if (traceFileInfo.Length > this.MaxTraceFileSize)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Gets the custom attributes supported by the trace listener.
        /// </summary>
        /// <returns>
        /// A string array naming the custom attributes supported by the trace listener, 
        /// or null if there are no custom attributes.
        /// </returns>
        protected override string[] GetSupportedAttributes()
        {
            return new string[3] { "MaxTraceFileSize", "MaxTraceFileCount", "ReserveDiskSpace" };
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose();
                textWriterTraceListener.Dispose();
            }
        }
        #endregion        
    }
}
