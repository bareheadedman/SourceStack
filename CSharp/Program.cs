using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Schema;


namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {


            User lw = new User("刘伟", "") { Reward = 100, HelpMoney = 10 };
            User xy = new User("小鱼", "") { Reward = 100, HelpMoney = 10 };
            User fg = new User("飞哥", "") { Reward = 100, HelpMoney = 10 };
            User gty = new User("龚廷义", "") { Reward = 100, HelpMoney = 10 };
            User lgy = new User("廖光银", "") { Reward = 100, HelpMoney = 10 };
            User zl = new User("邹丽", "") { Reward = 100, HelpMoney = 10 };



            ContentService fb = new ContentService();

            ContentDateTime alter = new ContentDateTime();


            Article lwarticle = new Article() { Title = "刘伟好帅", Body = "我是刘伟就是帅", Author = lw };
            fb.Publish(lwarticle);
            alter.AlterPublishTime(lwarticle, new DateTime(2018, 2, 3));

            Article xyarticle = new Article() { Title = "C#", Body = "我是小鱼C#", Author = xy };
            fb.Publish(xyarticle);
            alter.AlterPublishTime(xyarticle, new DateTime(2020, 7, 18));

            Article fgarticle = new Article() { Title = ".NET", Body = "我是飞哥,NET", Author = fg };
            fb.Publish(fgarticle);
            alter.AlterPublishTime(fgarticle, new DateTime(2014, 6, 3));

            Article zlarticle = new Article() { Title = "C#", Body = "我是邹丽C#", Author = zl };
            fb.Publish(zlarticle);
            alter.AlterPublishTime(zlarticle, new DateTime(2012, 7, 6));

            Article fgarticle2 = new Article() { Title = ".NET", Body = "我是飞哥2.NET", Author = fg };
            fb.Publish(fgarticle2);
            alter.AlterPublishTime(fgarticle2, new DateTime(2008, 8, 9));

            Article xyarticle2 = new Article() { Title = "", Body = "我是小鱼 小鱼儿", Author = xy };
            fb.Publish(xyarticle2);
            alter.AlterPublishTime(xyarticle2, new DateTime(2010, 12, 23));

            Article fgarticle3 = new Article() { Title = "C#", Body = "我是飞哥3.C#", Author = fg };
            fb.Publish(fgarticle3);
            alter.AlterPublishTime(fgarticle3, new DateTime(2018, 8, 13));

            Article fgarticle4 = new Article() { Title = "飞哥好帅", Body = "我是飞哥就是帅", Author = fg };
            fb.Publish(fgarticle4);


            IList<Article> articles = new List<Article>();
            articles.Add(lwarticle);
            articles.Add(xyarticle);
            articles.Add(fgarticle);
            articles.Add(zlarticle);
            articles.Add(fgarticle2);
            articles.Add(xyarticle2);
            articles.Add(fgarticle3);
            articles.Add(fgarticle4);


            Appraise zlappraise = new Appraise() { vote = zl };
            zlappraise.Agree();

            lwarticle.AppraiseS = new List<Appraise>();
            lwarticle.AppraiseS.Add(zlappraise);

            Appraise xyappraise = new Appraise() { vote = xy };
            xyappraise.Agree();

            fgarticle.AppraiseS = new List<Appraise>();
            fgarticle.AppraiseS.Add(xyappraise);

            Appraise fgappraise = new Appraise() { vote = fg };
            fgappraise.Disagree();

            xyarticle.AppraiseS = new List<Appraise>();
            xyarticle.AppraiseS.Add(fgappraise);

            Appraise lwappraise = new Appraise() { vote = lw };
            lwappraise.Agree();
            fgarticle.AppraiseS.Add(lwappraise);

            Appraise lgyappraise = new Appraise() { vote = lgy };
            lgyappraise.Agree();
            xyarticle.AppraiseS.Add(lgyappraise);

            Appraise gtyappraise = new Appraise() { vote = gty };
            gtyappraise.Disagree();
            fgarticle.AppraiseS.Add(gtyappraise);

            Comment<Article> lwcomment = new Comment<Article>() { Author = lw, Body = "写得好,我是刘伟" };
            Comment<Article> gtycomment = new Comment<Article>() { Author = gty, Body = "写得好，我是龚廷义" };
            Comment<Article> lgycomment = new Comment<Article>() { Author = lgy, Body = "写得好，写得好我是廖光银" };
            Comment<Article> zlycomment = new Comment<Article>() { Author = zl, Body = "写得好，写得好我是邹丽" };



            fgarticle.Comments = new List<Comment<Article>>();
            fgarticle.Comments.Add(lwcomment);
            fgarticle.Comments.Add(gtycomment);
            fgarticle.Comments.Add(zlycomment);


            xyarticle.Comments = new List<Comment<Article>>();
            xyarticle.Comments.Add(lgycomment);
            xyarticle.Comments.Add(zlycomment);

            lwarticle.Comments = new List<Comment<Article>>();
            lwarticle.Comments.Add(zlycomment);

            zlarticle.Comments = new List<Comment<Article>>();
            zlarticle.Comments.Add(lwcomment);

            xyarticle2.Comments = new List<Comment<Article>>();
            xyarticle2.Comments.Add(lwcomment);

            fgarticle2.Comments = new List<Comment<Article>>();
            fgarticle2.Comments.Add(zlycomment);

            fgarticle3.Comments = new List<Comment<Article>>();
            fgarticle3.Comments.Add(zlycomment);

            fgarticle4.Comments = new List<Comment<Article>>();
            fgarticle4.Comments.Add(lwcomment);


            Keyword<Article> k1 = new Keyword<Article>() { Name = "C#" };
            Keyword<Article> k2 = new Keyword<Article>() { Name = ".NET" };
            Keyword<Article> k3 = new Keyword<Article>() { Name = "66666" };


            lwarticle.Keywords = new List<Keyword<Article>>();
            xyarticle.Keywords = new List<Keyword<Article>>();
            zlarticle.Keywords = new List<Keyword<Article>>();
            fgarticle.Keywords = new List<Keyword<Article>>();

            xyarticle2.Keywords = new List<Keyword<Article>>();
            fgarticle2.Keywords = new List<Keyword<Article>>();
            fgarticle3.Keywords = new List<Keyword<Article>>();
            fgarticle4.Keywords = new List<Keyword<Article>>();

            lwarticle.Keywords.Add(k3);
            zlarticle.Keywords.Add(k1);
            xyarticle.Keywords.Add(k1);
            fgarticle.Keywords.Add(k2);
            xyarticle2.Keywords.Add(k3);
            fgarticle2.Keywords.Add(k2);
            fgarticle3.Keywords.Add(k1);
            fgarticle4.Keywords.Add(k3);







            //            一篇文章可以有多个评论
            //一个评论必须有一个它所评论的文章
            //每个文章和评论都有一个评价
            //一篇文章可以有多个关键字，一个关键字可以对应多篇文章





            //            在之前“文章 / 评价 / 评论 / 用户 / 关键字”对象模型的基础上，添加相应的数据，然后完成以下操作：

            //找出“飞哥”发布的文章


            //var result = from a in articles
            //             where a.Author.Name == "飞哥"
            //             select a;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body);
            //}



            //var result = articles.Where(a => a.Author.Name == "飞哥");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body);
            //}


            //找出2019年1月1日以后“小鱼”发布的文章

            //var result = from a in articles
            //             where a.Author.Name == "小鱼" &&
            //                   a.PublishTime > new DateTime(2019, 1, 1)
            //             select a;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body);
            //}




            //var result = articles.Where(a => a.Author.Name == "小鱼"  && 
            //                            a.PublishTime > new DateTime(2019, 1, 1)
            //                            );



            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body);
            //}




            //按发布时间升序 / 降序排列显示文章

            //var result = from a in articles
            //             orderby a.PublishTime
            //             select a;

            //var result = from a in articles
            //             orderby a.PublishTime descending
            //             select a;


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.PublishTime);
            //}        




            //var result = articles.OrderBy(a => a.PublishTime);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Body }+{"：得发布时间："}+{item.PublishTime}");
            //}


            //var result = articles.OrderByDescending(a => a.PublishTime);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Body }+{"：得发布时间："}+{item.PublishTime}");
            //}



            //统计每个用户各发布了多少篇文章

            //var result = from a in articles
            //             group a by a.Author;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Key.Name);
            //    Console.WriteLine(item.Count());
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i.Body);
            //    }
            //}



            //var result = articles.GroupBy(a=>a.Author);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Key.Name);
            //    Console.WriteLine(item.Count());
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i.Body);
            //    }
            //}




            //找出包含关键字“C#”或“.NET”的文章



            //var result = from a in articles
            //             where a.Keywords.Any(a => a.Word == "C#" || a.Word == ".NET")
            //             select a;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body);
            //}





            //var result = articles.SelectMany(
            //    a => a.Keywords,
            //    (a, k) => new { a.Body, k.Word }
            //    ).Where(k => k.Word == "C#" || k.Word == ".NET");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body,item.Word);
            //}




            //找出评论数量最多的文章

            //var result = from a in articles
            //             orderby a.Comments.Count() descending
            //             select a;
            //Console.WriteLine(result.First().Body);



            //var result = articles.OrderByDescending(a => a.Comments.Count);

            //Console.WriteLine(result.First().Body+"：数量："+result.First().Comments.Count);


            //找出每个作者评论数最多的文章


            //var result = from a in articles
            //             group a by a.Author;

            //foreach (var item in result)
            //{
            //    var kk = from i in item
            //             orderby i.Comments.Count() descending
            //             select i;
            //    Console.WriteLine(kk.First().Body,kk.First().Author);
            //}



            //var result = articles.GroupBy(a => a.Author);

            //foreach (var item in result)
            //{
            //    var kk = item.OrderByDescending(a => a.Comments.Count());
            //    Console.WriteLine(kk.First().Body+":"+kk.First().Author.Name);
            //}


            //            将之前作业的Linq查询表达式用Linq方法实现

            //找出每个作者最近发布的一篇文章
            //为求助（Problem）添加悬赏（Reward）属性，并找出每一篇求助的悬赏都大于5个帮帮币的求助作者

            Problem lwproblem = new Problem("求组C#我是刘伟") { Reward = 10, Author = lw };
            Problem zlproblem = new Problem("求组JAVA我是邹丽") { Reward = 3, Author = zl };
            Problem fgproblem = new Problem("求组.NET我是飞哥") { Reward = 7, Author = fg };
            Problem xyproblem = new Problem("求组!!!我是小鱼") { Reward = 1, Author = xy };
            Problem gtyproblem = new Problem("求组啊我是龚廷义") { Reward = 8, Author = gty };

            IList<Problem> problems = new List<Problem>() { lwproblem, zlproblem, fgproblem, xyproblem, gtyproblem };


            //var result = from p in problems
            //             where p.Reward > 5
            //             select p;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body+"悬赏:"+item.Reward);
            //}


            //var result = problems.Where(a => a.Reward > 5);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Body+"悬赏："+item.Reward);
            //}




            //var result = from a in articles
            //             group a by a.Author;


            //foreach (var item in result)
            //{
            //    var kk = from i in item
            //             orderby i.PublishTime descending
            //             select i;
            //    Console.WriteLine(kk.First().Body + ":" + kk.First().PublishTime);
            //}





            //var result = articles.GroupBy(a => a.Author);

            //foreach (var item in result)
            //{
            //    var kk = item.OrderByDescending(a =>a.PublishTime);
            //    Console.WriteLine(kk.First().Body + ":" + kk.First().PublishTime);
            //}



            //MimicStack<int> mimic = new MimicStack<int>(10);
            //mimic.Push(3, 5, 5);
            //int a;
            //a = mimic.Pop();
            //Console.WriteLine(a);
            //a = mimic.Pop();
            //Console.WriteLine(a);
            //a = mimic.Pop();
            //Console.WriteLine(a);
            //a = mimic.Pop();
            //Console.WriteLine(a);



            //DLinkNode<int> dLink1 = new DLinkNode<int>() { Content = 1 };
            //DLinkNode<int> dLink2 = new DLinkNode<int>() { Content = 2 };
            //DLinkNode<int> dLink3 = new DLinkNode<int>() { Content = 3 };
            //DLinkNode<int> dLink4 = new DLinkNode<int>() { Content = 4 };
            //DLinkNode<int> dLink5 = new DLinkNode<int>() { Content = 5 };
            //DLinkNode<int> dLink6 = new DLinkNode<int>() { Content = 6 };
            //DLinkNode<int> dLink7 = new DLinkNode<int>() { Content = 7 };


            DLinkNode<string> dLink1 = new DLinkNode<string>() { Content = "1" };
            DLinkNode<string> dLink2 = new DLinkNode<string>() { Content = "2" };
            DLinkNode<string> dLink3 = new DLinkNode<string>() { Content = "3" };
            DLinkNode<string> dLink4 = new DLinkNode<string>() { Content = "4" };
            DLinkNode<string> dLink5 = new DLinkNode<string>() { Content = "5" };
            DLinkNode<string> dLink6 = new DLinkNode<string>() { Content = "6" };
            DLinkNode<string> dLink7 = new DLinkNode<string>() { Content = "7" };



            dLink1.AddAfter(dLink2);
            dLink2.AddAfter(dLink3);
            dLink3.AddAfter(dLink4);
            dLink4.AddAfter(dLink5);
            dLink5.AddAfter(dLink6);
            dLink6.AddAfter(dLink7);

            //foreach (var item in dLink2)
            //{
            //    Console.WriteLine(item.Content);
            //}


            //Console.WriteLine(dLink1.Max());
        }
    }


}

