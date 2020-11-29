using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Pages.Entities;
using assignment.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment.Pages
{
    public class ArticleModel : PageModel
    {
        public List<Article> articles { get; set; }
        private ArticleRepository articleRepository { get; set; }
        public int ArticlePage { get; set; }
        public  int pageSize { get; } = 2;

        public ArticleModel()
        {
            articleRepository = new ArticleRepository();

        }
        public void OnGet()
        {
            int pageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            articles = new ArticleRepository().Get(pageIndex, pageSize);
            ArticlePage = articleRepository.ArticlesCount;
        }

    }
}
