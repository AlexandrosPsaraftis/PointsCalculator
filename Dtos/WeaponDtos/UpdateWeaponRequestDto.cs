namespace Army_Creator_App.Dtos.WeaponDtos
{
    public class UpdateWeaponRequestDto
    {
        public string WeaponName { get; set; } = string.Empty;
        public byte Range { get; set; }
        public byte? Attacks { get; set; }
        public byte Strength { get; set; }
        public byte Damage { get; set; }

    }
}
