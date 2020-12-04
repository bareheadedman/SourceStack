using assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Repository

{
    public class CategoryRepository
    {
        private static List<Category> categories { get; set; }
        static CategoryRepository()
        {
            categories = new List<Category>()
            {
                new Category(){Id=1,Title="源栈培训：ASP.NET全栈开发",Content="飞哥的源栈培训：线上全程直播，免费收看；线下拎包入住，按周计费。本系列收录所有讲义（含视频录播地址",Author=new User(){ Id=1,Name="叶飞"} },
                new Category(){Id=2,Title="编程那些事，讲课那些天",Content="一些和课程和编程相关，不宜放在培训系列中一些随想杂谈……",Author=new User(){ Id=1,Name="叶飞"} },
                new Category(){Id=3,Title="折腾",Content="生命不息，折腾不止。十年青葱岁月，多少辛酸回忆……",Author=new User(){ Id=2,Name="马保国"} },
                new Category(){Id=3,Title="Web前端",Content="包含基础的HTML/CSS/Javascript语法，以及Bootstrap/JQuery框架；高级的ES6/TypeScript，以及Vue.js等",Author=new User(){ Id=2,Name="马保国"} },



            };
        }

        public List<Category> Find(int userId)
        {
            return categories.Where(c => c.Author.Id == userId).ToList();
        }
    }
}
