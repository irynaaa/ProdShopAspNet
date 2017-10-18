using DAL.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class AddProductViewModel
    {
        public IEnumerable<SelectItemViewModel> Categories { get; set; }
        public int Id { get; set; }

        [Display(Name = "Name of product")]
        [Required, StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        [Display(Name = "Created:")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Modefied:")]
        public DateTime ModefiedDate { get; set; }

        [Required(ErrorMessage = "Chose category!")]
        [Display(Name = "Name of category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }

    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name of product")]
        [Required, StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        [Display(Name = "Created:")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Modefied:")]
        public DateTime ModefiedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }

    public  class AddCategoryProdViewModel
    {
        public string Name { get; set; }
        public bool Published { get; set; }
    }

   

    public class CategoryItemProdViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required! Can't be empty!")]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string Name { get; set; }
            [Display(Name = "Is Published?")]
            public bool Published { get; set; }

        public CategoryItemProdViewModel()
        {

        }

        public CategoryItemProdViewModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Published = category.Published;
        }
    }

    

}
