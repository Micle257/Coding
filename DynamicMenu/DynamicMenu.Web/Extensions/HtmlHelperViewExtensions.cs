// -----------------------------------------------------------------------
//  <copyright file="HtmlHelperViewExtensions.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web.Extensions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Internal;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Routing;

    /// <summary>
    /// Contains extension methods for <see cref="IHtmlHelper" />.
    /// </summary>
    public static class HtmlHelperViewExtensions
    {
        /// <summary>
        /// Performs controller's action in razor html view.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        /// <returns>
        /// A <see cref="IHtmlContent"/>.
        /// </returns>
        public static IHtmlContent RenderAction([NotNull] this IHtmlHelper helper, [NotNull] string action, [NotNull] string controller)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
            
           var area = (string) helper.ViewContext?.RouteData?.Values?["area"];

            var task = RenderActionAsync(helper, action, controller, area);

            return task.Result;
        }

        /// <summary>
        /// Performs controller's action in razor html view asynchronously.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="area">The area.</param>
        /// <returns>
        /// An awaitable <see cref="IHtmlContent"/>.
        /// </returns>
        static async Task<IHtmlContent> RenderActionAsync(this IHtmlHelper helper, string action, string controller, string area)
        {
            // fetching required services for invocation
            var currentHttpContext = helper.ViewContext?.HttpContext;
            var httpContextFactory = GetServiceOrFail<IHttpContextFactory>(currentHttpContext);
            var actionInvokerFactory = GetServiceOrFail<IActionInvokerFactory>(currentHttpContext);
            var actionSelector = GetServiceOrFail<IActionSelectorDecisionTreeProvider>(currentHttpContext);

            // creating new action invocation context
            var routeData = new RouteData();
            var routeValues = new RouteValueDictionary(new {area, controller, action});
            var newHttpContext = httpContextFactory.Create(currentHttpContext.Features);

            newHttpContext.Response.Body = new MemoryStream();

            foreach (var router in helper.ViewContext.RouteData.Routers)
                routeData.PushState(router, null, null);

            routeData.PushState(null, routeValues, null);
            routeData.PushState(null, new RouteValueDictionary(new { }), null);

            var actionDescriptor = actionSelector.DecisionTree.Select(routeValues).First();
            var actionContext = new ActionContext(newHttpContext, routeData, actionDescriptor);

            // invoke action and retreive the response body
            var invoker = actionInvokerFactory.CreateInvoker(actionContext);
            string content = null;

            await invoker.InvokeAsync().ContinueWith(task =>
                                                     {
                                                         if (task.IsFaulted)
                                                             content = task.Exception.Message;
                                                         else if (task.IsCompleted)
                                                         {
                                                             newHttpContext.Response.Body.Position = 0;
                                                             using (var reader = new StreamReader(newHttpContext.Response.Body))
                                                             {
                                                                 content = reader.ReadToEnd();
                                                             }
                                                         }
                                                     }).ConfigureAwait(false);

            return new HtmlString(content);
        }

        /// <summary>
        /// Gets the desired service from http context.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>
        /// A <see cref="TService"/>.
        /// </returns>
        static TService GetServiceOrFail<TService>(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            var service = httpContext.RequestServices?.GetService(typeof(TService));

            if (service == null)
                throw new InvalidOperationException($"Could not locate service: {nameof(TService)}");

            return (TService) service;
        }
    }
}