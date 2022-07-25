namespace MinecraftServerWeb.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IPostRepository Post {get;}
        public IUserRepository User {get;}
        void Commit();
    }
}
