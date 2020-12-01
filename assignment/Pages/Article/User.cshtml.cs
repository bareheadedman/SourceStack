using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Pages.Entities;
using E=assignment.Pages.Entities;
using assignment.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment.Pages.Article
{
    public class UserModel : PageModel
    {
        public User user { get; set; }
        private static UserRepository userRepository { get; set; }
        private static CategoryRepository categoryRepository { get; set; }
        public int pageSize { get; } = 2;
        public int PageIndex { get; set; }
        public int PageCount { get; set; }


        public int Id { get; set; }
        static UserModel()
        {
            userRepository = new UserRepository();
            categoryRepository = new CategoryRepository();
        }

        public void OnGet()
        {
            PageIndex = 1;
            if (RouteData.Values.ContainsKey("pid"))
            {
                PageIndex = Convert.ToInt32(RouteData.Values["pid"]);
            }
            Id = Convert.ToInt32(RouteData.Values["uid"]);
            user = userRepository.Find(Id);
            user.Categorys = categoryRepository.Find(Id);
            PageCount = user.Articles.Count();
            
        }
        public void OnPost()
        {
            
        }


    }
}
