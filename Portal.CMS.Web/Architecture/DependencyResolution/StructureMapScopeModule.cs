namespace Portal.CMS.Web.DependencyResolution
{
    using Portal.CMS.Web.Architecture.DependencyResolution;
    using StructureMap.Web.Pipeline;
    using System.Web;

    public class StructureMapScopeModule : IHttpModule
    {
        #region Public Methods and Operators

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => InitialiseDependencyResolution.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                InitialiseDependencyResolution.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }

        #endregion Public Methods and Operators
    }
}