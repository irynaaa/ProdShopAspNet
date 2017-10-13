using Autofac;
using BLL.Abstract;
using DAL.Abstract;
using DAL.Concreate;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concreate
{
   public class DataModel: Module
    {
        private string _connStr;
        public DataModel(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this._connStr))
                .As<IEFContext>().InstancePerRequest();
            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>().InstancePerRequest();
            builder.RegisterType<ProductProvider>()
               .As<IProductProvider>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
