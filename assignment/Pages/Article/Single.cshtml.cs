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
    public class SingleModel : PageModel
    {
        private ArticleRepository articleRepository { get; set; }
        public E.Article article { get; set; }
        private int id { get; set; }
        public SingleModel()
        {
            articleRepository = new ArticleRepository();
        }
        public void OnGet()
        {

            id = Convert.ToInt32(RouteData.Values["aid"]);

            article = articleRepository.Find(id);
        }
        public void OnPost()
        {

        }
    }
}
