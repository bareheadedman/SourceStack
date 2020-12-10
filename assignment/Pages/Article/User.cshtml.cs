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
        public User user { get; set; }
        private static UserRepository userRepository { get; set; }
        private static CategoryRepository categoryRepository { get; set; }



        public int Id { get; set; }
        static UserModel()
        {
            userRepository = new UserRepository();
            categoryRepository = new CategoryRepository();
        }

        public void OnGet()
        {

            Id = 1005;
            if (RouteData.Values.ContainsKey("id"))
            {
                Id = Convert.ToInt32(RouteData.Values["id"]);
            }
            user = userRepository.Find(Id);
            user.Categorys = categoryRepository.Find(Id);


            for (int i = 0; i < user.Articles.Count; i++)
            {
                user.Articles[i] = new ArticleRepository().Find(user.Articles[i].Id);
            }

        }
        public void OnPost()
        {

        }

    }
}
