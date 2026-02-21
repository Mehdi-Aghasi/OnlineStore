using FluentValidation;

namespace OnlineStore.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValodator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValodator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Category description cannot exceed 500 characters.");
            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Category slug is required.")
                .MaximumLength(100).WithMessage("Category slug cannot exceed 100 characters.");
        }
    }
}
