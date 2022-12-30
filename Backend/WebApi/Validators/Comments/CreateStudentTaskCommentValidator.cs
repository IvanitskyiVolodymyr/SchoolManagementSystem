using Common.Dtos.StudentTaskComment;
using FluentValidation;

namespace WebApi.Validators.Comments
{
    public class CreateStudentTaskCommentValidator : AbstractValidator<CreateStudentTaskCommentDto>
    {
        public CreateStudentTaskCommentValidator()
        {
            RuleFor(c => c.Comment).NotNull().NotEmpty();
            RuleFor(c => c.UserId).Must(id => id > 0);
            RuleFor(c => c.StudentTaskId).Must(id => id > 0);
        }
    }
}
