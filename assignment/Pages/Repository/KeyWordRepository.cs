using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E = assignment.Pages.Entities;
namespace assignment.Pages.Repository
{
    public class KeyWordRepository
    {
        public static List<E.KeyWord> KeyWords { get; set; }

        static KeyWordRepository()
        {
            KeyWords = new List<E.KeyWord>();
        }

        public E.KeyWord Find(int id)
        {
            return KeyWords.Where(K => K.Id == id).SingleOrDefault();
        }
    }
}
