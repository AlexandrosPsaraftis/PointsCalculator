using Army_Creator_App.Dtos;
using Army_Creator_App.Dtos.WeaponDtos;
using Army_Creator_App.Models;

public static class WeaponMapper
{
	public static WeaponDto ToWeaponDto(this Weapon weapon)
	{

		byte? tempAttacks = null;
		if (weapon is RangedWeapon)
		{
			RangedWeapon tempRangedWeapon = (RangedWeapon)weapon;
			tempAttacks = tempRangedWeapon.Attacks;	
		}

		return new WeaponDto
        {
			Id = weapon.Id,
			WeaponName = weapon.WeaponName,
			Range = weapon.Range,
			Attacks = tempAttacks,
			Strength = weapon.Strength,
			Damage = weapon.Damage

		};
	}

	public static Weapon ToWeaponFromPostDto(this CreateWeaponRequestDto dto)
	{

		if (dto.Range == 0)
		{
			return new MeleeWeapon
			{
				WeaponName = dto.WeaponName,
				Strength = dto.Strength,
				Damage = dto.Damage
			};
		}
		
		return new RangedWeapon
		{
			WeaponName = dto.WeaponName,
			Range = dto.Range,
			Attacks = dto.Attacks.GetValueOrDefault(),
			Strength = dto.Strength,
			Damage = dto.Damage
		};
		
	}
}
