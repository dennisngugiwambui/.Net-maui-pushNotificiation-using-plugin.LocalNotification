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
