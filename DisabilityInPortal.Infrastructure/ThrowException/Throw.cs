namespace DisabilityInPortal.Infrastructure.ThrowException
{
    public class Throw : IThrow
    {
        private Throw()
        {
        }

        public static IThrow Exception { get; } = new Throw();
    }
}