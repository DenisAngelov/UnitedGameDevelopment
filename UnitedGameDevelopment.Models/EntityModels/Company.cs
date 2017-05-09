namespace UnitedGameDevelopment.Models.EntityModels
{
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
            this.Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}