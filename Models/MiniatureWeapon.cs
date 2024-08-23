using Army_Creator_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Army_Creator_App.Models
{
    public class MiniatureWeapon
    {
        [Key]
        public int MiniatureId { get; set; }
        public Miniature Miniature { get; set; }

        [Key]
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}
