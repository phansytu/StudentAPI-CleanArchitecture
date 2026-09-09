using FluentValidation;

namespace StudentAPI.Application.Features.LopHoc.Queries.LayDanhSachLopHoc;

public class LayDanhSachLopHocValidator : AbstractValidator<LayDanhSachLopHocQuery>
{
    public LayDanhSachLopHocValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Số bản ghi mỗi trang phải lớn hơn 0.")
            .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100.");
    }
}