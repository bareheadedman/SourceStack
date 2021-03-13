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

            //一级
            yuyan = register("编程开发语言", 1);
            gongju = register("工具软件", 1);
            caozuo = register("操作系统", 1);


            // 二级关键字 
            java = register("Java", 2);
            java.UpLevel = yuyan;
            js = register("JavaScript", 2);
            js.UpLevel = yuyan;
            sql = register("SQL", 2);
            sql.UpLevel = yuyan;

            cad = register("CAD", 2);
            cad.UpLevel = gongju;
            word = register("Word", 2);
            word.UpLevel = gongju;
            vs = register("VisualStudio", 2);
            vs.UpLevel = gongju;


            windows = register("Windows", 2);
            windows.UpLevel = caozuo;
            unix = register("Unix", 2);
            unix.UpLevel = caozuo;
            android = register("Android", 2);
            android.UpLevel = caozuo;


            Helper.GetDbContext().SaveChanges();

        }


        private static Keyword register(string name, int level)
        {
            Keyword keyword = new Keyword
            {
                Name = name,
                Level = level,
                CreateTime = DateTime.Now

            };
            KeywordRepository keywordRepository = new KeywordRepository(Helper.GetDbContext());
            keywordRepository.Save(keyword);
            return keyword;
        }


    }
}
