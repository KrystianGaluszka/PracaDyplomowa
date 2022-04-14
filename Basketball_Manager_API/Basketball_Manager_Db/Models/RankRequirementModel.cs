namespace Basketball_Manager_Db.Models
{
    public class RankRequirementModel
    {
        public int Id { get; set; }
        public string RankName { get; set; }
        public int PointsRequired { get; set; }
        public int PointsLimit { get; set; }
        public string IconPath { get; set; }
    }
}
