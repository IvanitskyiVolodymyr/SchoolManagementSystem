using Common.Dtos.StudentTask;
using Common.Dtos.StudentTaskAttachment;

namespace Common.Dtos.Tasks
{
    public class ResponseTaskWithGradeAndAttachmentsDto : TaskWithGradeDto
    {
        public IEnumerable<StudentTaskAttachmentDto>? Attachments { get; set; } 
    }
}
