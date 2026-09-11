namespace StudentAPI.Domain.Entities;

public class LopHoc
{
    public int Id { get; set; }
    public string? MaLop { get; set; }
    public string TenLop { get; set; } = string.Empty;
    public string? ChuyenNganh { get; set; }
    public int? BoMonId { get; set; }
    public BoMon? BoMon { get; set; }
    public ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}