using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Classes.Adapter; 

namespace Pacman.Classes.ChainOfResponsibility
{
    public abstract class AbstractLogger: ILog
    {
        public abstract Form1 Form { get; set; }

        public static int DEBUG = 4;
        public static int CONSOLE = 3;
        public static int FILE = 2;
        public static int DEFAULT = 1;

        private int _level; 

        //next element in chain or responsibility
        protected AbstractLogger nextLogger;

        public AbstractLogger(int logLevel)
        {
            _level = logLevel;
        }

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        //loggeris spausdina tuos pranešimus, kurių lygis didesnis arba lygus loggerio lygiui
        public void LogMessage(int level, string message)
        {
            if (this._level <= level)
            {
                LogData(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }
        public abstract void LogData(string message);
    }
}
