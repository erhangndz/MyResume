using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.ProjectDtos
{
    public class CreateProjectDto
    {
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Type { get; set; }
    }
}
