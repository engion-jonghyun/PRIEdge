using Engion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIEdge
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bnew;
            string programName = "DSFilmConsole";

            Mutex mutex = new Mutex(true, programName, out bnew);

            try
            {
                if (bnew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    
                    if (!Directory.Exists("C:\\tmp"))
                    {
                        Directory.CreateDirectory("C:\\tmp");
                    }

                    Vars var = new Vars();
                    var.Init();
                    //var.InitDevice();
                    var.InitForm();

                    //Vars.mainViewerForm = new MainViewerForm();
                    Application.Run(Vars.mainViewerForm);
                }
                else
                {
                    MessageBox.Show(programName + " Program Running.");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program_Main_" + ex.Message);
                Vars.log?.AddLogMessage(Engion.LogType.Critical, 0, ex);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
