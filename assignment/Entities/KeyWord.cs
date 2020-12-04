﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Entities
{
    public class KeyWord : Entity
    {
        public string Content { get; set; }
        public List<Article> ByEmploys { get; set; }
    }
}
