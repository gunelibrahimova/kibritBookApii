using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageManager
    {
        void Add(Language language);
        void Remove(Language language, int id);
        void Update(Language language, int id);
        List<Language> GetAllLanguage();
        Language GetLanguageById(int id);
    }
}
