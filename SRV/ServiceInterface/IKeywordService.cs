using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ServiceInterface
{
    public interface IKeywordService
    {

        /// <summary>
        /// 找到某个level的关键字
        /// </summary>
        /// <param name="level">等级</param>
        /// <returns>没有则返回null</returns>
        IList<KeywordModel> GetByLevel(int level);

        /// <summary>
        /// 通过name找到某个关键字的下一级所有关键字
        /// </summary>
        /// <param name="name">名字 </param>
        /// <returns>没有则返回null</returns>
        IList<KeywordModel> GetByNameToDownLevel(string name);
    }
}
