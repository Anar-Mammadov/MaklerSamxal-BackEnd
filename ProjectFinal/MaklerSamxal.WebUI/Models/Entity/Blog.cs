﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.Entity
{
    public class Blog :BaseEntity
    {

        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public  string Body { get; set; }
        public string CreatedData { get; set; }

    }
}
