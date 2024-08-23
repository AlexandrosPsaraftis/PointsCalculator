using Army_Creator_App.Models;
using System.Text.Json.Serialization;

namespace Army_Creator_App.Dtos
{
    public class WeaponDto
    {
        public int Id { get; set; }
        public string WeaponName { get; set; } = string.Empty;
        public byte Range { get; set; }
        public byte? Attacks { get; set; } 
        public byte Strength { get; set; }
        public byte Damage { get; set; }

        //Add Miniature here!

    }

}
