using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModefiedDate { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
