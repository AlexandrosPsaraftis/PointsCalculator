using Army_Creator_App.Dtos.MiniatureDtos;
using Army_Creator_App.Models;

namespace Army_Creator_App.Interfaces
{
    public interface IMiniatureRepository
    {

        Task<List<Miniature>> GetAllAsync();

        Task<Miniature?> GetByIdAsync(int id);

        Task<Miniature> CreateAsync(Miniature miniatureModel);

        Task<Miniature> UpdateAsync(int id, UpdateMiniatureRequestDto miniatureDto);

        Task<Miniature> DeleteAsync(int id);

    }
}
