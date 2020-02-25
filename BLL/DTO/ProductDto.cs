using System.ComponentModel.DataAnnotations;
using BLL.DTO.Abstract;

namespace BLL.DTO
{
    public class ProductDto : BaseBllEntity
    {
        [Required, StringLength(30)]
        public string Caption { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
