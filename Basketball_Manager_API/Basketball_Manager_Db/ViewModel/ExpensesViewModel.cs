using System;

namespace Basketball_Manager_Db.ViewModel
{
    public class ExpensesViewModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Count { get; set; }
        public string Value { get; set; }
        public string IconPath { get; set; }
    }
}
