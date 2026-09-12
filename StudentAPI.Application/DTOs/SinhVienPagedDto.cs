namespace StudentAPI.Application.DTOs;

public class SinhVienPagedDto
{
    public int Id { get; set; }
    public string Msv { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool? GioiTinh { get; set; }
    public DateTime? NgaySinh { get; set; }
    public string Email { get; set; } = string.Empty;
    public double? DiemTb { get; set; }
    public string TenLop { get; set; } = string.Empty;
    public string TenMon { get; set; } = string.Empty;
}