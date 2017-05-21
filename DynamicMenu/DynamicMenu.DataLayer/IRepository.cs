// -----------------------------------------------------------------------
//  <copyright file="IRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a repository for <see cref="Menu"/> entity.
    /// </summary>
    /// <seealso cref="DynamicMenu.DataLayer.Repository{DynamicMenu.DataLayer.Menu}" />
    public class MenuRepository : Repository<Menu>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MenuRepository([NotNull] DataContext context) : base(context) { }
    }

    /// <summary>
    /// Represents a base class for <see cref="IRepository{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

    /// <summary> Represents the CRUD operation provider, which won't commit to the context. </summary>
    /// <typeparam name="T"> The type of the entity. </typeparam>
    public interface IRepository<T>
        where T : BaseEntity
    {
        /// <summary> Marks specified entity, that it should be inserted into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Add(T entity);

        /// <summary> Marks specified entity, that it should be updated into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Update(T entity);

        /// <summary> Marks specified entity, that it should be deleted into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Remove(T entity);

        /// <summary> Marks specified entity, that it should be inserted into the db context. </summary>
        /// <param name="entitySelector"> The entity selector. </param>
        void Remove(Expression<Func<T, bool>> entitySelector);

        /// <summary> Marks that entity specified by selector should be selected from the db context. </summary>
        /// <param name="entitySelector"> The entity selector. </param>
        /// <returns> An entity. </returns>
        T Get(Expression<Func<T, bool>> entitySelector);

        /// <summary> Marks that entity at specified id should be selected from the db context. </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> An entity. </returns>
        T GetById(int id);

        /// <summary> Marks that all entities should be selected from the db context. </summary>
        /// <returns> A <see cref="IEnumerable{T}" />. </returns>
        IEnumerable<T> GetAll();
    }
}