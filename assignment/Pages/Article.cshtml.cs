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
        public List<Article> articles;

        public ArticleModel()
        {
            articles = new ArticleRepository().Get();

        }
        public void OnGet()
        {

        }

    }
}
