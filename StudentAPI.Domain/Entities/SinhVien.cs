namespace StudentAPI.Domain.Entities
{

    public class SinhVien
    {

        public int Id { get; set; }
        public string MaSV { get; set; } = string.Empty;
        public required string HoTen { get; set; }

        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public required string Email { get; set; }

        public decimal DiemTB { get; set; }

        public required int LopHocId { get; set; }

        public LopHoc? lopHoc { get; set; }

    }
}