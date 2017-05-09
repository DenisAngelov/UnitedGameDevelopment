namespace UnitedGameDevelopment.Services
{
    using Data.Contracts;

    public abstract class Service
    {
        public Service(IUnitOfWork context)
        {
            this.Context = context;
        }

        protected IUnitOfWork Context { get; }
    }
}
