// -----------------------------------------------------------------------
//  <copyright file="IRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Entities;

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