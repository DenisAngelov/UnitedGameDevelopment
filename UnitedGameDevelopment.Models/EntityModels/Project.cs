namespace UnitedGameDevelopment.Models.EntityModels
{
    using System;

    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillsRequired { get; set; }
        public decimal Budjet { get; set; }
        public Company Company { get; set; }
        public DateTime PublishDate { get; set; }
    }
}