using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sium
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new ztc());
         //  Application.Run(new MDIParent1());
            //Application.Run(new GNumber());
            //Application.Run(new OUexecl());
            //Application.Run(new KeyWordTao());
            //Application.Run(new DPindex());
            //Application.Run(new  Formtest());
            //Application.Run(new XMlist());
            Application.Run(new MAXList());
          //Application.Run(new Formtest());
        }
    }
}
