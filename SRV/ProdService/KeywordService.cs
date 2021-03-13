using BLL.Entities;
using BLL.Repositories;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class KeywordService : BaseService, IKeywordService
    {
        private KeywordRepository keywordRepository;
        public KeywordService()
        {
            keywordRepository = new KeywordRepository(context);
        }

        public IList<KeywordModel> GetByLevel(int level)
        {
            IList<Keyword> keywords = keywordRepository.GetByLevel(level);
            if (keywords == null)
            {
                return null;
            }// else nothing
            return mapper.Map<IList<Keyword>, IList<KeywordModel>>(keywords);
        }

        public IList<KeywordModel> GetByNameToDownLevel(string name)
        {
            IList<Keyword> keywords = keywordRepository.GetByDownLevel(name);
            return mapper.Map<IList<Keyword>, IList<KeywordModel>>(keywords);

        }
    }
}
