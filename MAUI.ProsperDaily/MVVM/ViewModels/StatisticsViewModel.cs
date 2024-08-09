using MAUI.ProsperDaily.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace MAUI.ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary>? Summary { get; set; }
        public ObservableCollection<Transaction>? SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionsRepo?.GetItems();
            var result = new List<TransactionsSummary>();
            var groupedTransactions = data!.GroupBy(x => x.OperationDate);

            if (groupedTransactions.Count() == 0) return;

            foreach (var group in groupedTransactions)
            {
                var transactionSummary = new TransactionsSummary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
                    ShownDate = group.Key.ToString("MM/dd")
                };
                result.Add(transactionSummary);
            }

            result = result.OrderBy(x => x.TransactionsDate).ToList();
            Summary = new ObservableCollection<TransactionsSummary>(result);

            var spendingList = data?.Where(x => !x.IsIncome).ToList();

            SpendingList = new ObservableCollection<Transaction>(spendingList!);
        }
    }
}
