using System;

namespace Basketball_Manager_Db.ViewModel
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string IconPath { get; set; }
        public bool IsRead { get; set; }
    }
}
