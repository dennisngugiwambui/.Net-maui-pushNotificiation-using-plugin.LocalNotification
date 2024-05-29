
## README for Adding Notifications in Android using .NET MAUI

# Introduction
This guide provides step-by-step instructions to add notifications to an Android application using .NET MAUI. The process involves installing the Plugin.LocalNotification package and initializing it in your project.

# Prerequisites
Ensure you have the following installed:

   o .NET 6.0 or later
   
   o Visual Studio 2022 (with .NET MAUI workload installed)


   ## Installation
To add notifications to your Android application, you need to install the Plugin.LocalNotification package.

# Using NuGet Package Manager

1. Open your solution in Visual Studio.
2. Right-click on the solution in the Solution Explorer.
3. Select "Manage NuGet Packages for Solution..."
4. Search for Plugin.LocalNotification.
5. Install the latest version of the package.

# Using Package Manager Console

Alternatively, you can install the package using the Package Manager Console:

`Install-Package Plugin.LocalNotification`


# Initialization
After installing the package, initialize it in the MauiProgram.cs file.

# Open MauiProgram.cs.
Add the initialization code to the CreateMauiApp method.

`.UseLocalNotification()`

The updated code for MauiProgram.cs should be:

```
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace ExampleApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            //LocalNotificationCenter.CreateNotificationChannel();
            //LocalNotificationCenter.Current.Initialize();

            return builder.Build();
        }
    }
}

```
