using MAUI.ProsperDaily.MVVM.Models;

namespace MAUI.ProsperDaily.MVVM.ViewModels
{
    public class TransactionsViewModel
    {
        public Transaction Transaction { get; set; } = new Transaction
        {
            OperationDate = DateTime.Now
        };

        public string? SaveTransaction()
        {
            if (App.TransactionsRepo != null)
            {
                App.TransactionsRepo.SaveItem(Transaction);
                return App.TransactionsRepo.StatusMessage;
            }
            return null;
        }
    }
}
