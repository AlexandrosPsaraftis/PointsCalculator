using Army_Creator_App.Dtos.MiniatureDtos;
using Army_Creator_App.Interfaces;
using Army_Creator_App.Mappers;
using Army_Creator_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Army_Creator_App.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MiniatureController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		private readonly IMiniatureRepository _miniatureRepo;
		public MiniatureController(ApplicationDbContext context, IMiniatureRepository miniatureRepo)
		{
			_miniatureRepo = miniatureRepo;
			_context = context;
		}


		[HttpGet]
		public async Task<IActionResult> GetMiniatures()
		{

			//Get all the miniatures
			var miniatures = await _miniatureRepo.GetAllAsync();

			//Trim the fat down using Dtos
			var miniatureDto = miniatures.Select(s => s.ToMiniatureDto());

			return Ok(miniatureDto);
		}


		[HttpGet("{id}")] 
		public async Task<IActionResult> GetMiniature(int id)
		{
			//Get the miniature with that Id
			var miniature = await _miniatureRepo.GetByIdAsync(id);

			if (miniature == null)
			{
				return NotFound();
			}

			//Trim the fat and return that miniature
			return Ok(miniature.ToMiniatureDto());

		}

		[HttpPost]
		public async Task<ActionResult> PostMiniature(CreateMiniatureRequestDto postDto)
		{
			var miniatureModel = postDto.ToMiniatureFromPostDto();

		   
			await _miniatureRepo.CreateAsync(miniatureModel);

			return CreatedAtAction(nameof(GetMiniature), new { id = miniatureModel.Id }, miniatureModel.ToMiniatureDto());
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutMiniature(int id, UpdateMiniatureRequestDto updateDto)
		{

			var miniatureModel = await _miniatureRepo.UpdateAsync(id, updateDto);

			if (miniatureModel == null)
			{
				return NotFound();
			}

			await _context.SaveChangesAsync();

			return Ok(miniatureModel.ToMiniatureDto());

		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMiniature(int id)
		{
			var miniatureModel = await _miniatureRepo.DeleteAsync(id);

			if (miniatureModel == null)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}