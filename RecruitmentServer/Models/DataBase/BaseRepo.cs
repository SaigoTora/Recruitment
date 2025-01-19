using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Base;

namespace RecruitmentServer.Models.DataBase
{
	internal class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase
	{
		protected RecruitmentEntities Context => _db;

		private readonly DbSet<T> _table;
		private readonly RecruitmentEntities _db;

		internal BaseRepo(RecruitmentEntities context)
		{
			_db = context;
			_table = _db.Set<T>();
		}

		public int Add(T entity)
		{
			_table.Add(entity);
			return SaveChanges();
		}
		public int AddRange(IList<T> entities)
		{
			_table.AddRange(entities);
			return SaveChanges();
		}

		public int Save(T entity)
		{
			_db.Entry(entity).State = EntityState.Modified;
			return SaveChanges();
		}
		internal int SaveChanges()
		{
			try
			{
				return _db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				// Thrown when there is a concurrency error
				// for now, just rethrow the exception
				throw;
			}
			catch (DbUpdateException ex)
			{
				// Thrown when database update fails
				// Examine the inner exception(s) for additional 
				// details and affected objects
				// for now, just rethrow the exception
				throw;
			}
			catch (CommitFailedException ex)
			{
				// Handle transaction failures here
				// for now, just rethrow the exception
				throw;
			}
			catch (Exception ex)
			{
				// Some other exception happened and should be handled
				throw;
			}
		}

		public int Delete(int id)
		{
			_db.Entry(new EntityBase(id)).State
				= EntityState.Deleted;
			return SaveChanges();
		}
		public int Delete(T entity)
		{
			_db.Entry(entity).State = EntityState.Deleted;
			return SaveChanges();
		}

		public T GetOne(int? id) => _table.Find(id);
		public virtual List<T> GetAll() => _table.ToList();

		public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();
		public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
			=> _table.SqlQuery(sql, sqlParametersObjects).ToList();

		public void Dispose() => _db?.Dispose();
	}
}