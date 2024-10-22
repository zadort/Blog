namespace Blog.Models
{
    public class Dto
    {
        public record CreateUserDto(Guid Id, string Title, string Description, DateTime CretedTime, DateTime LastUpdated);
        public record UpdateUserDto(Guid Id, string Title, string Description, DateTime CretedTime, DateTime LastUpdated);
    }
}