using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharp
{
    class Student
    {
        public int Id { get; set; }

        
        [Required]
        public string Name { get; set; }
        
        public int Age { get; set; }
        public string BeForm { get; set; }

    }
}
