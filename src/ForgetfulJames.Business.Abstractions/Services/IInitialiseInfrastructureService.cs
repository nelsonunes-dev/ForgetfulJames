using ForgetfulJames.Business.Abstractions.Business;
using ForgetfulJames.Infrastructure.Abstractions;

namespace ForgetfulJames.Business.Abstractions.Services
{
    public interface IInitialiseInfrastructureService : IInitialiseInfrastructure, IInitialiseDatabase, ISeedDatabase { }
}
