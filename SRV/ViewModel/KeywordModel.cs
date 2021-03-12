using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class KeywordModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<KeywordModel> DownLevels { get; set; }
        public IList<KeywordModel> UpLevels { get; set; }
        /// <summary>
        /// 关键字属于那一级
        /// </summary>
        public int Level { get; set; }




    }
}
