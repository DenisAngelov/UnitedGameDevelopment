namespace UnitedGameDevelopment.Models.EntityModels
{
    using System.Collections.Generic;

    public class Freelancer
    {
        public Freelancer()
        {
            this.JobApplications = new HashSet<JobApplication>();
        }

        public int Id { get; set; }
        public string FreelancerName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}