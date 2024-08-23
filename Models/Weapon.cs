using System.ComponentModel.DataAnnotations;

namespace Army_Creator_App.Models
{
    public abstract class Weapon
    {

        [Key]
        public  int Id { get; set; }
        public  string WeaponName { get; set; } = string.Empty;
        public abstract byte Range { get; set; }
        public  byte Strength { get; set; }
        public  byte Damage { get; set; }
        public List<MiniatureWeapon> MiniatureWeapons { get; set; }
    }
}
