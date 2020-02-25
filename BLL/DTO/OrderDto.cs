using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.DTO.Abstract;
using DAL.DataEntities;

namespace BLL.DTO
{
    public class OrderDto : BaseBllEntity
    {
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        public int StageId { get; set; }
        [Required]
        public List<Product> Products { get; set; }
    }
}
