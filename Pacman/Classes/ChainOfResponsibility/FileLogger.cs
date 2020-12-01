using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Classes.Adapter;

namespace Pacman.Classes.ChainOfResponsibility
{
    class FileLogger : AbstractLogger
    {
        private Form1 _form;
        public override Form1 Form { get => _form; set => _form = value; }
        public FileLogger(Form1 form, int logLevel): base(logLevel)
        {
            _form = form;
        }

        

        public override void LogData(string message)
        {
            try
            {
                FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), "LogFile"), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(message);
                objStreamWriter.Close();
                objFilestream.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
