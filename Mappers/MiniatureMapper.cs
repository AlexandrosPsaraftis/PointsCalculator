using Army_Creator_App.Dtos.MiniatureDtos;
using Army_Creator_App.Models;
using Microsoft.Identity.Client;

namespace Army_Creator_App.Mappers
{
    public static class MiniatureMapper
    {

        public static MiniatureDto ToMiniatureDto(this Miniature miniature)
        {
            return new MiniatureDto
            {
                Id = miniature.Id,
                MiniatureName = miniature.MiniatureName,
                Movement = miniature.Movement,
                WeaponSkill = miniature.WeaponSkill,
                BallisticSkill = miniature.BallisticSkill,
                Strength = miniature.Strength,
                Toughness = miniature.Toughness,
                Wounds = miniature.Wounds,
                Initiative = miniature.Initiative,
                Attacks = miniature.Attacks,
                Leadership = miniature.Leadership,
                Points = miniature.Points,
            };

        }
        public static Miniature ToMiniatureFromPostDto(this CreateMiniatureRequestDto dto)
        {
            return new Miniature
            {
                MiniatureName = dto.MiniatureName,
                Movement = dto.Movement,
                WeaponSkill = dto.WeaponSkill,
                BallisticSkill = dto.BallisticSkill,
                Strength = dto.Strength,
                Toughness = dto.Toughness,
                Wounds = dto.Wounds,
                Initiative = dto.Initiative,
                Attacks = dto.Attacks,
                Leadership = dto.Leadership
            };
        }
    }
}