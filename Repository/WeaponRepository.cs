using Army_Creator_App.Dtos.WeaponDtos;
using Army_Creator_App.Interfaces;
using Army_Creator_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Army_Creator_App.Repository
{
    public class WeaponRepository : IWeaponRepository
	{

		private readonly ApplicationDbContext _context;

		public WeaponRepository(ApplicationDbContext context) 
		{
			_context = context;
		}

		public async Task<List<Weapon>> GetAllAsync()
		{
			return await _context.Weapons.ToListAsync();
		}

		public async Task<Weapon?> GetByIdAsync(int id)
		{
			return await _context.Weapons.FindAsync(id);
		}
		public async Task<Weapon> CreateAsync(Weapon weaponModel)
		{
			await _context.Weapons.AddAsync(weaponModel);
			await _context.SaveChangesAsync();
			return weaponModel;
		}
		public async Task<Weapon> UpdateAsync(int id, UpdateWeaponRequestDto weaponDto)
		{

			//existingWeapon is the instance of the object we draw from the database
			var existingWeapon = await _context.Weapons.FirstOrDefaultAsync(x => x.Id == id);

			//weaponDto is the updated info we request from the user

			//if the update is making a rangedWeapon into a meleeWeapon
			if (weaponDto.Range == 0 && existingWeapon is RangedWeapon)
			{

                var tempRangedWeapon = existingWeapon as RangedWeapon;

                if (tempRangedWeapon != null)
                {
                    tempRangedWeapon.Attacks = 0;
                    await _context.SaveChangesAsync();
                }

                _context.Entry(existingWeapon).State = EntityState.Detached;

				var newMeleeWeapon = new MeleeWeapon
				{
					Id = existingWeapon.Id,
					WeaponName = weaponDto.WeaponName,
					Range = 0,
					Strength = weaponDto.Strength,
					Damage = weaponDto.Damage,
				};


				_context.MeleeWeapons.Add(newMeleeWeapon);
				_context.Entry(existingWeapon).State = EntityState.Deleted;
				await _context.SaveChangesAsync();
				return newMeleeWeapon;
			}
			else if (weaponDto.Range > 0 && existingWeapon is MeleeWeapon)
			{
				_context.Entry(existingWeapon).State = EntityState.Detached;

				var newRangedWeapon = new RangedWeapon
				{
					Id = existingWeapon.Id,
					WeaponName = weaponDto.WeaponName,
					Range = weaponDto.Range,
					Attacks = weaponDto.Attacks.GetValueOrDefault(),
					Strength = weaponDto.Strength,
					Damage = weaponDto.Damage,
				};

				_context.RangedWeapons.Add(newRangedWeapon);
                _context.Entry(existingWeapon).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
				return newRangedWeapon;
            }
            else
			{
                // Update the weapon entity with DTO data
                existingWeapon.WeaponName = weaponDto.WeaponName;
                existingWeapon.Range = weaponDto.Range;
                existingWeapon.Strength = weaponDto.Strength;
                existingWeapon.Damage = weaponDto.Damage;
                if (existingWeapon is RangedWeapon rangedWeapon && weaponDto.Attacks.HasValue)
                {
                    rangedWeapon.Attacks = weaponDto.Attacks.Value;
                }

                await _context.SaveChangesAsync();
				return existingWeapon;
            }
		}

		public async Task<Weapon?> DeleteAsync(int id)
		{
            var weaponModel = await _context.Weapons.FirstOrDefaultAsync(x => x.Id == id);

            if (weaponModel == null)
            {
                return null;
            }

            _context.Weapons.Remove(weaponModel);
            await _context.SaveChangesAsync();
            return weaponModel;
        }
    }
}
