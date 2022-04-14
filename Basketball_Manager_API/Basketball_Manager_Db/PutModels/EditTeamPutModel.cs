using Basketball_Manager_Db.Models;
using System.Collections.Generic;

namespace Basketball_Manager_Db.PutModels
{
    public class EditTeamPutModel
    {
        public IEnumerable<int> SquadIds{ get; set; }
        public IEnumerable<int> BenchIds { get; set; }
        public IEnumerable<int> RestPlayersIds { get; set; }
        public string CaptainId { get; set; }
    }
}
