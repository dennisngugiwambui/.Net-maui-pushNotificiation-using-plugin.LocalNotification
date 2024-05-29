
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


## Usage
# Sending a Notification
To send a notification, use the following code in your application:



## Additional Configuration
# Android-Specific Configuration
For Android, you might need additional configuration in the AndroidManifest.xml file to ensure notifications work correctly.

Add the following permissions: 
(Click all the permisions to ensure the your application runs without any permission error)


Go to MainActivity.cs and add the code as follows

```
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Plugin.LocalNotification;

namespace ExampleApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Request necessary permissions at runtime
            CheckPermissions();

            // Manually create notification channel for Android 8.0 and above
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel("default", "Default Channel", NotificationImportance.Default)
                {
                    Description = "Default Channel for Notifications"
                };
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        private void CheckPermissions()
        {
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReceiveBootCompleted) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.ReceiveBootCompleted }, 0);
            }
        }
    }
}

```

