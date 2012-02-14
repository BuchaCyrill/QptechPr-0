using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace IntSph_shell_MainBoard
{
    /// <summary>
    /// Main application shell(Main Regions Layout) 
    /// </summary>
 
    [Export]
    public partial class MainShell : UserControl, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// ModuleManager - Imported from App Bootstrapper: Structure of all Modules 
        /// </summary>
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;
        
        /// <summary>
        /// RegionManager - Imported from App Bootstrapper: Structure of All Regions
        /// </summary>
        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;
        
        /// <summary>
        /// Initialization of MainShell
        /// </summary>
        public MainShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnImportsSatisfied - run after all Imports Satisfied
        /// </summary>
        public void OnImportsSatisfied()
        {
            //throw new NotImplementedException();
        }
    }
}
