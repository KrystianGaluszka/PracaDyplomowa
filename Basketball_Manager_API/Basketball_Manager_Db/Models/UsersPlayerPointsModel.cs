namespace Basketball_Manager_Db.Models
{
    public class UsersPlayerPointsModel
    {
        public int Id { get; set; }
        public int UserPlayerId { get; set; }
        public virtual UsersPlayerModel UsersPlayer { get; set; }
        public int OnePoints { get; set; }
        public int TwoPoints { get; set; }
        public int ThreePoints { get; set; }
        public int AllOnePoints { get; set; }
        public int AllTwoPoints { get; set; }
        public int AllThreePoints { get; set; }

    }
}
