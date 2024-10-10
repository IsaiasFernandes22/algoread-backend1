namespace ContentManagementAPI.DTOs
{
    public class ContentDto
    {
        public string Title { get; set; } = string.Empty; 
        public string Body { get; set; } = string.Empty; 
        public string UserId { get; set; } = string.Empty; 

        public ContentDto() { }
    }
}
