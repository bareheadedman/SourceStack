using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{

    public class SelectedUserModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int InvitedById { get; set; }
        public IList<RegisterModel> SelectedUsers { get; set; }
    }
}
