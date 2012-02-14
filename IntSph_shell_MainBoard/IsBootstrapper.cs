using System;
using System.Windows;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace IntSph_shell_MainBoard
{
    /// <summary>
    /// StartUp Prism FrameWork: MEF Dependency Injections 
    /// </summary>
    public class IsBootstrapper : MefBootstrapper
    {
        /// <summary>
        /// Configurate First XAP: Aggregate Catalogs - Path for seaching the Additionals Assembleys (DLLs)
        ///    - Add Defult paths for needed DLLs: Own Dlls - Default path 
        /// </summary>
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(IsBootstrapper).Assembly));
        }

        /// <summary>
        /// Configurate Prism Framework Modules: Structures
        ///   - Initial Modules: Log, Authentication and Others... 
        /// </summary>
        /// <returns>
        ///   IModuleCatalog - List of ModuleInfo classes. It's stored Module Description and Order of load.
        /// </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return base.CreateModuleCatalog();
        }
     
        protected override void ConfigureModuleCatalog()
        {

        }
        
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainShell>();
        }

        protected override void InitializeShell()
        {
#if SILVERLIGHT
            Application.Current.RootVisual = (MainShell)this.Shell;
#else
            Application.Current.MainWindow = (MainShell)this.Shell;
            Application.Current.MainWindow.Show();

#endif
        }
    }
}
