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


    }
}
