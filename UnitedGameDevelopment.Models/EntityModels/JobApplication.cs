namespace UnitedGameDevelopment.Models.EntityModels
{
    using System;

    public class JobApplication
    {
        public int Id { get; set; }
        public Freelancer Freelancer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillsAcquired { get; set; }
        public decimal SalaryPerHour { get; set; }
        public DateTime PublishDate { get; set; }
    }
}