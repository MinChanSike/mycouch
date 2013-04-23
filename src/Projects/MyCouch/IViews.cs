﻿using System;
using System.Threading.Tasks;

namespace MyCouch
{
    /// <summary>
    /// Used to query and manage views.
    /// </summary>
    public interface IViews
    {
        /// <summary>
        /// Creates a query which you later can run against any number of database instaces
        /// using <see cref="RunQuery{T}"/> or <see cref="RunQueryAsync{T}"/>. The query is not
        /// tied to the current connected client.
        /// </summary>
        /// <param name="designDocument"></param>
        /// <param name="viewname"></param>
        /// <returns></returns>
        IViewQuery CreateQuery(string designDocument, string viewname);

        /// <summary>
        /// Creates a system-query, targetting builtin views of CouchDb,
        /// which you later can run against any number of database instaces
        /// using <see cref="RunQuery{T}"/> or <see cref="RunQueryAsync{T}"/>. The query is not
        /// tied to the current connected client.
        /// </summary>
        /// <param name="viewname"></param>
        /// <returns></returns>
        ISystemViewQuery CreateSystemQuery(string viewname);

        /// <summary>
        /// Lets you run an <see cref="IViewQuery"/> against the current database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ViewQueryResponse<T> RunQuery<T>(IViewQuery query) where T : class;

        /// <summary>
        /// Lets you run an <see cref="IViewQuery"/> against the current database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<T>> RunQueryAsync<T>(IViewQuery query) where T : class;

        /// <summary>
        /// Creates and executes an <see cref="IViewQuery"/> on the fly.
        /// </summary>
        /// <param name="designDocument"></param>
        /// <param name="viewname"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        ViewQueryResponse<T> Query<T>(string designDocument, string viewname, Action<IViewQueryConfigurator> configurator) where T : class;
        
        /// <summary>
        /// Creates and executes an <see cref="IViewQuery"/> on the fly.
        /// </summary>
        /// <param name="designDocument"></param>
        /// <param name="viewname"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<T>> QueryAsync<T>(string designDocument, string viewname, Action<IViewQueryConfigurator> configurator) where T : class;
    }
}