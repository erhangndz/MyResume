using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.ExperienceDtos
{
    public class ResultExperienceDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
