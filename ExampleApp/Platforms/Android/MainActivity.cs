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
