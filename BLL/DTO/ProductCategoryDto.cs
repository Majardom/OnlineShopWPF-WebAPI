using System.ComponentModel.DataAnnotations;
using BLL.DTO.Abstract;

namespace BLL.DTO
{
    public class ProductCategoryDto : BaseBllEntity
    {
        [Required]
        public int DescriptionId { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
