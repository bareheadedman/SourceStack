using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp
{
    class Major
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public Teacher Teacher { get; set; }
    }
}
