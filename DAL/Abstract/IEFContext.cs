using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core;

namespace DAL.Abstract
{
    public interface IEFContext: IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        EntityState Modified<TEntity>(TEntity entity) where TEntity : class;
        EntityState Deleted<TEntity>(TEntity entity) where TEntity : class;
    }
}
