using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Actions
{
    public static class ExecutionExtension
    {
		public static Message<AggregateType> AddCondition<AggregateType>(this Action method, Func<bool> cond, string errorMessage)
		{
			if(cond.Invoke()){
				return new Message<AggregateType>(errorMessage);
			}
			else {
				method.Invoke();
			}
			return new Message<AggregateType>();
		}

		public static Message<AggregateType> AddCondition<AggregateType>(this Func<AggregateType> method, Func<bool> cond, string errorMessage)
		{
			if (cond.Invoke())
			{
				return new Message<AggregateType>(errorMessage);
			}
			else
			{
			   return new Message<AggregateType>(method.Invoke());
			}
		}


	}
}
