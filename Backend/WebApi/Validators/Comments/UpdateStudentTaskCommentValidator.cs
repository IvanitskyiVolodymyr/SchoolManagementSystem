using Common.Dtos.StudentTaskComment;
using FluentValidation;

namespace WebApi.Validators.Comments
{
    public class UpdateStudentTaskCommentValidator : AbstractValidator<UpdateStudentTaskCommentDto>
    {
        public UpdateStudentTaskCommentValidator()
        {
            RuleFor(c => c.Comment).NotNull().NotEmpty();
            RuleFor(c => c.StudentTaskCommentId).Must(c => c > 0);
        }
    }
}
