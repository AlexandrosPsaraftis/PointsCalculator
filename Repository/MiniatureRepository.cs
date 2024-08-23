using Army_Creator_App.Dtos.MiniatureDtos;
using Army_Creator_App.Interfaces;
using Army_Creator_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Army_Creator_App.Repository
{
	public class MiniatureRepository : IMiniatureRepository
	{

		private readonly ApplicationDbContext _context;

		public MiniatureRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async  Task<List<Miniature>> GetAllAsync()
		{
			return await _context.Miniatures.ToListAsync();
		}

		public async Task<Miniature?> GetByIdAsync(int id)
		{

			return await _context.Miniatures.FindAsync(id);

		}

		public async Task<Miniature> CreateAsync(Miniature miniatureModel)
		{
			await _context.Miniatures.AddAsync(miniatureModel);
			await _context.SaveChangesAsync();
			return miniatureModel;
		}

		public async Task<Miniature> UpdateAsync(int id, UpdateMiniatureRequestDto miniatureDto)
		{
			var existingMiniature = await _context.Miniatures.FirstOrDefaultAsync(x => x.Id == id);

			if (existingMiniature == null)
			{
				return null;
			}

			existingMiniature.MiniatureName = miniatureDto.MiniatureName;
			existingMiniature.Movement = miniatureDto.Movement;
			existingMiniature.WeaponSkill = miniatureDto.WeaponSkill;
			existingMiniature.BallisticSkill = miniatureDto.BallisticSkill;
			existingMiniature.Strength = miniatureDto.Strength;
			existingMiniature.Toughness = miniatureDto.Toughness;
			existingMiniature.Wounds = miniatureDto.Wounds;
			existingMiniature.Initiative = miniatureDto.Initiative;
			existingMiniature.Attacks = miniatureDto.Attacks;
			existingMiniature.Leadership = miniatureDto.Leadership;

			await _context.SaveChangesAsync();
			return existingMiniature;
		}

		public async Task<Miniature?> DeleteAsync(int id)
		{
			var miniatureModel = await _context.Miniatures.FirstOrDefaultAsync(x => x.Id == id);

			if (miniatureModel == null)
			{
				return null;
			}

			_context.Miniatures.Remove(miniatureModel);
			await _context.SaveChangesAsync();
			return miniatureModel;
		}

	}
}
