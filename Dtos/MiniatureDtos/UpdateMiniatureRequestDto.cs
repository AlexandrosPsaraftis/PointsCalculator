﻿namespace Army_Creator_App.Dtos.MiniatureDtos
{
    public class UpdateMiniatureRequestDto
    {

        public string MiniatureName { get; set; }
        public byte Movement { get; set; }
        public byte WeaponSkill { get; set; }
        public byte BallisticSkill { get; set; }
        public byte Strength { get; set; }
        public byte Toughness { get; set; }
        public byte Wounds { get; set; }
        public byte Initiative { get; set; }
        public byte Attacks { get; set; }
        public byte Leadership { get; set; }

    }
}
