namespace Cinema.Data.DTOs.ActorDTOs
{
    public class GetActorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }
}