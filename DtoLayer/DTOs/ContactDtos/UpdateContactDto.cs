using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.ContactDtos
{
    public class UpdateContactDto
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? instagramUrl { get; set; }
        public string? linkedinUrl { get; set; }
        public string? githubUrl { get; set; }
        public string? youtubeUrl { get; set; }

        public string MapUrl { get; set; }
    }
}
