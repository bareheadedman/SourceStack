using assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E = assignment.Entities;
namespace assignment.Repository

{
    public class UserRepository
    {
        private static List<User> users;
        static UserRepository()
        {
            users = new List<User>()
            {
               new User(){ Id = 1,Name="叶飞",PassWord="12345",InviterCode="6666",Articles =new List<E.Article>()
               {
                                new E.Article(){PublishTime=new DateTime(2020,8,20,8,7,20),
                      Id=1,
                      Title ="1-VS中的第一个页面",
                      Body = "学习HTML，其实就是学习一系列的标记（markup），而标记的核心就是元素（element）HTML标记语言的核心就是元素。 元素由标签、属性和文本内容组成，",
                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "VS" },new KeyWord() {Content = "HTML" },new KeyWord() {Content = "入门" } },
                      comments = new List<Comment>(){},
                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Up } },
                      Author = new User(){Id=1,Name ="叶飞" },
                     },
                                new E.Article(){PublishTime=new DateTime(2020,8,21,5,4,20),
                                      Id=2,
                                      Title ="2-Promise：回调地狱/then()/fulfiled/reject……",
                                      Body = "回调地狱在JavaScript中，异步通常就伴随着回调（复习：异步和回调）。为什么呢？看下面的代码 let result = false;function loadSuccess() {setTimeout(function () {result = true;}",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "ES6" },new KeyWord() {Content = "promise" },new KeyWord() {Content = "回调地狱" } },
                                      comments = new List<Comment>(){ new Comment() {Content = "我是刘伟飞哥说的好",PublishTime=new DateTime(2015,1,1),Author=new User() {Id=9527,Name="刘伟" },Appraises = new List<Appraise>() { new Appraise() {Direction=UpOrdown.Down },new Appraise() { Direction=UpOrdown.Up} }, Comments = new List<Comment>() { new Comment() { Content="这个评论太对了",PublishTime = new DateTime(2015,1,2),Author= new User() { Id=666,Name="龚廷义"} } } },new Comment() { Author= new User() {Id=777,Name="李智博" },Content="我是李智博飞哥写的好",PublishTime=new DateTime(2015,1,3),Appraises = new List<Appraise>() { new Appraise() { Direction=UpOrdown.Up} }  } },
                                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Up } },
                                      Author = new User(){Id=1,Name ="叶飞" },
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,8,5,15,20,15),
                                      Id=3,
                                      Title ="3-JQuery：表单/Ajax/其他……",
                                      Body = "表单简写: / :submit / :text ……prop()以及val()文本：text 和 textarea选择 ：check 和 radio下拉列表：select常用：取值赋值：选中只读/禁用JQuery效果hide()/show()/toggle() 淡入淡出：fade...() 滑动：slide 自定义动画：",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "AJAX" },new KeyWord() {Content = "json" },new KeyWord() {Content = "后台" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Down } },
                                      Author = new User(){Id=1,Name ="叶飞" },
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,7,21,11,52,3),
                                      Id=4,
                                      Title ="4-Bootstrap.js：引入/Modal/",
                                      Body = "JS插件 引入bootstrap.js（基于jquery）复习：压缩.min 和 CDN第一个例子：Modaldata-js方法：modal()和option事件总结：",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "bootstrap.js" },new KeyWord() {Content = "插件" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Down } },
                                      Author = new User(){Id=1,Name ="叶飞" },
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,1,2,1,5,2),
                                      Id=5,
                                      Title ="5-ES6和JS进阶：新的集合对象",
                                      Body = "for...in或许是为了模拟其他语言（如C#的foreach），JavaScript推出了for...in循环，可以：遍历对象的全部属性for (var i in student) {console.log(i); ",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "ES6" },new KeyWord() {Content = "集合" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Down } },
                                      Author = new User(){Id=1,Name ="叶飞" },
                                     },

               } },

               new User(){ Id=2,Name="马保国",PassWord="1234" ,InviterCode="8888",Articles = new List<E.Article>(){

                                new E.Article(){PublishTime=new DateTime(2020,9,1,1,5,33),
                      Id=6,
                      Title ="6-Javascript的昨天今天和明天",
                      Body = "for...in或许是为了模拟其他语言（如C#的foreach），JavaScript推出了for...in循环，可以：遍历对象的全部属性for (var i in student) {console.log(i); ",
                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "JavaScript" },new KeyWord() {Content = "介绍" },new KeyWord() {Content = "历史" } },
                      comments = new List<Comment>(){},
                      appraises = new List<Appraise>(){},
                      Author = new User(){Id=2,Name ="马保国" },
                     },
                                new E.Article(){PublishTime=new DateTime(2020,9,9,3,52,20),
                                      Id=7,
                                      Title ="7-JavaScript：事件：冒泡和捕获机制",
                                      Body = "一般的事件处理不需要考虑这种情况。但是，这不仅是一个常见面试题，而且有其实际使用场景。演示准备 有父子两个元素<div id=\"propagate>\" <p>源栈欢迎您</p></div>为了便于演示，加上一点CSS效果：",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "JavaScript" },new KeyWord() {Content = "事件" },new KeyWord() {Content = "冒泡" },new KeyWord() {Content = "捕获" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){ new Appraise() {Direction=UpOrdown.Up },new Appraise() {Direction=UpOrdown.Down },new Appraise() {Direction=UpOrdown.Down } },
                                      Author = new User(){Id=2,Name ="马保国" },
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,7,1,23,30,30),
                                      Id=8,
                                      Title ="8-999天晚上聊一聊：检索目录：001-111",
                                      Body = "哪怕是行为艺术，我也要坚持999天！ 每天晚7点，欢迎围观 ",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "飞哥" },new KeyWord() {Content = "999天" },new KeyWord() {Content = "晚7点" } },
                                      comments = new List<Comment>(){ new Comment() {Content="支持" } },
                                      appraises = new List<Appraise>(){},
                                      Author = new User(){Id=2,Name ="马保国"},
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,11,21,6,22,38),
                                      Id=9,
                                      Title ="9-JavaScript：作用域：函数作用域/全局变量污染/命名空间",
                                      Body = "在C#中我们都基本上不讲作用域，因为一切都是自然而然的（用语言描述反而有些困难）。但JavaScript的作用域，让人非常头大！局部变量如果一个变量在函数体内部申明， ",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "作用域" },new KeyWord() {Content = "全局变量污染" },new KeyWord() {Content = "词法" },new KeyWord() {Content = "IIFE" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){},
                                      Author = new User(){Id=2,Name ="马保国" },
                                     },
                                new E.Article(){PublishTime=new DateTime(2020,11,21,6,22,38),
                                      Id=10,
                                      Title ="10闪电五连鞭",
                                      Body = "年轻人速度快。不讲武德，耗子尾汁",
                                      keyWords = new List<KeyWord>(){ new KeyWord() {Content = "作用域" },new KeyWord() {Content = "全局变量污染" },new KeyWord() {Content = "词法" },new KeyWord() {Content = "IIFE" } },
                                      comments = new List<Comment>(){},
                                      appraises = new List<Appraise>(){},
                                      Author = new User(){Id=2,Name ="马保国" },
                                     },


               } },

            };
        }

        public User Find(int id)
        {
            return users.Where(u => u.Id == id).SingleOrDefault();
        }

        public void Save(User user)
        {
            users.Add(user);
        }

        public User GetByName(string name)
        {
            return users.Where(u => u.Name == name).SingleOrDefault();
        }
    }
}
