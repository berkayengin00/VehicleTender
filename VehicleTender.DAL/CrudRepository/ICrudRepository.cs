using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.DAL.CrudRepository
{
	public interface ICrudRepository<TEntity> where TEntity : class, new()
	{
		TEntity Get(Expression<Func<TEntity, bool>> cond);
		List<TEntity> GetAll(Expression<Func<TEntity, bool>> cond = null);
		int Insert(TEntity entity, bool save = true);
		int Update(TEntity entity, bool save = true);
		int Delete(TEntity entity, bool save = true);
	}
}
