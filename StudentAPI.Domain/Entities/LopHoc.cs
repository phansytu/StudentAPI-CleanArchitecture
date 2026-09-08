namespace StudentAPI.Domain.Entities;

public class LopHoc
{
    public int Id { get; set; }

    public string MaLop { get; set; } = string.Empty;

    public required string TenLop { get; set; }

    public required string ChuyenNganh { get; set; }


    public int BoMonId { get; set; }
    public BoMon? BoMon { get; set; }
    public ICollection<SinhVien>? SinhViens { get; set; }
}