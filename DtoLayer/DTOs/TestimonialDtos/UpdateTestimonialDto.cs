namespace DtoLayer.DTOs.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string Id { get; set; }

        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }

        public string Comment { get; set; }
    }
}
