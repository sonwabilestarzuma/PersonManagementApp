using PersonManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagementApp.Repository
{

    public class MockUpLanguageRepository : ILanguageRepository
    {
        private List<Languages> languageList;
        public MockUpLanguageRepository()
        {
            languageList = new List<Languages>()
            {
                new Languages{Id=1,Name="Java"},
                new Languages{Id=2, Name="C#"},
                new Languages{Id=3,Name="Python"},
                new Languages{Id=4,Name="JavaScript"},
                new Languages{Id=5,Name="Delphi"},
                new Languages{Id=6,Name="MATLAB"},
                new Languages{Id=7,Name="Groovy"},
                new Languages{Id=8,Name="MATLAB"},
                new Languages{Id=9,Name="Lua"},
                new Languages{Id=10,Name="Ruby"},
                new Languages{Id=11,Name="Rust"},
                new Languages{Id=12,Name="PHP"},
                new Languages{Id=13,Name="C++"},

            };
        }

        public Languages GetLanguage(int id)
        {
            Languages languageInRepo = languageList.SingleOrDefault(c => c.Id == id);
            if (languageInRepo == null)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Invalid language id!");
                Console.WriteLine("----------------------");
                return null;
            }
            return languageInRepo;
        }

        public List<Languages> GetLanguages()
        {
            return languageList;
        }
    }
}





