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
        public int pageSize { get; } = 2;
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public IndexModel()
        {
            articleRepository = new ArticleRepository();

        }
        public void OnGet()
        {
            PageIndex = 1;
            if (RouteData.Values.ContainsKey("pid"))
            {
                PageIndex = Convert.ToInt32(RouteData.Values["pid"]);
            }
            articles = new ArticleRepository().Get(PageIndex, pageSize);
            PageCount = articleRepository.ArticlesCount / pageSize;
        }

    }
}
