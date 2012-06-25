    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using AppScan;
    using AppScan.Scan;
    using AppScan.Events;
    using AppScan.Extensions;
    using AppScan.Scan.Events;
    using O2.DotNetWrappers.ExtensionMethods;
    using O2.XRules.Database.Utils;

    namespace O2.APIs
    {
        public class O2_AppScan_Standard_PlugIn : IExtensionLogic
        {
            public static IAppScan      AppScan          { get; set; }
            public static IAppScanGui   AppScanGui       { get; set; }
            public static string        ExtensionDir    { get; set; }

            public void Load (IAppScan appscan, IAppScanGui appScanGui, string extensionDir)
            {            
                "AppScan ExtensionDir: {0}".info(extensionDir);
            
                AppScan = appscan;                        
                AppScanGui = appScanGui;
                ExtensionDir = extensionDir;
                addO2MenuItems();
            }

            public void addO2MenuItems()
            {
                var menuItem_LogViewer= new AppScan.Extensions.MenuItem<EventArgs>("O2 LogViewer", (sender)=> "O2 LogViewer".popupWindow().add_LogViewer());            
                AppScanGui.ExtensionsMenu.Add(menuItem_LogViewer);

                var menuItem_ScriptEditor = new AppScan.Extensions.MenuItem<EventArgs>("O2 C# REPL Editor", (sender)=> ascx_Panel_With_Inspector.runControl());            
                AppScanGui.ExtensionsMenu.Add(menuItem_ScriptEditor);                        
            }
            
            public ExtensionVersionInfo GetUpdateData(Edition targetApp, Version targetAppVersion)
            {
                    return null;
            }
          }

    }