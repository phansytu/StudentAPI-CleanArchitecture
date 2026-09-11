using FluentValidation;

namespace StudentAPI.Application.Features.BoMon.Queries.LayDanhSachBoMon;

public class LayDanhSachBoMonValidator : AbstractValidator<LayDanhSachBoMonQuery>
{
    public LayDanhSachBoMonValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0).WithMessage("Số trang (PageIndex) phải lớn hơn 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Số bản ghi mỗi trang (PageSize) phải lớn hơn 0.")
            .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100.");
    }
}