using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Demo.Domain.Clients;
using VMStarter.Shared.Repositories;

namespace VMStarter.Demo.Repository.Interfaces
{
    public interface IClientRepository : IAsyncRepository<ClientDomain, int, ClientFilter>
    {
    }
}
