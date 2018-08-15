using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Repositories
{
    public interface IReadOnlyRepository<AggregateType, IdType, FilterType> where AggregateType:IAggregateRoot
    {
		Message<PagedList<AggregateType>> List(FilterType filter);
		Message<AggregateType> Get(IdType id);
    }
}
