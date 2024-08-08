using MAUI.ProsperDaily.MVVM.Views;

namespace MAUI.ProsperDaily
{
    public partial class App : Application
    {
        public App()
        {
            if (Application.Current != null)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                this.RequestedThemeChanged += (s, e) =>
                {
                    Application.Current.UserAppTheme = AppTheme.Light;
                };
            }

            InitializeComponent();

            //MainPage = new DashboardPage();
            MainPage = new TransactionsPage();
            //MainPage = new StatisticsPage();
        }
    }
}
