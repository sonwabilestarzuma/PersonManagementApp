using PersonManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementApp.Repository
{
    public class MockUpPersonRepository : IPersonRepository
    {
        private List<Person> personList;
        private ILanguageRepository languageList;

        public MockUpPersonRepository(ILanguageRepository _languageRepo)
        {
            languageList = _languageRepo;
            Languages d1 = new Languages();
            d1 = languageList.GetLanguage(1);
            Languages d2 = new Languages();
            d2 = languageList.GetLanguage(2);
            Languages d3 = new Languages();
            d3 = languageList.GetLanguage(3);
            Languages d4 = new Languages();
            d4 = languageList.GetLanguage(3);
            Languages d5 = new Languages();
            d5 = languageList.GetLanguage(3);
            Languages d6 = new Languages();
            d6 = languageList.GetLanguage(3);
            Languages d7 = new Languages();
            d7 = languageList.GetLanguage(3);
            Languages d8 = new Languages();
            d8 = languageList.GetLanguage(3);

            personList = new List<Person>()
            {
                new Person(d1){Id=1,FirstName="Star",LastName="Zuma"},
                new Person(d2){Id=2,FirstName="Red",LastName="Star"},
                new Person(d3){Id=3,FirstName="Sonwabo",LastName="Red"},
                 new Person(d4){Id=4,FirstName="mkhonto",LastName="Redy"},
                  new Person(d5){Id=5,FirstName="Sobs",LastName="Soberty"},
                   new Person(d6){Id=6,FirstName="Lobs",LastName="Long"},
                    new Person(d7){Id=7,FirstName="Nunu",LastName="Nene"},
                     new Person(d8){Id=8,FirstName="Sonwabo",LastName="TUYI"}

            };
        }
        public Person CreatePerson(Person person)
        {
            if (personList.Count() == 0)
            {
                person.Id = 1;
            }
            else
            {
                person.Id = personList.Max(c => c.Id) + 1;
            }
            personList.Add(person);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Person added successfully to repository!");
            Console.WriteLine("------------------------------------------");
            return person;
        }


        public Person DeletePerson(int id)
        {
            Person personInRepo = personList.SingleOrDefault(c => c.Id == id);
            if (personInRepo == null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid person ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                personList.Remove(personInRepo);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Person DELETED successfully from repository!");
                Console.WriteLine("----------------------------------------------");
                return personInRepo;
            }

        }


        public Person EditPerson(Person person)
        {
            Person personInRepo = personList.SingleOrDefault(c => c.Id == person.Id);
            if (personInRepo == null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid person ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                personInRepo.FirstName = person.FirstName;
                personInRepo.LastName = person.LastName;
                personInRepo.Languages = person.Languages;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Person data successfully updated!");
                Console.WriteLine("-----------------------------------");
                return personInRepo;
            }
        }


        public Person GetPerson(int id)
        {
            Person personInRepo = personList.SingleOrDefault(c => c.Id == id);
            if (personInRepo == null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid person ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                return personInRepo;
            }
        }

        List<Person> IPersonRepository.GetPersons()
        {
            return personList;
        }
    }
}
    

