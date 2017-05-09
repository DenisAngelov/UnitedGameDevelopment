namespace UnitedGameDevelopment.Models.ViewModels.Manage
{
    using EntityModels;

    public class FreelancerUserVm
    {
        public int Id { get; set; }
        public string FreelancerName { get; set; }
        public ApplicationUser User { get; set; }
    }
}