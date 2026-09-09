using FluentValidation;

namespace StudentAPI.Application.Features.LopHoc.Commands.TaoLopHoc;

public class TaoLopHocValidator
           : AbstractValidator<TaoLopHocCommand>
{
    public TaoLopHocValidator()
    {
        RuleFor(x => x.TenLop)
            .NotEmpty()
            .WithMessage("Tên lớp không được để trống")
            .MaximumLength(100)
            .WithMessage("Tên lớp không được vượt quá 100 ký tự");

        RuleFor(x => x.ChuyenNganh)
            .NotEmpty()
            .WithMessage("Chuyên ngành không được để trống")
            .MaximumLength(100)
            .WithMessage("Chuyên ngành không được vượt quá 100 ký tự");
    }
}