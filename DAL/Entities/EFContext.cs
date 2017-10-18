using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EFContext: DbContext, IEFContext
    {
        public EFContext():base("ShopConnection")
        {
            Database.SetInitializer<EFContext>(null);
        }
        public EFContext(string connString):base (connString)
        {
            Database.SetInitializer<EFContext>(new DBInitializer());
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public EntityState Modified<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Modified;
            return EntityState.Modified;
        }

        public EntityState Deleted<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry(entity).State = EntityState.Deleted;
            return EntityState.Deleted;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity:class
        {
            return base.Set<TEntity>();
        }

        //public System.Data.Entity.DbSet<BLL.ViewModels.ProductViewModel> ProductViewModels { get; set; }

        //public System.Data.Entity.DbSet<BLL.ViewModels.ProductViewModel> ProductViewModels { get; set; }

        // public System.Data.Entity.DbSet<BLL.ViewModels.ProductViewModel> ProductViewModels { get; set; }
    }
}
