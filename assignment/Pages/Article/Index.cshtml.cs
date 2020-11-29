using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E = assignment.Pages.Entities;
namespace assignment.Pages.Article
{
    public class IndexModel : PageModel
    {
        public List<E.Article> articles { get; set; }
        private ArticleRepository articleRepository { get; set; }
        public int ArticlePage { get; set; }
        public int pageSize { get; } = 2;
        public int PageIndex { get; set; }
        public IndexModel()
        {
            articleRepository = new ArticleRepository();

        }
        public void OnGet()
        {
            PageIndex = 1;
            if (Request.Query.ContainsKey("pageIndex"))
            {
                PageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);

            }
            articles = new ArticleRepository().Get(PageIndex, pageSize);
            ArticlePage = articleRepository.ArticlesCount;
        }

    }
}
