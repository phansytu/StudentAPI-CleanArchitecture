namespace StudentAPI.Domain.Entities;

public class BoMon
{
    public int Id { get; set; }
    public string? MaBoMon { get; set; }

    public string? TenBoMon { get; set; }
    public ICollection<LopHoc>? LopHocs { get; set; }
}