using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ALEx
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Mutex Mut_Ex = new Mutex(true, "A.L.Ex.", out bool rulareNoua);
            if (rulareNoua == false) { return; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<string> args = Environment.GetCommandLineArgs().Skip(1).ToList();
            frm_Main frmMAIN = new frm_Main(args);
            frmMAIN.Show();
            Application.Run();

            //Application.Run(new frm_Main());
        }
    }
}
