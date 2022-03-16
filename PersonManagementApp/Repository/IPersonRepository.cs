using PersonManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementApp.Repository
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
        List<Person> GetPersons();
        Person CreatePerson(Person person);
        Person EditPerson(Person person);
        Person DeletePerson(int id);
    }
}
