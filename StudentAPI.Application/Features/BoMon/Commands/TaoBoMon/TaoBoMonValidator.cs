using FluentValidation;

namespace StudentAPI.Application.Features.BoMon.Commands.TaoBoMon;

public class TaoBoMonCommandValidator : AbstractValidator<TaoBoMonCommand>
{
    public TaoBoMonCommandValidator()
    {
        RuleFor(x => x.MaBoMon)
            .NotEmpty().WithMessage("Mã bộ môn không được để trống.")
            .MaximumLength(20).WithMessage("Mã bộ môn không được vượt quá 20 ký tự.");

        RuleFor(x => x.TenBoMon)
            .NotEmpty().WithMessage("Tên bộ môn không được để trống.")
            .MaximumLength(100).WithMessage("Tên bộ môn không được vượt quá 100 ký tự.");
    }
}