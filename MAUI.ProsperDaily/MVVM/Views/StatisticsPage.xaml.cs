using MAUI.ProsperDaily.MVVM.ViewModels;

namespace MAUI.ProsperDaily.MVVM.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
		BindingContext = new StatisticsViewModel();
	}

    override protected void OnAppearing()
    {
        base.OnAppearing();
        var vm = (StatisticsViewModel)BindingContext;
        vm.GetTransactionsSummary();
    }
}