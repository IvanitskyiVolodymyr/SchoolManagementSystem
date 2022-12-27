using Common.Dtos.Tasks;
using FluentValidation;

namespace WebApi.Validators.Tasks
{
    public class InsertTaskValidator : AbstractValidator<InsertTaskDto>
    {
        public InsertTaskValidator()
        {
            RuleFor(t => t.Title).NotNull().NotEmpty();
            RuleFor(t => t.StartDateTime).Must(BeAValidDate).WithMessage("StartDateTime is required");
            RuleFor(t => t.EndDateTime).Must(BeAValidDate).WithMessage("EndDateTime is required");
            RuleFor(t => t.TaskType).IsInEnum();
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
