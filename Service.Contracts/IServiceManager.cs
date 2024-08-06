namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }

        IUserService UserService { get; }

        IWaterSampleService WaterSampleService { get; }
    }
}
