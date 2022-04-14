using System.Collections.Generic;

namespace Basketball_Manager_Db.DeleteModels
{
    public class QuickSellDeleteModel
    {
        public IEnumerable<int> UserPlayerIds { get; set; }
        public string UserId { get; set; }
    }
}
