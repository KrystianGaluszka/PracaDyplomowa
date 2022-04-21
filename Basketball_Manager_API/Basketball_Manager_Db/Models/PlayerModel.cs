using Basketball_Manager_Db.SwaggerConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basketball_Manager_Db.Models
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public PlayerRarity Rarity{ get; set; }
        public int Level { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string PicturePath { get; set; }
        public virtual IEnumerable<UsersPlayerModel> UsersPlayers { get; set; }
    }

    public enum PlayerRarity 
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Masterwork,
        Legendary
    }
}