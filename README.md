# HardwareSerialMonitor_v2 (LibreHardwareMonitor-Based)

[GitHub Repository](https://github.com/koogar/HardwareSerialMonitor_v2)

## Overview

**HardwareSerialMonitor_v2** is a lightweight server that uses **LibreHardwareMonitor** to send PC hardware data over a **serial port**—ideal for integration with an **Arduino** or similar microcontroller.

It is based on **Wee Hardware Stat Server** (compatible with **Gnat-Stats** and **Phat-Stats**) by Vinod Mishra (2021). (https://gitlab.com/vinodmishra/wee-hardware-stat-server)

The project is licensed under **GPL v2**.  
The **LibreHardwareMonitor** library is licensed under the **Mozilla Public License 2.0**.

---

## Supported Fields for Custom Format

You can customize the output format using the following fields:

| CPU Fields        | GPU Fields            | RAM Fields      |
|-------------------|-----------------------|-----------------|
| `CpuName`         | `GpuName`             | `RamLoad`       |
| `CpuTemperature`  | `GpuTemperature`      | `RamUsed`       |
| `CpuLoad`         | `GpuLoad`             | `RamAvailable`  |
| `CpuClock`        | `GpuCoreClock`        |                 |
|                   | `GpuMemoryClock`      |                 |
|                   | `GpuShaderClock`      |                 |
|                   | `GpuMemoryTotal`      |                 |
|                   | `GpuFanSpeedLoad`     |                 |
|                   | `GpuFanSpeedRpm`      |                 |
|                   | `GpuMemoryLoad`       |                 |
|                   | `GpuPower`            |                 |
|                   | `GpuMemoryUsed`       |                 |

---

## Installation Notes

Unlike the original **HardwareSerialMonitor**, version 2 **does not include a system tray icon** for configuration.  
Instead, configuration is done manually via the `appsettings.json` file in the program folder.

When running:
- A **command window** will appear to log connection ticks (if not running silently).
- Or it runs **silently in the background** (depending on how you launch it).

---

## Installation Steps

1. ✅ **Install .NET 9 Runtime**  
   Download and install from:  
   [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)

2. ✅ **Configure the COM Port**
   - Open `appsettings.json` (using Notepad or any text editor).
   - Set the `COM` port to match your Arduino’s port.
   - ⚠️ *Note: If you connect your Arduino to a different USB port later, the COM port may change—you’ll need to update `appsettings.json` again.*

3. ✅ **Run as Administrator**
   - Right-click `HardwareSerialMonitor_v2.exe`.
   - Go to **Properties → Compatibility**.
   - Check **“Run this program as administrator”**.

---

## Auto-Start on Windows

To have **HardwareSerialMonitor_v2** start automatically when Windows boots:

1. Install the program to:
   C:\Program Files (x86)\HardwareSerialMonitor_v2 
*(If you install elsewhere, you will need to manually edit the script paths—see step 4.)*

2. Navigate to the Windows **Startup folder**:    
Open File Explorer and paste:
%AppData%\Microsoft\Windows\Start Menu\Programs\Startup

3. Copy one of the `.vbs` files from the program’s `AutoRunOnWindowsStartup` folder into the Startup folder:
- `HardwareSerialMonitor_v2.vbs` → starts with a command window.
- `HardwareSerialMonitor_v2Silent.vbs` → starts silently in the background.

4. ✅ Done! The program will automatically launch at startup, using the last known COM port.

**Important:**  
If you installed the program to a different folder (not `C:\Program Files (x86)\HardwareSerialMonitor_v2`), you will need to edit the `.vbs` file using Notepad and update the file paths inside the script.

---

## Notes

- **No graphical interface or tray icon**—all settings must be configured via `appsettings.json`.
- Use the `.vbs` launcher of your choice depending on whether you want a visible command window or silent execution.
- For displaying PC stats on an Arduino-connected display (OLED, LCD, etc.) running GnatStats or PhatStats.

---




   

