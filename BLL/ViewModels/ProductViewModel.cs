using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
  public  class AddCategoryProdViewModel
    {
        public string Name { get; set; }
        public bool Published { get; set; }
    }

   

    public class CategoryItemProdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
