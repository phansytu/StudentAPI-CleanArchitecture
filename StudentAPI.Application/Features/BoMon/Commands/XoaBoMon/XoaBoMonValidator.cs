using FluentValidation;

namespace StudentAPI.Application.Features.BoMon.Commands.XoaBoMon;

public class XoaBoMonCommandValidator : AbstractValidator<XoaBoMonCommand>
{
    public XoaBoMonCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("ID bộ môn phải lớn hơn 0.");
    }
}