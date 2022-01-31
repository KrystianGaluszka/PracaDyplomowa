using System;
using System.Collections.Generic;

namespace Basketball_Manager_Db.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserModel User { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsRead { get; set; }
        public string IconPath { get; set; }
    }  
}
