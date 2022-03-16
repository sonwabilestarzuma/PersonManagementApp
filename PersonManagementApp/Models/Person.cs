using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Languages Languages { get; set; }

        public Person(Languages langua)
        {
            Languages = langua;
        }

        private void setFirstName()
        {
            
            bool check = true;
            Console.WriteLine("-------------------------------");
            do
            {
                Console.Write("Input persons first name: ");
                this.FirstName = Console.ReadLine();
                check = Validation.validateFirstName(this.FirstName);
            } while (!check);
        }
        private void setLastName()
        {
            bool check = true;
            Console.WriteLine("------------------------------");
            do
            {
                Console.Write("Input persons last name: ");
                this.LastName = Console.ReadLine();
                check = Validation.validateFirstName(this.LastName);
            } while (!check);
        }
        private void setLanguages(Languages languages)
        {
            Languages = languages;
        }

        public void setPerson(Languages languages)
        {
            this.setFirstName();
            this.setLastName();
            this.setLanguages(languages);
        }

        public void printPersonInfo()
        {
            Console.WriteLine("ID: " + this.Id);
            Console.WriteLine("First Name: " + this.FirstName);
            Console.WriteLine("Last Name: " + this.LastName);
            Console.WriteLine("Language: " + Languages.Name);
        }
    }
}
    


