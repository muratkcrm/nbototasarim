﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.DbModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Aciklama { get; set; }
        public string Category { get; set; }
    }
}
