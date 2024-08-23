using Army_Creator_App.Models;
using System.Text.Json.Serialization;

namespace Army_Creator_App.Models
{
    public class MeleeWeapon : Weapon
    {
        public override byte Range { get; set; } = 0;
    }
}
