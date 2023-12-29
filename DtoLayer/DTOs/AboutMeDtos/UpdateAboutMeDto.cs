using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.AboutMeDtos
{
    public class UpdateAboutMeDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string CVUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
