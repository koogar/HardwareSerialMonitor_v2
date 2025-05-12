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



## Notes

- **No graphical interface or tray icon**—all settings must be configured via `appsettings.json`.
- Use the `.vbs` launcher of your choice depending on whether you want a visible terminal window or silent execution.
- For displaying PC stats on an Arduino-connected display (OLED, LCD, etc.) running GnatStats or PhatStats https://tallmanlabs.com.

## Hardware connection Guides

Arduino Hookup guides for GnatStats & PhatStats OLED/LCD displays can be found on https://tallmanlabs.com.


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

**Important:**  
If you installed the program to a different folder (not `C:\Program Files (x86)\HardwareSerialMonitor_v2`), you will need to edit the `.vbs` file using Notepad and update the file paths inside the script.

---

