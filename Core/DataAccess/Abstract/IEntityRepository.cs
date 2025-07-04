﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
	public interface IEntityRepository<TEntity> where TEntity : class
	{
		List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
		TEntity Get(Expression<Func<TEntity, bool>> filter);
		TEntity Add(TEntity entity);
		TEntity Update(TEntity entity);
		TEntity Delete(TEntity entity);
	}
}
