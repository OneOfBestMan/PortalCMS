using Portal.CMS.Web.Architecture.DependencyResolution;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(InitialiseDependencyResolution), "Start")]
[assembly: ApplicationShutdownMethod(typeof(InitialiseDependencyResolution), "End")]

namespace Portal.CMS.Web.Architecture.DependencyResolution
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Portal.CMS.Web.DependencyResolution;
    using System.Web.Mvc;

    public static class InitialiseDependencyResolution
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion Public Properties

        #region Public Methods and Operators

        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        public static void Start()
        {
            var container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion Public Methods and Operators
    }
}