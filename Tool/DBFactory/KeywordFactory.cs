using BLL.Entities;
using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    class KeywordFactory
    {
        //一级关键字
        internal static Keyword yuyan;
        internal static Keyword gongju;
        internal static Keyword caozuo;

        // 二级关键字 
        internal static Keyword java;
        internal static Keyword js;
        internal static Keyword sql;

        internal static Keyword cad;
        internal static Keyword word;
        internal static Keyword vs;

        internal static Keyword windows;
        internal static Keyword unix;
        internal static Keyword android;



        public static void Create()
        {


            // 二级关键字 
            java = register("Java", 2);
            js = register("JavaScript", 2);
            sql = register("SQL", 2);

            cad = register("CAD", 2);
            word = register("Word", 2);
            vs = register("VisualStudio", 2);

            windows = register("Windows", 2);
            unix = register("Unix", 2);
            android = register("Android", 2);





            //一级
            yuyan = register("编程开发语言", 1);

            yuyan.DownLevels = new List<Keyword>();
            yuyan.DownLevels.Add(java);
            yuyan.DownLevels.Add(js);
            yuyan.DownLevels.Add(sql);


            gongju = register("工具软件", 1);
            gongju.DownLevels = new List<Keyword>();
            gongju.DownLevels.Add(cad);
            gongju.DownLevels.Add(word);
            gongju.DownLevels.Add(vs);


            caozuo = register("操作系统", 1);
            caozuo.DownLevels = new List<Keyword>();
            caozuo.DownLevels.Add(windows);
            caozuo.DownLevels.Add(unix);
            caozuo.DownLevels.Add(android);


            save(caozuo);

        }


        private static Keyword register(string name, int level)
        {
            Keyword keyword = new Keyword
            {
                Name = name,
                Level = level,
                CreateTime = DateTime.Now

            };
            save(keyword);
            return keyword;
        }


        private static void save(Keyword keyword)
        {
            KeywordRepository keywordRepository = new KeywordRepository(Helper.GetDbContext());
            keywordRepository.Save(keyword);
        }



    }
}
