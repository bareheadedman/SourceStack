using CSharp._17bangTableAdapters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Schema;
using static CSharp._17bang;

namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            SqlDbContext context = new SqlDbContext();

            //var db = context.Database;
            //db.Migrate();
            //db.EnsureDeleted();
            //db.EnsureCreated();



            //利用EF，插入3个User对象

            //User mbg = new User("马保国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id = 1
            //};

            //User mxg = new User("马大国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id = 2
            //};

            //User mdg = new User("马小国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id = 3
            //};
            //context.AddRange(mbg, mxg, mdg);



            //通过主键找到其中一个User对象

            //User user = context.Find<User>("马小国");


            //修改该User对象的Name属性，将其同步到数据库

            //User user = context.Find<User>("马小国");
            //user.Name = "小马国";

            //不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            //User user = new User("马国国", "")
            //{
            //    Id = 3
            //};

            //context.Attach<User>(user);
            //user.HelpBean = 55;


            //删除该用户
            //context.Remove<User>(context.Find<User>("马小国"));



            //            利用Linq to EntityFramework，实现方法：
            //GetBy(IList < ProblemStatus > exclude, bool hasReward, bool descByPublishTime)，该方法可以根据输入参数：
            //IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
            //bool hasReward：只显示已有酬谢的求助（如果传入值为true的话）
            //bool descByPublishTime：按发布时间正序还是倒序
            //参考：求助列表（不显示 / 只显示）和文章列表（正序 / 倒序）

            //context.AddRange(new Problem("总结-撤销") { Title = "总结", ProblemStatus = ProblemStatus.HasBackout, Summary = new Summary() { Content = "问题总结白给" } },
            //                 new Problem("总结-撤销闪电乱鞭9") { Title = "总结", ProblemStatus = ProblemStatus.HasBackout, Summary = new Summary() { Content = "问题总结犹豫就会败北" } },
            //                 new Problem("撤销闪电五连鞭8") { Title = "撤销", ProblemStatus = ProblemStatus.HasBackout },
            //                 new Problem("撤销如何打好闪电五连鞭11") { Title = "撤销", ProblemStatus = ProblemStatus.HasBackout },
            //                 new Problem("协助闪电乱鞭99") { Title = "协助", ProblemStatus = ProblemStatus.Helping },
            //                 new Problem("协助闪电五连鞭88") { Title = "协助", ProblemStatus = ProblemStatus.Helping },
            //                 new Problem("酬谢协助闪电五连鞭66") { Title = "酬谢", ProblemStatus = ProblemStatus.HasReward },
            //                 new Problem("酬谢协助闪电五连鞭77") { Title = "酬谢", ProblemStatus = ProblemStatus.HasReward },
            //                 new Problem("总结酬谢协助闪电五连鞭77") { Title = "酬谢", ProblemStatus = ProblemStatus.HasReward, Summary = new Summary() { Content = "果断就会白给" } },
            //                 new Problem("总结酬谢协助闪电五连鞭77") { Title = "酬谢", ProblemStatus = ProblemStatus.HasReward, Summary = new Summary() { Content = "果断就会白给2" } }

            //);

            //List<ProblemStatus> problemStatuses = new List<ProblemStatus>();
            //problemStatuses.Add(ProblemStatus.HasBackout);
            //problemStatuses.Add(ProblemStatus.HasReward);
            //problemStatuses.Add(ProblemStatus.Helping);


            //IList<Problem> problems = GetBy(problemStatuses, true, false);


            //            实现方法：GetMessage()，靠将消息列表：
            //所有未读在已读前面
            //未读和已读各自按生成时间排序

            //context.Messages.AddRange(
            //    new Message() { DateTime = DateTime.Now.AddDays(-1), Content = "马保国发来挑战", HasRead = true, MessageStatus = MessageStatus.LeaveMessage },
            //    new Message() { DateTime = DateTime.Now.AddDays(-10), Content = "蔡徐坤邀请你打篮球", HasRead = false, MessageStatus = MessageStatus.Inform },
            //    new Message() { DateTime = DateTime.Now.AddDays(-50), Content = "吴亦凡邀请你充电", HasRead = false, MessageStatus = MessageStatus.comment },
            //    new Message() { DateTime = DateTime.Now.AddDays(-100), Content = "赵4邀请你跳舞", HasRead = false, MessageStatus = MessageStatus.comment },
            //    new Message() { DateTime = DateTime.Now.AddDays(-200), Content = "xx邀请你整容", HasRead = true, MessageStatus = MessageStatus.Inform }
            //);

            //IList<Message> messages = GetMessages();


            //            观察一起帮的功能，思考并
            //Email和User有一对一的关系，参照课堂演示，在数据库上建立User外键引用Email的映射
            //按继承映射：Blog / Article / Suggest以及他们的父类Content


            context.Add<Problem>(new Problem() { Author = new User("过过过", "") { CreateTime = DateTime.Now }, Body = "闪电鞭", Title = "打好闪电鞭", ProblemStatus = ProblemStatus.Helping });


            context.SaveChanges();


        }

        static IList<Problem> GetBy(IList<ProblemStatus> exclude, bool hasReward, bool descByPublishTime)
        {
            SqlDbContext context = new SqlDbContext();

            IQueryable<Problem> result = context.Problems;
            foreach (var item in exclude)
            {
                result = result.Where(p => p.ProblemStatus != item);
            }


            if (hasReward)
            {
                if (exclude.Contains(ProblemStatus.HasBackout) && exclude.Contains(ProblemStatus.HasReward))
                {
                    throw new Exception("冲突");
                }
                result = result.Where(P => P.Summary != null);
            }

            result = result.OrderByDescending(P => P.PublishTime);

            if (descByPublishTime)
            {
                result = result.OrderBy(P => P.PublishTime);
            };


            return result.ToList();
        }

        static IList<Message> GetMessages()
        {
            SqlDbContext context = new SqlDbContext();

            //var resultFalse = context.Messages.Where(m => m.HasRead == false).OrderByDescending(m => m.DateTime).ToList();
            //var resultTrue = context.Messages.Where(m => m.HasRead == true).OrderByDescending(m => m.DateTime).ToList();

            //resultFalse.AddRange(resultTrue);

            //return resultFalse;

            return context.Messages.FromSqlInterpolated($"SELECT * FROM Messages ORDER bY HasRead , DateTime DESC").ToList();

        }

    }
}


