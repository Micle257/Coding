// -----------------------------------------------------------------------
//  <copyright file="Repository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Interfaces;
    using Core.Models;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    /// <summary> Represents a base class for <see cref="IRepository{T}" />. </summary>
    /// <typeparam name="T"> </typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        /// <summary> The database set. </summary>
        readonly DbSet<T> _set;

        /// <summary> Initializes a new instance of the <see cref="Repository{T}" /> class. </summary>
        /// <param name="context"> The context. </param>
        public Repository([NotNull] DataContext context)
        {
            Context = context;
            _set = Context.Set<T>();
        }

        /// <summary> Gets the data context. </summary>
        /// <value> The <see cref="DataContext" />. </value>
        public DataContext Context { get; }

        /// <inheritdoc />
        public virtual void Add(T entity)
        {
            _set.Add(entity);
        }

        /// <inheritdoc />
        public virtual void Update(T entity)
        {
            _set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        /// <inheritdoc />
        public void Remove(Expression<Func<T, bool>> entitySelector)
        {
            foreach (var obj in _set.Where(entitySelector))
                _set.Remove(obj);
        }

        /// <inheritdoc />
        public T Get(Expression<Func<T, bool>> entitySelector) => _set.FirstOrDefault(entitySelector);

        /// <inheritdoc />
        public T GetById(int id) => _set.Find(id);

        /// <inheritdoc />
        public IEnumerable<T> GetAll() => _set.ToList();
    }
}