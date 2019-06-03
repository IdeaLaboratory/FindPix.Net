using System;
using System.Windows;

namespace FindPix.Net
{
    public class Log
    {
        static Log log;

        private Log() { }

        public static Log GetInstance()
        {
            if (log == null)
            {
                log = new Log();
            }

            return log;
        }

        internal void ProcessError(Exception exception)
        {
            var error = "LOGGED: Exception = " + exception.Message;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                error += " : Inner Exception = " + exception.Message;
            }

            //This is where you save to file. 

            MessageBox.Show(error);
        }
    }
}
