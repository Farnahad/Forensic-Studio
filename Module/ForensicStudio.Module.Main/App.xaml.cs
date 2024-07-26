using System;
using System.Reflection;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Control.Mvvm;
using ForensicStudio.Core.Control.Ribbon;
using ForensicStudio.Core.Control.Window;
using ForensicStudio.Module.Core;
using ForensicStudio.Module.Tool;
using ForensicStudio.Module.Windows;
using ForensicStudio.Service.Core;
using ForensicStudio.Service.Main;
using ForensicStudio.Service.Tool;
using ForensicStudio.Service.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ForensicStudio.Module.Main;

public partial class App
{
    static App()
    {
        SetTheme();
        ShowSplashScreen();
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterDialogWindow<FsDxWindow>();
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        regionAdapterMappings.RegisterMapping(typeof(FsRibbonControl),
            Container.Resolve<FsRibbonControlRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(FsAutoHideGroup),
            Container.Resolve<FsAutoHideGroupRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(FsDocumentGroup),
            Container.Resolve<FsDocumentGroupRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(FsDockLayoutGroup),
            Container.Resolve<FsDockLayoutGroupRegionAdapter>());
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        return new ConfigurationModuleCatalog();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        #region Modules

        moduleCatalog.AddModule<CoreModule>();
        moduleCatalog.AddModule<MainModule>();
        moduleCatalog.AddModule<ToolModule>();
        moduleCatalog.AddModule<WindowsModule>();

        #endregion


        #region Services

        moduleCatalog.AddModule<CoreServiceModule>();
        moduleCatalog.AddModule<MainServiceModule>();
        moduleCatalog.AddModule<ToolServiceModule>();
        moduleCatalog.AddModule<WindowsServiceModule>();

        #endregion
    }

    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();

        ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
        {
            var viewName = viewType.FullName;
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = $"{viewName}Model, {viewAssemblyName}";

            return Type.GetType(viewModelName);
        });
    }

    private static void SetTheme()
    {
        ApplicationThemeHelper.ApplicationThemeName = "Office2013DarkGray";
    }

    private static void ShowSplashScreen()
    {
        var splashScreenViewModel = new DXSplashScreenViewModel
        {
            Title = "Forensic Studio",
            IsIndeterminate = true,
            Subtitle = "Powered by Farnahad",
            Copyright = "Copyright © " + DateTime.Now.Year + " Farnahad Company.\nAll rights reserved."
        };

        SplashScreenManager.Create(() => new ForensicStudioSplashScreen
        {
        }, splashScreenViewModel).ShowOnStartup();
    }
}