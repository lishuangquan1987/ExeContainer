# ExeContainer

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg)](https://www.microsoft.com/windows)

A modern .NET library for embedding external executable applications into your Windows Forms or WPF applications. This project is based on and improved from [bitzhuwei/AppContainer](https://github.com/bitzhuwei/AppContainer).

## 🚀 Features

- **Cross-Platform Support**: Supports both .NET Framework 4.7.2 and .NET 8.0
- **Dual UI Framework Support**: Works with both Windows Forms and WPF
- **Modern Async/Await**: Built with modern C# async patterns for better performance
- **Automatic Window Management**: Handles window resizing and lifecycle automatically
- **Error Handling**: Robust error handling with detailed exception information
- **Process Lifecycle Management**: Automatically manages embedded application lifecycle

## 📋 Requirements

- Windows 10/11 or Windows Server 2016+
- .NET Framework 4.7.2 or .NET 8.0
- Visual Studio 2019+ or .NET CLI

## 🛠️ Installation

### NuGet Package (Recommended)
```bash
# For Windows Forms applications
Install-Package ExeContainer

# For WPF applications
Install-Package ExeContainer
```

### Manual Installation
1. Clone this repository
2. Build the solution
3. Reference the `ExeContainer.dll` in your project

## 📖 Quick Start

### Windows Forms Usage

1. **Add the control to your form:**
```csharp
using ExeContainer;

public partial class Form1 : Form
{
    private ExeContainerWinform exeContainer;
    
    public Form1()
    {
        InitializeComponent();
        exeContainer = new ExeContainerWinform();
        this.Controls.Add(exeContainer);
        exeContainer.Dock = DockStyle.Fill;
    }
}
```

2. **Embed an application:**
```csharp
private async void btnEmbed_Click(object sender, EventArgs e)
{
    string exePath = @"C:\Path\To\Your\Application.exe";
    bool success = await exeContainer.EmbedProcess(exePath);
    
    if (success)
    {
        MessageBox.Show("Application embedded successfully!");
    }
    else
    {
        MessageBox.Show("Failed to embed application.");
    }
}
```

### WPF Usage

1. **Add the control to your XAML:**
```xml
<Window x:Class="YourNamespace.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:execontainer="clr-namespace:ExeContainer;assembly=ExeContainer"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <execontainer:ExeContainerWpf x:Name="wpfContainer" />
    </Grid>
</Window>
```

2. **Embed an application:**
```csharp
private async void btnEmbed_Click(object sender, RoutedEventArgs e)
{
    string exePath = @"C:\Path\To\Your\Application.exe";
    bool success = await wpfContainer.EmbedProcess(exePath);
    
    if (success)
    {
        MessageBox.Show("Application embedded successfully!");
    }
    else
    {
        MessageBox.Show("Failed to embed application.");
    }
}
```

## 🔧 Advanced Usage

### Custom Window Sizing
The embedded application automatically resizes with the container, but you can also manually control the size:

```csharp
// For Windows Forms
exeContainer.Size = new Size(800, 600);

// For WPF
wpfContainer.Width = 800;
wpfContainer.Height = 600;
```

### Error Handling
```csharp
try
{
    bool success = await exeContainer.EmbedProcess(exePath);
    if (!success)
    {
        // Handle embedding failure
        Console.WriteLine("Failed to embed application");
    }
}
catch (Exception ex)
{
    // Handle exceptions
    Console.WriteLine($"Error: {ex.Message}");
}
```

## 📁 Project Structure

```
ExeContainer/
├── ExeContainer/                 # Main library
│   ├── ContainerHelper.cs       # Core embedding logic
│   ├── Win32Api.cs             # Windows API declarations
│   ├── ExeContainerWinform.cs  # Windows Forms control
│   └── ExeContainerWpf.xaml    # WPF control
├── ExeContainer.WinformDemo/    # Windows Forms demo
├── ExeContainer.WpfDemo/        # WPF demo
└── README.md
```

## 🎯 Demo Applications

The repository includes two demo applications:

- **ExeContainer.WinformDemo**: Windows Forms demonstration
- **ExeContainer.WpfDemo**: WPF demonstration

To run the demos:
1. Open the solution in Visual Studio
2. Set either demo project as the startup project
3. Build and run
4. Click "Browse" to select an executable file
5. Click "Embed" to embed the application

## 🔍 How It Works

ExeContainer uses Windows API calls to:

1. **Start the target process** with minimized window style
2. **Wait for the main window handle** to become available
3. **Set the parent window** using `SetParent` API
4. **Remove window borders** and adjust styles
5. **Resize and position** the embedded window
6. **Handle window lifecycle** automatically

## ⚠️ Limitations

- Only works on Windows platforms
- Some applications may not embed properly due to their internal window management
- Console applications cannot be embedded
- Applications with multiple main windows may behave unexpectedly
- UAC-elevated applications may require special handling

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

This project is based on the original work by [bitzhuwei/AppContainer](https://github.com/bitzhuwei/AppContainer). We've modernized the codebase with:

- Modern .NET support (.NET 8.0)
- Async/await patterns
- Better error handling
- Improved WPF support
- Enhanced documentation

## 📞 Support

If you encounter any issues or have questions, please:

1. Check the [Issues](https://github.com/yourusername/ExeContainer/issues) page
2. Create a new issue with detailed information
3. Include your .NET version and target framework

---

**Note**: This library is designed for embedding external applications into your own applications. Please ensure you have the necessary permissions and licenses to embed third-party applications. 