using Common.Dtos.StudentTaskAttachment;

namespace Common.Dtos.Tasks
{
    public class ResponseTaskWithGradeAndAttachmentsDto : ResponseTaskWithGradeDto
    {
        public IEnumerable<StudentTaskAttachmentDto> Attachments { get; set; } 
    }
}
