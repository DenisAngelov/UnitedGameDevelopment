namespace UnitedGameDevelopment.Models.ViewModels.Projects
{
    using System;

    public class ProjectVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillsRequired { get; set; }
        public decimal Budjet { get; set; }
        public string CompanyName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}