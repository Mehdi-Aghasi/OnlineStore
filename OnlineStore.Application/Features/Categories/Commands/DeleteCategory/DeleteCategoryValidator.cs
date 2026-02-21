using FluentValidation;

namespace OnlineStore.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
        }
    }
}
