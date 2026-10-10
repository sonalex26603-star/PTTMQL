
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    public class SanPham
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; } = string.Empty;

        [Range(0.01, 1000000000,
            ErrorMessage = "Giá phải lớn hơn 0")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá")]
        public decimal Gia { get; set; }

        [Range(0, 1000000,
            ErrorMessage = "Số lượng không hợp lệ")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
    }
}
