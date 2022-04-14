using System;

namespace Basketball_Manager_Db.Models
{
    public class ExpensesModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public string ItemName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Count { get; set; }
        public string Value { get; set; }
        public string IconPath { get; set; }
    }
}
