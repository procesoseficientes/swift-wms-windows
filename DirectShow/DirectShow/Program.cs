using System;
using System.Windows.Forms;

namespace DirectShow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            //Application.Run(new TakePicture());
            Application.Run(new TakePicture(){FilePath =args[0]});
        }
    }
}