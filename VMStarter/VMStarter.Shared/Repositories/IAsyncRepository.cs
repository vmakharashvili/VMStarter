using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Repositories
{
    public interface IAsyncRepository<AggregateType, IdType, FilterType> : IAsyncReadOnlyRepository<AggregateType, IdType, FilterType> where AggregateType:IAggregateRoot where FilterType:Filter
    {
		Task<Message<AggregateType>> Create(AggregateType aggregate);
		Task<Message<AggregateType>> Update(AggregateType aggregate);
		Task<Message<AggregateType>> Delete(IdType id);
    }
}
