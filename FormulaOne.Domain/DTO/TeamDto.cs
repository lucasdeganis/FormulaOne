﻿namespace FormulaOne.Domain.DTO
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string FullTeamName { get; set; }
        public string Base { get; set; }
        public string TeamChief { get; set; }
        public string TechnicalChief { get; set; }
        public string Chassis { get; set; }
        public string PowerUnit { get; set; }
        public int FirstTeamEntry { get; set; }
        public int WorldChampionships { get; set; }
        public string HighestRaceFinish { get; set; }
        public int PolePositions { get; set; }
        public int FastestLaps { get; set; }
    }
}
