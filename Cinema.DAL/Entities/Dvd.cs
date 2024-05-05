﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Entities
{
    public class Dvd
    {
        
        public int Id {  get; set; }
        public required string? Name { get; set; }
        public string? Director { get; set; }
    }
}
