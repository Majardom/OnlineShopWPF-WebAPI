using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Abstract
{
    public abstract class BaseBllEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
