using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E = assignment.Entities;

namespace assignment.Pages.Article
{
    public class IndexModel : PageModel
    {
        private ArticleRepository articleRepository;

        public IndexModel()
        {
            articleRepository = new ArticleRepository();
        }

        public List<E.Article> Articles { get; set; }
        public int pageSize { get; } = 2;
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int ArticlesCount { get; set; }

        public void OnGet()
        {
            PageIndex = 1;
            if (RouteData.Values.ContainsKey("id"))
            {
                PageIndex = Convert.ToInt32(RouteData.Values["id"]);
            }
            Articles = articleRepository.Get(PageIndex, pageSize);
            ArticlesCount = articleRepository.ArticlesCount();

            if (ArticlesCount % pageSize == 0)
            {
                PageCount = ArticlesCount / pageSize;
            }
            else
            {
                PageCount = ArticlesCount / pageSize + 1;
            }

            foreach (var item in Articles)
            {
                item.keyWords = new KeyWordRepository().FindsArticle(item.Id);
                item.Author = new UserRepository().Find(item.Author.Id);
            }

        }

    }
}
