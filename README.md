# HardwareSerialMonitor_v2 (LibreHardwareMonitor-Based)

[GitHub Repository](https://github.com/koogar/HardwareSerialMonitor_v2)


## Overview

**HardwareSerialMonitor_v2** is a lightweight server that uses **LibreHardwareMonitor** to send PC hardware data over a **serial port**—ideal for integration with an **Arduino** or similar microcontroller.

[LibreHardwareMonitor GitHub Repository](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor)

It is based on **Wee Hardware Stat Server**  thanks to Vinod Mishra (2021),
(https://gitlab.com/vinodmishra/wee-hardware-stat-server)

who made it compatible with GnatStas & PhatStats OLED/LCD displays by R.Hirst (https://tallmanlabs.com).

[GnatStats GitHub Repository](https://github.com/koogar/Gnat-Stats) / [PhatStats GitHub Repository](https://github.com/koogar/Phat-Stats)


The project is licensed under **GPL v2**.  
The **LibreHardwareMonitor** library is licensed under the **Mozilla Public License 2.0**.

## Hardware connection Guides

Arduino Hookup guides for GnatStats & PhatStats OLED/LCD displays can be found on https://tallmanlabs.com.

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

| Feature/Aspect              | **HardwareSerialMonitor (Original)**                                         | **HardwareSerialMonitor\_v2 (Updated)**                                                                     |
| --------------------------- | ---------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| **Base Project**            | Original app by Rupert Hirst & Colin Conway                                  | Original app by Vinod Mishra Fork/upgrade by Rupert Hirst                                                                     |
| **Tray Icon / UI**          | ✅ Has a system tray icon for easy access to settings like COM port selection | ❌ No tray icon or UI; all settings are configured manually in `appsettings.json`                            |
| **Configuration**           | Via tray icon or settings menu                                               | Only via `appsettings.json` file                                                                            |
| **Startup Options**         | Controlled via tray icon or manual                                           | Uses `.vbs` scripts for auto-start (silent or visible modes)                                                |
| **Logging**                 | Unknown/limited                                                              | Logs ticks in terminal window or runs silently                                                               |
| **Output Fields Supported** | Fewer fields                                                                 | ✅ More fields supported (added GPU/RAM stats, power readings, fan speeds, etc.)                             |
| **Format Customization**    | Basic                                                                        | ✅ Fully customizable format strings                                                                         |
| **Installation Location**   | Flexible                                                                     | Recommended in `C:\Program Files (x86)\HardwareSerialMonitor_v2` (for `.vbs` scripts to work without edits) |
| **.NET Version Required**   | Older (.NET 4.x or similar)                                                  | Requires **.NET 9 runtime**                                                                                 |
| **License**                 | GPL v2   uses OpenHardwareMonitor                                            | GPL v2 + uses LibreHardwareMonitor (MPL 2.0)                                                                |
| **Target Users**            | Beginners/hobbyists needing simple setup                                     | Intermediate users comfortable editing config files                                                         |
| **Development Status**      | No longer actively updated                                                   | Active fork with planned features                                                                           |


## ✅ **Key Improvements in v2:**

* **Expanded sensor data support:** More GPU stats, RAM stats, and fan metrics.
* **Format flexibility:** You can build a custom string output instead of a fixed format.
* **Headless/silent mode:** Can run silently at startup using provided `.vbs` scripts.
* **Cleaner architecture:** No dependencies on UI libraries for tray icon → lighter memory footprint.
* **LibreHardwareMonitor has active development for futureproofing new hardware**
* **Bluetooth Virtual Com**: Virtual Com ports are now stored and reconnect each time HardwareSerialMonitor_v2 runs.

---

## ⚠️ **Key Tradeoffs in v2:**

* ❌ No easy GUI → users must edit config files manually.
* ❌ COM port selection must be updated in `appsettings.json` if hardware/port changes.
* ❌ Less beginner-friendly for non-technical users.

---

## 💡 **When to choose which?**

| If you want…                                     | → **Use**                        |
| ------------------------------------------------ | -------------------------------- |
| Easy config through a tray icon UI               | HardwareSerialMonitor (original) |
| More output fields, flexibility, future-proofing | HardwareSerialMonitor\_v2        |
| Auto-start silent operation with no window       | HardwareSerialMonitor\_v2        |
| Minimal setup, no editing JSON manually          | HardwareSerialMonitor (original) |

---

### 📝 **In summary:**

`HardwareSerialMonitor_v2` improves **flexibility and feature set** but sacrifices **user interface convenience**. It’s better suited for users comfortable with **manual config**. The original version is better for those who prefer **GUI-based configuration** without editing files.


## Installation Notes

Unlike the original **HardwareSerialMonitor**, version 2 **does not include a system tray icon** for configuration.  
Instead, configuration is done manually via the `appsettings.json` file in the program folder.

When running:
- A **terminal window** will appear to log connection worker ticks (if not running silently).
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
- `HardwareSerialMonitor_v2.vbs` → starts with a terminal window.
- `HardwareSerialMonitor_v2Silent.vbs` → starts silently in the background.

4. ✅ Done! The program will automatically launch at startup, using the last known COM port.

**Important:**  
If you installed the program to a different folder (not `C:\Program Files (x86)\HardwareSerialMonitor_v2`), you will need to edit the `.vbs` file using Notepad and update the file paths inside the script.

---

## Notes

- **No graphical interface or tray icon**—all settings must be configured via `appsettings.json`.
- Use the `.vbs` launcher of your choice depending on whether you want a visible terminal window or silent execution.
- For displaying PC stats on an Arduino-connected display (OLED, LCD, etc.) running GnatStats or PhatStats.

---


 Licence
  -------
  
  GPL v2
  
Gnat-Stats, Phat-Stats, Tacho-Stats, uVolume & HardwareSerialMonitor 
Copyright (C) 2016  Colin Conway, Rupert Hirst and contributors
 
This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; If not, see <http://www.gnu.org/licenses/>.

---






   

