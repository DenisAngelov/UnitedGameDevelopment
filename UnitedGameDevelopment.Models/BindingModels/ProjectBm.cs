namespace UnitedGameDevelopment.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProjectBm
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title must be between 5 and 100 charcters.", MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Description must be at least 100 characters long.", MinimumLength = 100)]
        public string Description { get; set; }
        [Required]
        [StringLength(10000, MinimumLength = 3, ErrorMessage = "Skills must be between 3 and 10 000 characters length.")]
        public string SkillsRequired { get; set; }
        [Required]
        [Range(0, 200000, ErrorMessage = "Budjet can't be a negative number.")]
        public decimal Budjet { get; set; }
        public string CompanyName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}