using System.ComponentModel.DataAnnotations;
using BLL.DTO.Abstract;

namespace BLL.DTO
{
    public class StageDto : BaseBllEntity
    {
        [Required, StringLength(20)]
        public string Caption { get; set; }
    }
}
