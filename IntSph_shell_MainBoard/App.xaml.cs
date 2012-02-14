using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace IntSph_shell_MainBoard
{
    /// <summary>
    /// Application class - Main Entry Point of SilverLight Instance
    ///   - Entry Point for Initialization work framewotk Prism 4.0
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialization of SilverLight Application
        /// </summary>
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        /// <summary>
        /// Entry Point : Startup - Code When apllication starting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {           
            var bootstrapper = new IsBootstrapper();
            bootstrapper.Run(true);
        }

        /// <summary>
        /// Exit Point: Exit -  Code When application closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Exception Point: Throw Unhadled Exception Point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        /// <summary>
        /// Exception Point: Create A web page with text of Error. 
        /// </summary>
        /// <param name="e"></param>
        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
