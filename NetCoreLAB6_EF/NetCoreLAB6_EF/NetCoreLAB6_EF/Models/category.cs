using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreLAB6_EF.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Display(Name = "CreatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
