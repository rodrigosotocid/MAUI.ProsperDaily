using MAUI.ProsperDaily.Abstractions;

namespace MAUI.ProsperDaily.MVVM.Models
{
    public class Transaction : TableData
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
