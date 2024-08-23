using System.ComponentModel.DataAnnotations;

namespace Army_Creator_App.Models
{
    public class Miniature
    {
        [Key]
        public int Id { get; set; }
        public string MiniatureName { get; set; } = string.Empty;
        public byte Movement { get; set; }
        public byte WeaponSkill { get; set; }
        public byte BallisticSkill { get; set; }
        public byte Strength { get; set; }
        public byte Toughness { get; set; }
        public byte Wounds { get; set; }
        public byte Initiative { get; set; }
        public byte Attacks { get; set; }
        public byte Leadership { get; set; }
        public double Points { get; set; }
        public List<MiniatureWeapon> MiniatureWeapons { get; set; }
        public Miniature(string miniatureName, byte movement, byte weaponSkill, byte ballisticSkill, byte strength, byte toughness, byte wounds, byte initiative, byte attacks, byte leadership)
        {
            MiniatureName = miniatureName;
            Movement = movement;
            WeaponSkill = weaponSkill;
            BallisticSkill = ballisticSkill;
            Strength = strength;
            Toughness = toughness;
            Wounds = wounds;
            Initiative = initiative;
            Attacks = attacks;
            Leadership = leadership;
        }

        public Miniature()
        {

        }
    }
}
