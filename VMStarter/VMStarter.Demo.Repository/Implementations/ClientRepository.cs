using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VMStarter.Demo.DAL.Models;
using VMStarter.Demo.Domain.Clients;
using VMStarter.Demo.Repository.Interfaces;
using VMStarter.Shared.Actions;
using VMStarter.Shared.Models;

namespace VMStarter.Demo.Repository.Implementations
{
    public class ClientRepository : RepositoryBase<DemoContext>, IClientRepository
    {
        public ClientRepository(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public async Task<Message<ClientDomain>> Create(ClientDomain aggregate) => await new ExecutionAsync<ClientDomain>(async () =>
        {
            var client = Map<ClientDomain, Client>(aggregate);
            await DatabaseContext.Clients.AddAsync(client);
            await DatabaseContext.SaveChangesAsync();
        }).Run();

        public Task<Message<ClientDomain>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Message<ClientDomain>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Message<PagedList<ClientDomain>>> List(ClientFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Message<ClientDomain>> Update(ClientDomain aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
