using System;

namespace Basketball_Manager_Db.PostModels
{
    public class NotificationPostModel
    {
        public string UserId { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreateDate{ get; set; }
        public string IconPath { get; set; }

    }
}
