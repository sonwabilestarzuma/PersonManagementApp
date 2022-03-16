using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementApp.Models
{
   public class Languages
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public void printLanguagesInfo()
        {
            Console.WriteLine("ID: " + Id + " , Name: " + Name);
        }
    }
}
    
