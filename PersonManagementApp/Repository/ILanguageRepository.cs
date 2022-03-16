using PersonManagementApp.Models;
using System.Collections.Generic;

namespace PersonManagementApp.Repository
{
    public interface ILanguageRepository
    {
        Languages GetLanguage(int id);
        List<Languages> GetLanguages();
    }
}