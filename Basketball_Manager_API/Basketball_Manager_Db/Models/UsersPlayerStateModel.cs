namespace Basketball_Manager_Db.Models
{
    public class UsersPlayerStateModel
    {
        public int Id { get; set; }
        public int UserPlayerId { get; set; }
        public virtual UsersPlayerModel UsersPlayer { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsOnAuction { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsOnBench { get; set; }
        public bool IsInjured { get; set; }
        public bool IsBoosted { get; set; }
    }
}
