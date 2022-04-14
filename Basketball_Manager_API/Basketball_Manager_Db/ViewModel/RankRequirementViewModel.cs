namespace Basketball_Manager_Db.ViewModel
{
    public class RankRequirementViewModel
    {
        public int Id { get; set; }
        public string RankName { get; set; }
        public int PointsRequired { get; set; }
        public int PointsLimit { get; set; }
        public string IconPath { get; set; }
    }
}
