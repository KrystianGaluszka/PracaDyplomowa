using System.Collections.Generic;

namespace Basketball_Manager_Db.PutModels
{
    public class UpdateTrainingPutModel
    {
        public string UserId { get; set; }
        public IEnumerable<UserPlayerOptions> UserPlayersOption { get; set; }
    }

    public class UserPlayerOptions
    {
        public int UserPlayerId { get; set; }
        public string TrainingType { get; set; }
    }
}
