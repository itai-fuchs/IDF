using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IDF.Loger
{
    internal class Logger
    {
        private static Logger instance=null;
        private static string path = "./exam.txt";
        private Logger() { }
        public static Logger GetLogger()
        { 
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

      
        
        public string Read()
        {
          return File.ReadAllText(path);
           
        }

        public void Log(string text)
        {
            File.WriteAllText(path, text);
        }
        
        public void Add (string text)
        {
            File.AppendAllText(path, text);
        }
        
        

    


    }
}
