using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WidowsAPI
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);


        [DllImport("kernel32")]
        public static extern void GetSystemInfo(ref SYSTEM_INFO PSI);
          

 
        private static void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                SYSTEM_INFO PSI = new SYSTEM_INFO();
                GetSystemInfo(ref PSI);
                StringBuilder sysInfo = new StringBuilder();

                sysInfo.Append("dwOemId						" + PSI.dwOemId + "\n");
                sysInfo.Append("dwPageSize					" + PSI.dwPageSize + "\n");
                sysInfo.Append("lpMinimumApplicationAddress	" + PSI.lpMinimumApplicationAddress + "\n");
                sysInfo.Append("lpMaximumApplicationAddress	" + PSI.lpMaximumApplicationAddress + "\n");
                sysInfo.Append("dwActiveProcessorMask		" + PSI.dwActiveProcessorMask + "\n");
                sysInfo.Append("dwNumberOfProcessors		" + PSI.dwNumberOfProcessors + "\n");
                sysInfo.Append("dwProcessorType				" + PSI.dwProcessorType + "\n");
                sysInfo.Append("dwAllocationGranularity		" + PSI.dwAllocationGranularity + "\n");
                sysInfo.Append("dwProcessorLevel			" + PSI.dwProcessorLevel + "\n");
                sysInfo.Append("dwProcessorRevision			" + PSI.dwProcessorRevision + "\n");
                MessageBox(0, sysInfo.ToString(), "Wind API Demo", 0);
                
            }
            catch(Exception ex)
            {
                MessageBox(0, ex.Message, "API DEMO", 0);
            }

        }

        static void Main(string[] args)
        {
            Button btn = new Button();
            btn.Click += Btn_Click;
            btn.PerformClick();
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public uint dwOemId;
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }
}
