﻿

namespace DtoLayer.DTOs.EducationDtos
{
    public class UpdateEducationDto
    {
        public string Id { get; set; }

        public string SchoolName { get; set; }
        public string Department { get; set; }
        public int StartYear { get; set; }
        public int FinishYear { get; set; }
    }
}
