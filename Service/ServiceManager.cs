using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IWaterSampleService> _waterSampleService;
        private readonly Lazy<ICsvService> _csvService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IOptions<JwtConfiguration> configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _waterSampleService = new Lazy<IWaterSampleService>(() => new WaterSampleService(userManager, mapper, logger, repository));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, configuration, userManager, roleManager));
            _userService = new Lazy<IUserService>(() => new UserService(logger, mapper, configuration, userManager, roleManager));
            _csvService = new Lazy<ICsvService>(() => new CsvService());
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IUserService UserService => _userService.Value;

        public IWaterSampleService WaterSampleService => _waterSampleService.Value;

        public ICsvService CsvService => _csvService.Value;
    }
}
