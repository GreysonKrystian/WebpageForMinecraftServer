namespace MinecraftServerWeb.Utility.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(): base() {}
        public UserNotFoundException(string message) : base(message) {}
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }
}
