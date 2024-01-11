using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.TeamDtos
{
    public class CreateTeamDto
    {
        
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
