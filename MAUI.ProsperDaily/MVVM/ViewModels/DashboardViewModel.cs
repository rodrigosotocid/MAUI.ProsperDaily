using MAUI.ProsperDaily.MVVM.Models;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace MAUI.ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DashboardViewModel
    {
        public ObservableCollection<Transaction>? Transactions { get; set; }
        public decimal Balance { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }

        public DashboardViewModel()
        {
            FillData();
        }

        public void FillData()
        {
            var transactions = App.TransactionsRepo?.GetItems();
            transactions = [.. transactions!.OrderByDescending(x => x.OperationDate)];
            //transactions = transactions!.OrderByDescending(x => x.OperationDate).ToList();

            if (transactions.Any())
            {
                Transactions = new ObservableCollection<Transaction>(transactions!);

                Balance = 0;
                Income = 0;
                Expenses = 0;

                foreach (var transaction in Transactions)
                {
                    if (transaction.IsIncome)
                        Income += transaction.Amount;
                    else
                        Expenses += transaction.Amount;
                }
                Balance = Income - Expenses;
            }
        }
    }
}
