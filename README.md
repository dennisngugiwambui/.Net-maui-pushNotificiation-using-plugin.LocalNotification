
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

The backened code should be implemented this way(Example the MainPage.xaml.cs)

```
using Plugin.LocalNotification;

namespace ExampleApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            NotificationStatusLabel.Text = "Attempting to schedule notification...";

            try
            {
                var request = new NotificationRequest
                {
                    NotificationId = 1337,
                    Title = "MEDIUM",
                    Subtitle = "Hello! I'm Erdal",
                    Description = "Local Push Notification",
                    BadgeNumber = 1,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(3),
                    }
                };

                LocalNotificationCenter.Current.Show(request);
                NotificationStatusLabel.Text = "Notification scheduled successfully";
            }
            catch (Exception ex)
            {
                NotificationStatusLabel.Text = $"Error scheduling notification: {ex.Message}";
            }
        }
    }
}
```

The button to trigger the notification should be (Example MainPage.xaml)

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ExampleApp.MainPage">

    <ScrollView>
        <VerticalStackLayout
            Padding="30,0"
            Spacing="25">
            <Image
                Source="dotnet_bot.png"
                HeightRequest="185"
                Aspect="AspectFit"
                SemanticProperties.Description="dot net bot in a race car number eight" />

            <Label
                Text="Hello, World!"
                Style="{StaticResource Headline}"
                SemanticProperties.HeadingLevel="Level1" />

            <Label
                Text="Welcome to &#10;.NET Multi-platform App UI"
                Style="{StaticResource SubHeadline}"
                SemanticProperties.HeadingLevel="Level2"
                SemanticProperties.Description="Welcome to dot net Multi platform App U I" />

            <Button
                x:Name="CounterBtn"
                Text="Click me" 
                SemanticProperties.Hint="Counts the number of times you click"
                Clicked="OnCounterClicked"
                HorizontalOptions="Fill" />

            <!-- Label to display the notification status -->
            <Label x:Name="NotificationStatusLabel" Text="" TextColor="Green" />
        </VerticalStackLayout>
    </ScrollView>
</ContentPage>
```

## Additional Configuration
# Android-Specific Configuration
For Android, you might need additional configuration in the AndroidManifest.xml file to ensure notifications work correctly.

Add the following permissions: 
(Click all the permisions to ensure the your application runs without any permission error)

Open AndroidManifest in edit mode and copy this code:

```
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android">
	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	<uses-permission android:name="android.permission.INTERNET" />
	<uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />
	<uses-permission android:name="android.permission.ACCEPT_HANDOVER" />
	<uses-permission android:name="android.permission.ACCESS_BACKGROUND_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_BLOBS_ACROSS_USERS" />
	<uses-permission android:name="android.permission.ACCESS_CHECKIN_PROPERTIES" />
	<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_LOCATION_EXTRA_COMMANDS" />
	<uses-permission android:name="android.permission.ACCESS_MEDIA_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_MOCK_LOCATION" />
	<uses-permission android:name="android.permission.ACCESS_NOTIFICATION_POLICY" />
	<uses-permission android:name="android.permission.ACCESS_SURFACE_FLINGER" />
	<uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
	<uses-permission android:name="android.permission.ACCOUNT_MANAGER" />
	<uses-permission android:name="android.permission.ACTIVITY_RECOGNITION" />
	<uses-permission android:name="com.android.voicemail.permission.ADD_VOICEMAIL" />
	<uses-permission android:name="android.permission.ANSWER_PHONE_CALLS" />
	<uses-permission android:name="android.permission.AUTHENTICATE_ACCOUNTS" />
	<uses-permission android:name="android.permission.BATTERY_STATS" />
	<uses-permission android:name="android.permission.BIND_ACCESSIBILITY_SERVICE" />
	<uses-permission android:name="android.permission.BIND_APPWIDGET" />
	<uses-permission android:name="android.permission.BIND_AUTOFILL_SERVICE" />
	<uses-permission android:name="android.permission.BIND_CARRIER_MESSAGING_CLIENT_SERVICE" />
	<uses-permission android:name="android.permission.BIND_CARRIER_MESSAGING_SERVICE" />
	<uses-permission android:name="android.permission.BIND_CARRIER_SERVICES" />
	<uses-permission android:name="android.permission.BIND_CHOOSER_TARGET_SERVICE" />
	<uses-permission android:name="android.permission.BIND_COMPANION_DEVICE_SERVICE" />
	<uses-permission android:name="android.permission.BIND_CONDITION_PROVIDER_SERVICE" />
	<uses-permission android:name="android.permission.BIND_CONTROLS" />
	<uses-permission android:name="android.permission.BIND_CREDENTIAL_PROVIDER_SERVICE" />
	<uses-permission android:name="android.permission.BIND_DEVICE_ADMIN" />
	<uses-permission android:name="android.permission.BIND_DREAM_SERVICE" />
	<uses-permission android:name="android.permission.BIND_INCALL_SERVICE" />
	<uses-permission android:name="android.permission.BIND_INPUT_METHOD" />
	<uses-permission android:name="android.permission.BIND_MIDI_DEVICE_SERVICE" />
	<uses-permission android:name="android.permission.BIND_NFC_SERVICE" />
	<uses-permission android:name="android.permission.BIND_NOTIFICATION_LISTENER_SERVICE" />
	<uses-permission android:name="android.permission.BIND_PRINT_SERVICE" />
	<uses-permission android:name="android.permission.BIND_QUICK_ACCESS_WALLET_SERVICE" />
	<uses-permission android:name="android.permission.BIND_QUICK_SETTINGS_TILE" />
	<uses-permission android:name="android.permission.BIND_REMOTEVIEWS" />
	<uses-permission android:name="android.permission.BIND_SCREENING_SERVICE" />
	<uses-permission android:name="android.permission.BIND_TELECOM_CONNECTION_SERVICE" />
	<uses-permission android:name="android.permission.BIND_TEXT_SERVICE" />
	<uses-permission android:name="android.permission.BIND_TV_INPUT" />
	<uses-permission android:name="android.permission.BIND_TV_INTERACTIVE_APP" />
	<uses-permission android:name="android.permission.BIND_VISUAL_VOICEMAIL_SERVICE" />
	<uses-permission android:name="android.permission.BIND_VOICE_INTERACTION" />
	<uses-permission android:name="android.permission.BIND_VPN_SERVICE" />
	<uses-permission android:name="android.permission.BIND_VR_LISTENER_SERVICE" />
	<uses-permission android:name="android.permission.BIND_WALLPAPER" />
	<uses-permission android:name="android.permission.BLUETOOTH" />
	<uses-permission android:name="android.permission.BLUETOOTH_ADMIN" />
	<uses-permission android:name="android.permission.BLUETOOTH_ADVERTISE" />
	<uses-permission android:name="android.permission.BLUETOOTH_CONNECT" />
	<uses-permission android:name="android.permission.BLUETOOTH_PRIVILEGED" />
	<uses-permission android:name="android.permission.BLUETOOTH_SCAN" />
	<uses-permission android:name="android.permission.BODY_SENSORS" />
	<uses-permission android:name="android.permission.BODY_SENSORS_BACKGROUND" />
	<uses-permission android:name="android.permission.BRICK" />
	<uses-permission android:name="android.permission.BROADCAST_PACKAGE_REMOVED" />
	<uses-permission android:name="android.permission.BROADCAST_SMS" />
	<uses-permission android:name="android.permission.BROADCAST_STICKY" />
	<uses-permission android:name="android.permission.BROADCAST_WAP_PUSH" />
	<uses-permission android:name="android.permission.CALL_COMPANION_APP" />
	<uses-permission android:name="android.permission.CALL_PHONE" />
	<uses-permission android:name="android.permission.CALL_PRIVILEGED" />
	<uses-permission android:name="android.permission.CAMERA" />
	<uses-permission android:name="android.permission.CAPTURE_AUDIO_OUTPUT" />
	<uses-permission android:name="android.permission.CAPTURE_SECURE_VIDEO_OUTPUT" />
	<uses-permission android:name="android.permission.CAPTURE_VIDEO_OUTPUT" />
	<uses-permission android:name="android.permission.CHANGE_COMPONENT_ENABLED_STATE" />
	<uses-permission android:name="android.permission.CHANGE_CONFIGURATION" />
	<uses-permission android:name="android.permission.CHANGE_NETWORK_STATE" />
	<uses-permission android:name="android.permission.CHANGE_WIFI_MULTICAST_STATE" />
	<uses-permission android:name="android.permission.CHANGE_WIFI_STATE" />
	<uses-permission android:name="android.permission.CLEAR_APP_CACHE" />
	<uses-permission android:name="android.permission.CLEAR_APP_USER_DATA" />
	<uses-permission android:name="android.permission.CONFIGURE_WIFI_DISPLAY" />
	<uses-permission android:name="android.permission.CONTROL_LOCATION_UPDATES" />
	<uses-permission android:name="android.permission.CREDENTIAL_MANAGER_QUERY_CANDIDATE_CREDENTIALS" />
	<uses-permission android:name="android.permission.CREDENTIAL_MANAGER_SET_ALLOWED_PROVIDERS" />
	<uses-permission android:name="android.permission.CREDENTIAL_MANAGER_SET_ORIGIN" />
	<uses-permission android:name="android.permission.DELETE_CACHE_FILES" />
	<uses-permission android:name="android.permission.DELETE_PACKAGES" />
	<uses-permission android:name="android.permission.DELIVER_COMPANION_MESSAGES" />
	<uses-permission android:name="android.permission.DETECT_SCREEN_CAPTURE" />
	<uses-permission android:name="android.permission.DEVICE_POWER" />
	<uses-permission android:name="android.permission.DIAGNOSTIC" />
	<uses-permission android:name="android.permission.DISABLE_KEYGUARD" />
	<uses-permission android:name="android.permission.DUMP" />
	<uses-permission android:name="android.permission.ENFORCE_UPDATE_OWNERSHIP" />
	<uses-permission android:name="android.permission.EXECUTE_APP_ACTION" />
	<uses-permission android:name="android.permission.EXPAND_STATUS_BAR" />
	<uses-permission android:name="android.permission.FACTORY_TEST" />
	<uses-permission android:name="android.permission.FLASHLIGHT" />
	<uses-permission android:name="android.permission.FORCE_BACK" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_CAMERA" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_CONNECTED_DEVICE" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_DATA_SYNC" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_HEALTH" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_LOCATION" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_MEDIA_PLAYBACK" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_MEDIA_PROJECTION" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_MICROPHONE" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_PHONE_CALL" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_REMOTE_MESSAGING" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_SPECIAL_USE" />
	<uses-permission android:name="android.permission.FOREGROUND_SERVICE_SYSTEM_EXEMPTED" />
	<uses-permission android:name="android.permission.GET_ACCOUNTS" />
	<uses-permission android:name="android.permission.GET_ACCOUNTS_PRIVILEGED" />
	<uses-permission android:name="android.permission.GET_PACKAGE_SIZE" />
	<uses-permission android:name="android.permission.GET_TASKS" />
	<uses-permission android:name="android.permission.GET_TOP_ACTIVITY_INFO" />
	<uses-permission android:name="android.permission.GLOBAL_SEARCH" />
	<uses-permission android:name="android.permission.HARDWARE_TEST" />
	<uses-permission android:name="android.permission.HIDE_OVERLAY_WINDOWS" />
	<uses-permission android:name="android.permission.HIGH_SAMPLING_RATE_SENSORS" />
	<uses-permission android:name="android.permission.INJECT_EVENTS" />
	<uses-permission android:name="android.permission.INSTALL_LOCATION_PROVIDER" />
	<uses-permission android:name="android.permission.INSTALL_PACKAGES" />
	<uses-permission android:name="com.android.launcher.permission.INSTALL_SHORTCUT" />
	<uses-permission android:name="android.permission.INSTANT_APP_FOREGROUND_SERVICE" />
	<uses-permission android:name="android.permission.INTERACT_ACROSS_PROFILES" />
	<uses-permission android:name="android.permission.INTERNAL_SYSTEM_WINDOW" />
	<uses-permission android:name="android.permission.KILL_BACKGROUND_PROCESSES" />
	<uses-permission android:name="android.permission.LAUNCH_CAPTURE_CONTENT_ACTIVITY_FOR_NOTE" />
	<uses-permission android:name="android.permission.LAUNCH_MULTI_PANE_SETTINGS_DEEP_LINK" />
	<uses-permission android:name="android.permission.LOADER_USAGE_STATS" />
	<uses-permission android:name="android.permission.LOCATION_HARDWARE" />
	<uses-permission android:name="android.permission.MANAGE_ACCOUNTS" />
	<uses-permission android:name="android.permission.MANAGE_APP_TOKENS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_LOCK_STATE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ACCESSIBILITY" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ACCOUNT_MANAGEMENT" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ACROSS_USERS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ACROSS_USERS_FULL" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ACROSS_USERS_SECURITY_CRITICAL" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_AIRPLANE_MODE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_APPS_CONTROL" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_APP_RESTRICTIONS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_APP_USER_DATA" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_AUDIO_OUTPUT" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_AUTOFILL" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_BACKUP_SERVICE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_BLUETOOTH" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_BUGREPORT" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_CALLS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_CAMERA" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_CERTIFICATES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_COMMON_CRITERIA_MODE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_DEBUGGING_FEATURES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_DEFAULT_SMS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_DEVICE_IDENTIFIERS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_DISPLAY" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_FACTORY_RESET" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_FUN" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_INPUT_METHODS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_INSTALL_UNKNOWN_SOURCES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_KEEP_UNINSTALLED_PACKAGES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_KEYGUARD" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_LOCALE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_LOCATION" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_LOCK" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_LOCK_CREDENTIALS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_LOCK_TASK" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_METERED_DATA" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_MICROPHONE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_MOBILE_NETWORK" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_MODIFY_USERS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_MTE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_NEARBY_COMMUNICATION" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_NETWORK_LOGGING" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_ORGANIZATION_IDENTITY" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_OVERRIDE_APN" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PACKAGE_STATE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PHYSICAL_MEDIA" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PRINTING" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PRIVATE_DNS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PROFILES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PROFILE_INTERACTION" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_PROXY" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_QUERY_SYSTEM_UPDATES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_RESET_PASSWORD" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_RESTRICT_PRIVATE_DNS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_RUNTIME_PERMISSIONS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_RUN_IN_BACKGROUND" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SAFE_BOOT" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SCREEN_CAPTURE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SCREEN_CONTENT" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SECURITY_LOGGING" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SETTINGS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SMS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_STATUS_BAR" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SUPPORT_MESSAGE" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SUSPEND_PERSONAL_APPS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SYSTEM_APPS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SYSTEM_DIALOGS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_SYSTEM_UPDATES" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_TIME" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_USB_DATA_SIGNALLING" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_USB_FILE_TRANSFER" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_USERS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_VPN" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_WALLPAPER" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_WIFI" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_WINDOWS" />
	<uses-permission android:name="android.permission.MANAGE_DEVICE_POLICY_WIPE_DATA" />
	<uses-permission android:name="android.permission.MANAGE_DOCUMENTS" />
	<uses-permission android:name="android.permission.MANAGE_EXTERNAL_STORAGE" />
	<uses-permission android:name="android.permission.MANAGE_MEDIA" />
	<uses-permission android:name="android.permission.MANAGE_ONGOING_CALLS" />
	<uses-permission android:name="android.permission.MANAGE_OWN_CALLS" />
	<uses-permission android:name="android.permission.MANAGE_WIFI_INTERFACES" />
	<uses-permission android:name="android.permission.MANAGE_WIFI_NETWORK_SELECTION" />
	<uses-permission android:name="android.permission.MASTER_CLEAR" />
	<uses-permission android:name="android.permission.MEDIA_CONTENT_CONTROL" />
	<uses-permission android:name="android.permission.MODIFY_AUDIO_SETTINGS" />
	<uses-permission android:name="android.permission.MODIFY_PHONE_STATE" />
	<uses-permission android:name="android.permission.MOUNT_FORMAT_FILESYSTEMS" />
	<uses-permission android:name="android.permission.MOUNT_UNMOUNT_FILESYSTEMS" />
	<uses-permission android:name="android.permission.NEARBY_WIFI_DEVICES" />
	<uses-permission android:name="android.permission.NFC" />
	<uses-permission android:name="android.permission.NFC_PREFERRED_PAYMENT_INFO" />
	<uses-permission android:name="android.permission.NFC_TRANSACTION_EVENT" />
	<uses-permission android:name="android.permission.OVERRIDE_WIFI_CONFIG" />
	<uses-permission android:name="android.permission.PACKAGE_USAGE_STATS" />
	<uses-permission android:name="android.permission.PERSISTENT_ACTIVITY" />
	<uses-permission android:name="android.permission.POST_NOTIFICATIONS" />
	<uses-permission android:name="android.permission.PROCESS_OUTGOING_CALLS" />
	<uses-permission android:name="android.permission.PROVIDE_OWN_AUTOFILL_SUGGESTIONS" />
	<uses-permission android:name="android.permission.PROVIDE_REMOTE_CREDENTIALS" />
	<uses-permission android:name="android.permission.QUERY_ALL_PACKAGES" />
	<uses-permission android:name="android.permission.READ_ASSISTANT_APP_SEARCH_DATA" />
	<uses-permission android:name="android.permission.READ_BASIC_PHONE_STATE" />
	<uses-permission android:name="android.permission.READ_CALENDAR" />
	<uses-permission android:name="android.permission.READ_CALL_LOG" />
	<uses-permission android:name="android.permission.READ_CONTACTS" />
	<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
	<uses-permission android:name="android.permission.READ_FRAME_BUFFER" />
	<uses-permission android:name="com.android.browser.permission.READ_HISTORY_BOOKMARKS" />
	<uses-permission android:name="android.permission.READ_HOME_APP_SEARCH_DATA" />
	<uses-permission android:name="android.permission.READ_INPUT_STATE" />
	<uses-permission android:name="android.permission.READ_LOGS" />
	<uses-permission android:name="android.permission.READ_MEDIA_AUDIO" />
	<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
	<uses-permission android:name="android.permission.READ_MEDIA_VIDEO" />
	<uses-permission android:name="android.permission.READ_MEDIA_VISUAL_USER_SELECTED" />
	<uses-permission android:name="android.permission.READ_NEARBY_STREAMING_POLICY" />
	<uses-permission android:name="android.permission.READ_PHONE_NUMBERS" />
	<uses-permission android:name="android.permission.READ_PHONE_STATE" />
	<uses-permission android:name="android.permission.READ_PRECISE_PHONE_STATE" />
	<uses-permission android:name="android.permission.READ_PROFILE" />
	<uses-permission android:name="android.permission.READ_SMS" />
	<uses-permission android:name="android.permission.READ_SOCIAL_STREAM" />
	<uses-permission android:name="android.permission.READ_SYNC_SETTINGS" />
	<uses-permission android:name="android.permission.READ_SYNC_STATS" />
	<uses-permission android:name="android.permission.READ_USER_DICTIONARY" />
	<uses-permission android:name="com.android.voicemail.permission.READ_VOICEMAIL" />
	<uses-permission android:name="android.permission.REBOOT" />
	<uses-permission android:name="android.permission.RECEIVE_MMS" />
	<uses-permission android:name="android.permission.RECEIVE_SMS" />
	<uses-permission android:name="android.permission.RECEIVE_WAP_PUSH" />
	<uses-permission android:name="android.permission.RECORD_AUDIO" />
	<uses-permission android:name="android.permission.REORDER_TASKS" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_APP_STREAMING" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_AUTOMOTIVE_PROJECTION" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_COMPUTER" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_GLASSES" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_NEARBY_DEVICE_STREAMING" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_PROFILE_WATCH" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_RUN_IN_BACKGROUND" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_SELF_MANAGED" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_START_FOREGROUND_SERVICES_FROM_BACKGROUND" />
	<uses-permission android:name="android.permission.REQUEST_COMPANION_USE_DATA_IN_BACKGROUND" />
	<uses-permission android:name="android.permission.REQUEST_DELETE_PACKAGES" />
	<uses-permission android:name="android.permission.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS" />
	<uses-permission android:name="android.permission.REQUEST_INSTALL_PACKAGES" />
	<uses-permission android:name="android.permission.REQUEST_OBSERVE_COMPANION_DEVICE_PRESENCE" />
	<uses-permission android:name="android.permission.REQUEST_PASSWORD_COMPLEXITY" />
	<uses-permission android:name="android.permission.RESTART_PACKAGES" />
	<uses-permission android:name="android.permission.RUN_USER_INITIATED_JOBS" />
	<uses-permission android:name="android.permission.SCHEDULE_EXACT_ALARM" />
	<uses-permission android:name="android.permission.SEND_RESPOND_VIA_MESSAGE" />
	<uses-permission android:name="android.permission.SEND_SMS" />
	<uses-permission android:name="android.permission.SET_ACTIVITY_WATCHER" />
	<uses-permission android:name="com.android.alarm.permission.SET_ALARM" />
	<uses-permission android:name="android.permission.SET_ALWAYS_FINISH" />
	<uses-permission android:name="android.permission.SET_ANIMATION_SCALE" />
	<uses-permission android:name="android.permission.SET_DEBUG_APP" />
	<uses-permission android:name="android.permission.SET_ORIENTATION" />
	<uses-permission android:name="android.permission.SET_POINTER_SPEED" />
	<uses-permission android:name="android.permission.SET_PREFERRED_APPLICATIONS" />
	<uses-permission android:name="android.permission.SET_PROCESS_LIMIT" />
	<uses-permission android:name="android.permission.SET_TIME" />
	<uses-permission android:name="android.permission.SET_TIME_ZONE" />
	<uses-permission android:name="android.permission.SET_WALLPAPER" />
	<uses-permission android:name="android.permission.SET_WALLPAPER_HINTS" />
	<uses-permission android:name="android.permission.SIGNAL_PERSISTENT_PROCESSES" />
	<uses-permission android:name="android.permission.SMS_FINANCIAL_TRANSACTIONS" />
	<uses-permission android:name="android.permission.START_FOREGROUND_SERVICES_FROM_BACKGROUND" />
	<uses-permission android:name="android.permission.START_VIEW_APP_FEATURES" />
	<uses-permission android:name="android.permission.START_VIEW_PERMISSION_USAGE" />
	<uses-permission android:name="android.permission.STATUS_BAR" />
	<uses-permission android:name="android.permission.SUBSCRIBED_FEEDS_READ" />
	<uses-permission android:name="android.permission.SUBSCRIBED_FEEDS_WRITE" />
	<uses-permission android:name="android.permission.SUBSCRIBE_TO_KEYGUARD_LOCKED_STATE" />
	<uses-permission android:name="android.permission.SYSTEM_ALERT_WINDOW" />
	<uses-permission android:name="android.permission.TRANSMIT_IR" />
	<uses-permission android:name="android.permission.TURN_SCREEN_ON" />
	<uses-permission android:name="com.android.launcher.permission.UNINSTALL_SHORTCUT" />
	<uses-permission android:name="android.permission.UPDATE_DEVICE_STATS" />
	<uses-permission android:name="android.permission.UPDATE_PACKAGES_WITHOUT_USER_ACTION" />
	<uses-permission android:name="android.permission.USE_BIOMETRIC" />
	<uses-permission android:name="android.permission.USE_CREDENTIALS" />
	<uses-permission android:name="android.permission.USE_EXACT_ALARM" />
	<uses-permission android:name="android.permission.USE_FINGERPRINT" />
	<uses-permission android:name="android.permission.USE_FULL_SCREEN_INTENT" />
	<uses-permission android:name="android.permission.USE_ICC_AUTH_WITH_DEVICE_IDENTIFIER" />
	<uses-permission android:name="android.permission.USE_SIP" />
	<uses-permission android:name="android.permission.UWB_RANGING" />
	<uses-permission android:name="android.permission.VIBRATE" />
	<uses-permission android:name="android.permission.WAKE_LOCK" />
	<uses-permission android:name="android.permission.WRITE_APN_SETTINGS" />
	<uses-permission android:name="android.permission.WRITE_CALENDAR" />
	<uses-permission android:name="android.permission.WRITE_CALL_LOG" />
	<uses-permission android:name="android.permission.WRITE_CONTACTS" />
	<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
	<uses-permission android:name="android.permission.WRITE_GSERVICES" />
	<uses-permission android:name="com.android.browser.permission.WRITE_HISTORY_BOOKMARKS" />
	<uses-permission android:name="android.permission.WRITE_PROFILE" />
	<uses-permission android:name="android.permission.WRITE_SECURE_SETTINGS" />
	<uses-permission android:name="android.permission.WRITE_SETTINGS" />
	<uses-permission android:name="android.permission.WRITE_SMS" />
	<uses-permission android:name="android.permission.WRITE_SOCIAL_STREAM" />
	<uses-permission android:name="android.permission.WRITE_SYNC_SETTINGS" />
	<uses-permission android:name="android.permission.WRITE_USER_DICTIONARY" />
	<uses-permission android:name="com.android.voicemail.permission.WRITE_VOICEMAIL" />
	<application android:allowBackup="true" android:icon="@mipmap/appicon" android:supportsRtl="true">
		<!-- Receiver to handle scheduled notifications -->
		<receiver android:name="com.plugin.localnotification.LocalNotificationCenter" android:exported="true" android:enabled="true">
			<intent-filter>
				<action android:name="android.intent.action.BOOT_COMPLETED" />
			</intent-filter>
		</receiver>
		<!-- Additional application components can be added here -->
	</application>
	<uses-sdk />
</manifest>
```


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

Example Screenshot


![image](https://github.com/dennisngugiwambui/.Net-maui-pushNotificiation-using-plugin.LocalNotification/assets/112067611/393a7870-c002-4de9-ae0a-aa51c488b9d0)


