using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Display
{
    public class GetAllCategories
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
