using PersonManagementApp.Models;
using PersonManagementApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonManagementApp
{
    class Program
    {
        static int menu()
        {
            int choose;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("---- PERSON CRUD MENU ----");
                Console.WriteLine("----------------------------");
                Console.Write("1) Create person\n");
                Console.Write("2) Edit person\n");
                Console.Write("3) Get person\n");
                Console.Write("4) Get person(s)\n");
                Console.Write("5) Delete person\n");
                Console.Write("6) END\n");
                Console.WriteLine("----------------------------");
                Console.Write("Input choice: ");
                choose = Convert.ToInt32(Console.ReadLine());
                return choose;
            }
            while (true);
        }
        //Dependency injection
        static ILanguageRepository CreateLanguageRepository()
        {
            return new MockUpLanguageRepository();
        }
        static IPersonRepository CreatePersonRepository()
        {
            return new MockUpPersonRepository(CreateLanguageRepository());
        }


        static void printPersonRepo(List<Person> persons)
        {
            Console.WriteLine("Persons in repository");
            Console.WriteLine("-----------------------");
            for (int i = 0; i < persons.Count(); i++)
            {
                persons[i].printPersonInfo();
                Console.WriteLine("---------------");
            }
        }
        static void Main(string[] args)
        {
            ILanguageRepository languageRepository = CreateLanguageRepository();
            IPersonRepository personRepository = CreatePersonRepository();
            var languagesInRepository = languageRepository.GetLanguages();
            var personsInRepository = personRepository.GetPersons();
            int choose;
            bool programFlow = true;
            do
            {
                choose = menu();
                switch (choose)
                {
                    case 1:
                       Languages languages;
                        Console.WriteLine("Select language type");
                        Console.WriteLine("----------------------");
                        for (int i = 0; i < languagesInRepository.Count(); i++)
                        {
                            languagesInRepository[i].printLanguagesInfo();
                        }
                        Console.WriteLine("----------------------");
                        int languaId;
                        Console.Write("Select language id: ");
                        languaId = Convert.ToInt32(Console.ReadLine());
                        languages = languageRepository.GetLanguage(languaId);
                        while (languages == null)
                        {
                            Console.Write("Select language id: ");
                            languaId = Convert.ToInt32(Console.ReadLine());
                            languages = languageRepository.GetLanguage(languaId);
                        }
                        Person person  = new Person(languages);
                        person.setPerson(languages);
                        personRepository.CreatePerson(person);
                        break;


                    case 2:
                        if (personsInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Person repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            printPersonRepo(personRepository.GetPersons());
                            Console.Write("Input person id: ");
                            int personId = Convert.ToInt32(Console.ReadLine());
                            Person personInRepo = personRepository.GetPerson(personId);
                            while (personInRepo == null)
                            {
                                Console.Write("Input person id: ");
                                personId = Convert.ToInt32(Console.ReadLine());
                                personInRepo = personRepository.GetPerson(personId);
                            }
                            Console.WriteLine("Select language type");
                            Console.WriteLine("----------------------");
                            for (int i = 0; i < languagesInRepository.Count(); i++)
                            {
                                languagesInRepository[i].printLanguagesInfo();
                            }
                            Console.WriteLine("----------------------");
                            Console.Write("Input language id: ");
                            languaId = Convert.ToInt32(Console.ReadLine());
                            languages = languageRepository.GetLanguage(languaId);
                            while (languages== null)
                            {
                                Console.Write("Input language id: ");
                                languaId = Convert.ToInt32(Console.ReadLine());
                                languages = languageRepository.GetLanguage(languaId);
                            }
                            personInRepo.setPerson(languages);
                            personRepository.EditPerson(personInRepo);
                        }

                        break;

                    case 3:
                        if (personsInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Person repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Person ID's in repository");
                            Console.WriteLine("---------------------------");
                            for (int i = 0; i < personsInRepository.Count(); i++)
                            {
                                Console.WriteLine("ID: " + personsInRepository[i].Id);
                                Console.WriteLine("------");
                            }
                            Console.Write("Input person ID to see person details: ");
                            int personId = Convert.ToInt32(Console.ReadLine());
                            Person  personInRepo = personRepository.GetPerson(personId);
                            while (personInRepo == null)
                            {
                                Console.Write("Input person id: ");
                                personId = Convert.ToInt32(Console.ReadLine());
                                personInRepo = personRepository.GetPerson(personId);
                            }
                            personInRepo.printPersonInfo();
                        }
                        break;

                    case 4:
                        if (personsInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Person repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            printPersonRepo(personsInRepository);
                        }
                        break;

                    case 5:
                        if (personsInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Person repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Person ID's in repository");
                            Console.WriteLine("---------------------------");
                            for (int i = 0; i < personsInRepository.Count(); i++)
                            {
                                Console.WriteLine("ID: " + personsInRepository[i].Id);
                                Console.WriteLine("------");
                            }
                            Console.Write("Input person ID to delete same: ");
                            int personId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Are you sure you want to delete this person?(Y/N): ");
                            string confirm = Console.ReadLine();
                            if (confirm == "Y" || confirm == "y")
                            {
                                personRepository.DeletePerson(personId);
                            }
                        }
                        break;

                    case 6:
                        programFlow = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            } while (programFlow);
        }
    }
}
    

