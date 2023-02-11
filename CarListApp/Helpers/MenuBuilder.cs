using CarListApp.Controls;
using CarListApp.Models;

namespace CarListApp.Helpers
{
    public static class MenuBuilder
    {
        public static async Task BuildMenu(UserInfo userInfo)
        {
            Shell.Current.Items.Clear();
            Shell.Current.FlyoutHeader = new FlyoutHeader();

            foreach (var role in userInfo.Roles.Distinct())
            {
                if (role.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
                {
                    var item = new FlyoutItem()
                    {
                        Title = "Car Management",
                        Route = nameof(MainPage),
                        FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems
                    };
                }

                if (role.Equals("User", StringComparison.OrdinalIgnoreCase))
                {
                    var item = new FlyoutItem()
                    {
                        Title = "Car Management",
                        Route = nameof(MainPage),
                        FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems
                    };
                }
            }
        }
    }
}
