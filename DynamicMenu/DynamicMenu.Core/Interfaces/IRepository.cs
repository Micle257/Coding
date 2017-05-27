// -----------------------------------------------------------------------
//  <copyright file="IRepository.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using JetBrains.Annotations;
    using Models;

    /// <summary> Represents the CRUD operation provide. </summary>
    /// <typeparam name="T"> The type of the entity. </typeparam>
    public interface IRepository<T> : IDisposable
        where T : BaseEntity
    {
        /// <summary> Marks specified entity, that it should be inserted into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Add([NotNull] T entity);

        /// <summary> Marks specified entity, that it should be updated into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Update([NotNull] T entity);

        /// <summary> Marks specified entity, that it should be deleted into the db context. </summary>
        /// <param name="entity"> The entity. </param>
        void Remove([NotNull] T entity);

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

        /// <summary> Commits the changes to the context. </summary>
        void Commit();
    }
}