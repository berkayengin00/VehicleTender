using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace VehicleTender.DAL.CrudRepository
{
	public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class, new()
	{
		private readonly DbContext _db=null;

		/// <summary>
		/// Crud sınıfını kullanan sınıflar, DbContext tipinde bir Context göndermelidir.
		/// </summary>
		/// <param name="db"></param>
		public CrudRepository(DbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Veritabanına veri siler. HardDelete olarak ilişkili veriler de 
		/// Eğer parametre olarak save değeri verilmezse tek kaydetme olur. Transaction Uygulanmaz
		/// <param name="entity"></param>
		/// <param name="save"></param>
		/// <returns></returns>
		public virtual int Delete(TEntity entity, bool save = true)
		{
			#region HardDeleteAktif
			_db.Entry(entity).State = EntityState.Deleted;
			_db.Set<TEntity>().Remove(entity);
			return save ? Save() : 0;

			#endregion

			#region SoftDelete
			//dbSet.GetType().GetProperty("isDeleted").SetValue(entity, 0);
			//return Update(entity); 
			#endregion

		}

		/// <summary>
		/// Filtre Verilmezse bütün veriyi getirir.
		/// Eğer Filtre verilirse istenilen filtreye göre Liste döner
		/// </summary>
		/// <param name="cond"></param>
		/// <returns></returns>
		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> cond = null)
		{
			return cond == null
				? _db.Set<TEntity>().ToList()
				: _db.Set<TEntity>().Where(cond).ToList();
		}

		/// <summary>
		/// Filtreye göre 1 veri getirir. Eğer Yoksa null döner.
		/// Parametre zorunldur
		/// </summary>
		/// <param name="cond"></param>
		/// <returns></returns>
		public TEntity Get(Expression<Func<TEntity, bool>> cond)
		{
			return cond == null
				? _db.Set<TEntity>().Find(cond)
				: _db.Set<TEntity>().Where(cond).SingleOrDefault();
		}

		/// <summary>
		/// Veritabanına veri ekler.
		/// Eğer parametre olarak save değeri verilmezse tek kaydetme olur. Transaction Uygulanmaz
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="save"></param>
		/// <returns></returns>
		public int Insert(TEntity entity, bool save = true)
		{
			_db.Entry(entity).State = EntityState.Added;
			_db.Set<TEntity>().Add(entity);
			return save ? Save() : 0;
		}

		/// <summary>
		/// Veri tabanında veri günceller geriye etkilenen satır sayısını döner
		/// Eğer parametre olarak save değeri verilmezse tek kaydetme olur. Transaction Uygulanmaz
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="save"></param>
		/// <returns></returns>
		public int Update(TEntity entity, bool save = true)
		{
			_db.Entry(entity).State = EntityState.Modified;
			_db.Set<TEntity>().Attach(entity);
			return save ? Save() : 0;
		}

		/// <summary>
		/// Veritabanına verilerin kaydedildiği metod.
		/// Geriye satır sayısı döner
		/// </summary>
		/// <returns></returns>
		public int Save()
		{
			return _db.SaveChanges();
		}

		/// <summary>
		/// Transaction ile kaydet uygulanır
		/// Bu metodu kullanmak için diğer metodlara parametre olarak save=false verilmelidir
		/// En son olarak bu metod çağırılmalıdır.
		/// </summary>
		public void SaveWithTransaction()
		{
			//using (TransactionScope transaction = new TransactionScope())
			//{
			//	try
			//	{
			//		Save();
			//		transaction.Complete();
			//	}
			//	catch (Exception ex)
			//	{
			//		transaction.Dispose();
			//		throw ex;
			//	}
			//}
		}

		/// <summary>
		/// Veritabanına loglama yapılmak istenirse içerisi doldurulmalıdır.
		/// </summary>
		private void Log()
		{
			//_db.Database.Log = Console.Write;
		}
		/// <summary>
		/// Parametre Olarak VerilenTipe göre ilgili tablonun verilerini getirir.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="express"></param>
		/// <returns></returns>
		public List<TResult> Select<TResult>(Func<TEntity,TResult> express)
		{
			return _db.Set<TEntity>().Select(express).ToList();
		}
	}
}
