﻿using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.MockService
{
    public class KeywordService : IKeywordService
    {
        public IList<KeywordModel> GetByLevel(int level)
        {
            throw new NotImplementedException();
        }

        public IList<KeywordModel> GetByNameToDownLevel(string name)
        {
            throw new NotImplementedException();
        }
    }
}
