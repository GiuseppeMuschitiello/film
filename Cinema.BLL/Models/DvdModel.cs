using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Models
{
    public class DvdModel
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public string? Director { get; set; }
    }
}
