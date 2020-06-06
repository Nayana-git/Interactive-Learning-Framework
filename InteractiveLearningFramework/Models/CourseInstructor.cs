namespace InteractiveLearningFramework.Models
{
    public class CourseInstructor
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }

        public User Instructor { get; set; }
        public Course Course { get; set; }
    }
}