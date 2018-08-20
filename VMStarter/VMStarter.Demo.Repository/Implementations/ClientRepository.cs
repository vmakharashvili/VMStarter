using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VMStarter.Demo.DAL.Models;
using VMStarter.Demo.Domain.Clients;
using VMStarter.Demo.Repository.Interfaces;
using VMStarter.Shared.Actions;
using VMStarter.Shared.Extensions;
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
        }, async()=> { return await DatabaseContext.Clients.AnyAsync(f => 
               f.FirstName == aggregate.FirstName 
            && f.LastName == aggregate.LastName 
            && f.Address==aggregate.Address); }, "The client is already registered in the database").Run();

        public async Task<Message<ClientDomain>> Delete(int id) => await new ExecutionAsync<ClientDomain>(async () =>
        {
            var client = await DatabaseContext.Clients.FirstOrDefaultAsync(f => f.Id == id);
            DatabaseContext.Clients.Remove(client);
            await DatabaseContext.SaveChangesAsync();
        }).Run();

        public async Task<Message<ClientDomain>> Get(int id)
        {
            var client = await DatabaseContext.Clients.FirstOrDefaultAsync(f => f.Id == id);
            return new Message<ClientDomain>(Map<Client, ClientDomain>(client));
        }

        public async Task<Message<PagedList<ClientDomain>>> List(ClientFilter filter)
        {
            var clients= await DatabaseContext.Clients.ToMappedPagedListAsync<Client, ClientDomain, ClientFilter>(filter);
            return new Message<PagedList<ClientDomain>>(clients);
        }

        public async Task<Message<ClientDomain>> Update(ClientDomain aggregate) => await new ExecutionAsync<ClientDomain>(async () =>
        {
            var clientToEdit = await DatabaseContext.Clients.FirstOrDefaultAsync(f => f.Id == aggregate.Id);
            clientToEdit = await MappAsync(aggregate, clientToEdit);
            await DatabaseContext.SaveChangesAsync();
        }).Run();
    }
}
