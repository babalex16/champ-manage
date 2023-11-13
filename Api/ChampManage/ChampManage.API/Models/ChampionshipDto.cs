﻿namespace ChampManage.API.Models
{
    public class ChampionshipDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string? Description { get; set; }
        public int OrganizerId { get; set; }

        public ICollection<UserDto> Participants { get; set; }
               = new List<UserDto>();
        public ICollection<MatchDto> Matches { get; set; }
               = new List<MatchDto>();

        public ICollection<CategoryDto> Categories { get; set; }
               = new List<CategoryDto>();
    }

}
