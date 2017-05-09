namespace UnitedGameDevelopment.Models.ViewModels.Manage
{
    using EntityModels;

    public class CompanyUsersVm
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public ApplicationUser User { get; set; }
    }
}