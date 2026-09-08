namespace StudentAPI.Domain.Entities;

public class BoMon
{
    public Guid id { get; set; }
    public string maBM { get; set; } = string.Empty;

    public string tenBM { get; set; } = string.Empty;
    public ICollection<LopHoc>? lopHocs { get; set; }
}