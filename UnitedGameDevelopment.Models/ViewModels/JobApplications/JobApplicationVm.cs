namespace UnitedGameDevelopment.Models.ViewModels.JobApplications
{
    using System;
    using EntityModels;

    public class JobApplicationVm
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