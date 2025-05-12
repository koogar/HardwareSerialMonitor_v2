using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibreHardwareMonitor.Hardware;
using HardwareSerialMonitor_v2.Models;
using HardwareSerialMonitor_v2.Services;
using HardwareSerialMonitor_v2.Services.Interfaces;
using HardwareSerialMonitor_v2;

public class TrayApp : Form
{
    private NotifyIcon trayIcon;
    private ContextMenu trayMenu;
    private IHost _host;

    public TrayApp()
    {
        // Tray icon setup
        trayMenu = new ContextMenu();
        trayMenu.MenuItems.Add("Exit", OnExit);
        trayIcon = new NotifyIcon
        {
            Text = "Hardware Serial Monitor",
            Icon = new Icon("icon.ico"),
            ContextMenu = trayMenu,
            Visible = true
        };

        // Form minimized and hidden
        this.WindowState = FormWindowState.Minimized;
        this.ShowInTaskbar = false;

        // Start the host in background
        Task.Run(StartHostAsync);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.Hide();
    }

    private async Task StartHostAsync()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, configApp) => { }) // Add command line args if needed
            .ConfigureServices((hostContext, services) =>
            {
                // Service registration from original Program.cs
                services.AddHostedService<Worker>();
                services.AddSingleton(GetConfigSection<OutputSettings>(hostContext.Configuration));
                services.AddSingleton(GetConfigSection<SerialPortSettings>(hostContext.Configuration));
                services.AddSingleton<IVisitor, UpdateVisitor>();
                services.AddSingleton<IHardwareMonitorService, LibreHardwareMonitorService>();
                services.AddSingleton<IHWiNFOHardwareMonitorService, HWiNFOHardwareMonitorService>();
                services.AddSingleton<ISerialPortService, SerialPortService>();

                var computer = new Computer
                {
                    IsCpuEnabled = true,
                    IsGpuEnabled = true,
                    IsMemoryEnabled = true,
                    IsMotherboardEnabled = true,
                    IsControllerEnabled = true,
                    IsNetworkEnabled = true,
                    IsStorageEnabled = true
                };
                computer.Open();
                services.AddSingleton<IComputer>(computer);
            })
            .Build();

        await _host.RunAsync();
    }

    private static T GetConfigSection<T>(IConfiguration configuration, string name = null) where T : new()
    {
        var configSection = new T();
        configuration.GetSection(name ?? configSection.GetType().Name).Bind(configSection);
        return configSection;
    }

    private void OnExit(object sender, EventArgs e)
    {
        trayIcon.Visible = false;
        Application.Exit();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            trayIcon?.Dispose();
            _host?.StopAsync().Wait();
        }
        base.Dispose(disposing);
    }
}
