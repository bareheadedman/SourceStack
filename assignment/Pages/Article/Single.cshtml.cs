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
    public class SingleModel : PageModel
    {
        private ArticleRepository articleRepository { get; set; }
        public SingleModel()
        {
            articleRepository = new ArticleRepository();
        }

        public E.Article Article { get; set; }
        private int id { get; set; }


        public void OnGet()
        {

            id = Convert.ToInt32(RouteData.Values["id"]);

            Article = articleRepository.Find(id);
            Article.keyWords = new KeyWordRepository().FindsArticle(Article.Id);
            Article.Author = new UserRepository().Find(Article.Author.Id);
        }
        public void OnPost()
        {

        }
    }
}
