using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Repositories
{
    public interface IAsyncReadOnlyRepository<AggregateType, IdType, FilterType> where AggregateType : IAggregateRoot
	{
		Task<Message<PagedList<AggregateType>>> List(FilterType filter);
		Task<Message<AggregateType>> Get(IdType id);
	}
}
