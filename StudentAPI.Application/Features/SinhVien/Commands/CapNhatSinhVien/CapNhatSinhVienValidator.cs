using FluentValidation;

namespace StudentAPI.Application.Features.SinhVien.Commands.CapNhatSinhVien;

public class SinhVienUpdateValidator : AbstractValidator<CapNhatSinhVienCommand>
{
    public SinhVienUpdateValidator()
    {
        RuleFor(x => x.HoTen)
            .NotEmpty()
            .WithMessage("Họ tên không được để trống")
            .MaximumLength(100)
            .WithMessage("Họ tên không được vượt quá 100 ký tự");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email không được để trống")
            .EmailAddress()
            .WithMessage("Email không hợp lệ")
            .MaximumLength(150)
            .WithMessage("Email không được vượt quá 150 ký tự");

        RuleFor(x => x.NgaySinh)
            .LessThan(DateTime.Today)
            .WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");

        RuleFor(x => x.DiemTB)
            .InclusiveBetween(0, 10)
            .WithMessage("Điểm trung bình phải từ 0 đến 10");

        RuleFor(x => x.lopHocId)
            .NotNull()
            .WithMessage("Id lớp phải tồn tại trong lớp học");
    }
}