namespace YourNamespace.Models
{
    public class ContentReviewAssignment
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ReviewerId { get; set; }

        public ContentSubmission ContentSubmission { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
