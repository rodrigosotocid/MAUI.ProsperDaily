using MAUI.ProsperDaily.MVVM.Models;
using MAUI.ProsperDaily.MVVM.Views;
using MAUI.ProsperDaily.Repositories;

namespace MAUI.ProsperDaily
{
    public partial class App : Application
    {
        public static BaseRepository<Transaction>? TransactionsRepo { get; private set; }

        public App(BaseRepository<Transaction>? transactionsRepo)
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

            TransactionsRepo = transactionsRepo;

            MainPage = new NavigationPage(new DashboardPage());
        }
    }
}
