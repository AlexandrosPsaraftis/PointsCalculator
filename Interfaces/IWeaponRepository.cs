using Army_Creator_App.Dtos.WeaponDtos;
using Army_Creator_App.Models;

namespace Army_Creator_App.Interfaces
{
    public interface IWeaponRepository
    {

        Task<List<Weapon>> GetAllAsync();

        Task<Weapon?> GetByIdAsync(int id);

        Task<Weapon> CreateAsync(Weapon weaponModel);

        Task<Weapon> UpdateAsync(int id, UpdateWeaponRequestDto weaponDto);

        Task<Weapon> DeleteAsync(int id);

    }
}
