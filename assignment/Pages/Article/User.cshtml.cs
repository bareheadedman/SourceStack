using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Entities;
using E = assignment.Entities;
using assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment.Pages.Article
{
    public class UserModel : PageModel
    {
        private static UserRepository userRepository;
        private static CategoryRepository categoryRepository;
        public UserModel()
        {
            userRepository = new UserRepository();
            categoryRepository = new CategoryRepository();
        }


        public User User { get; set; }
        public int Id { get; set; }


        public void OnGet()
        {

            Id = 1005;
            if (RouteData.Values.ContainsKey("id"))
            {
                Id = Convert.ToInt32(RouteData.Values["id"]);
            }
            User = userRepository.Find(Id);
            User.Categorys = categoryRepository.Find(Id);

            User.Articles = new ArticleRepository().FindAuthorId(User.Id);

            foreach (var item in User.Articles)
            {
                item.keyWords = new KeyWordRepository().FindsArticle(item.Id);
                item.Author = new UserRepository().Find(item.Author.Id);
            }

        }
        public void OnPost()
        {

        }

    }
}
