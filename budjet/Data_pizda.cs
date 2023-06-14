using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budjet
{
    internal class Data_pizda
    {
        public string Nazv { 
            get; 
            set; 
        }
        
        public string Denga { 
            get; 
            set; 
        }
        
        public bool Proch { 
            get; 
            set; 
        }
        
        public string Tip { 
            get; 
            set; 
        }
        
        public DateTime Vrema {
            get; 
            set; 
        }

        public Data_pizda(string text, string money, string type, bool proch, DateTime date)
        {
            Nazv = text;
            Denga = money;
            Tip = type;
            Proch = proch;
            Vrema = date;
        }
    }
}