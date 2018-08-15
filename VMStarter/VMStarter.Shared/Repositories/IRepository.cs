using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Repositories
{
    public interface IRepository<AggregateType, IdType, FilterType> : IReadOnlyRepository<AggregateType, IdType, FilterType> where AggregateType:IAggregateRoot where FilterType:Filter
	{
		Message<AggregateType> Create(AggregateType aggregate);
		Message<AggregateType> Update(AggregateType aggregate);
		Message<AggregateType> Delete(IdType id);
    }
}
