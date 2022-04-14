namespace Basketball_Manager_Db.ViewModel
{
    public class BackgroundTaskViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? User2Id { get; set; }
        public string JobId { get; set; }
        public string TaskName { get; set; }
        public bool IsStarted { get; set; }
    }
}
