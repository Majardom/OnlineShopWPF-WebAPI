using System.ComponentModel.DataAnnotations;
using BLL.DTO.Abstract;

namespace BLL.DTO
{
    public class CategoryDescriptionDto : BaseBllEntity
    {
        [Required]
        public string Description { get; set; }
    }
}
