
namespace StudentAPI.Application.Features.SinhVien.Common
{
    public class SinhVienDto
    {

        public int Id { get; set; }
        public string? MaSV { get; set; }
        public string? HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? Email { get; set; }
        public decimal DiemTB { get; set; }
        public int LopHocId { get; set; }


    }
}