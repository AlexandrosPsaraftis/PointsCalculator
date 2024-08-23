using System.Text.Json.Serialization;

namespace Army_Creator_App.Models
{
    public class RangedWeapon : Weapon
    {

        public override byte Range { get; set; }
        public byte Attacks { get; set; }

    }
}
