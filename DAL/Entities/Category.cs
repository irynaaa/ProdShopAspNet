using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(maximumLength:255)]
        public string Name { get; set; }

        [Display(Name="Is it published?")]
        public bool Published { get; set; }
    }
}
