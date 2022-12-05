using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageManager
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }
        public void Add(Language language)
        {
            _languageDal.Add(language);
        }
        public List<Language> GetAllLanguage()
        {
            return _languageDal.GetAll();
        }
        public Language GetLanguageById(int id)
        {
            return _languageDal.Get(x => x.Id == id);
        }
        public void Remove(Language language, int id)
        {
            var current = _languageDal.Get(x => x.Id == id);
            current.Name = language.Name;
            _languageDal.Delete(current);
        }
        public void Update(Language language, int id)
        {
            var current = _languageDal.Get(x => x.Id == id);
            current.Name = language.Name;
            _languageDal.Update(current);
        }
    }
}
