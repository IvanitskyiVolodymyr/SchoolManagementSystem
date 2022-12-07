namespace Domain.Core.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public int UserId { get; set; }
        public int? ClassId { get; set; }
    }
}
