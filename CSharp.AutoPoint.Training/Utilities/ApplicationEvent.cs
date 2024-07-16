using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Utilities
{
    public static class ApplicationEvent
    {
        public delegate void StartApplicationEventHandler(object sender, EventArgs e);
        public static event StartApplicationEventHandler StartApplication;

        public static void OnStartApplication()
        {
            StartApplication?.Invoke(null, EventArgs.Empty);
        }
    }
}
