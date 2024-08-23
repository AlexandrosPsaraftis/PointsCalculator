using Army_Creator_App.Dtos;
using Army_Creator_App.Mappers;
using Army_Creator_App.Dtos.WeaponDtos;
using Army_Creator_App.Interfaces;
using Army_Creator_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Army_Creator_App.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeaponController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		private readonly IWeaponRepository _weaponRepo;

		public WeaponController(ApplicationDbContext context, IWeaponRepository weaponRepo)
		{
			_context = context;
			_weaponRepo = weaponRepo;
		}

		[HttpGet]
		public async Task<IActionResult> GetWeapons()
		{
			var weapons = await _weaponRepo.GetAllAsync();

			var weaponDto = weapons.Select(s => s.ToWeaponDto());

			return Ok(weaponDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetWeapon(int id)
		{
			var weapon = await _weaponRepo.GetByIdAsync(id);

			if (weapon == null)
			{
				return NotFound();
			}

			return Ok(weapon.ToWeaponDto());
		}

		[HttpPost]
		public async Task<IActionResult> PostWeapon(CreateWeaponRequestDto postDto)
		{
			var weaponModel = postDto.ToWeaponFromPostDto();

            await _weaponRepo.CreateAsync(weaponModel);

            return CreatedAtAction(nameof(GetWeapon), new { id = weaponModel.Id }, weaponModel.ToWeaponDto());
		}




		[HttpPut("{id}")]
		public async Task<IActionResult> PutWeapon(int id, UpdateWeaponRequestDto updateDto)
		{
            var weaponModel = await _weaponRepo.UpdateAsync(id, updateDto);

            if (weaponModel == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return Ok(weaponModel.ToWeaponDto());

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWeapon(int id)
		{
			var weapon = await _context.Weapons.FindAsync(id);
			if (weapon == null)
			{
				return NotFound();
			}

			_context.Weapons.Remove(weapon);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
