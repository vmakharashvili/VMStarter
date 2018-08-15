using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Actions
{
    public class ExecutionAsync<T>
    {
		private Dictionary<Func<Task<bool>>, string> conditions { get; set; }
		private Action Method { get; set; }

		public ExecutionAsync(Action action)
		{
			Method = action;
			conditions = null;

		}

		public ExecutionAsync(Action method, Func<Task<bool>> cond, string errorMessage)
		{
			if (conditions == null)
			{
				conditions = new Dictionary<Func<Task<bool>>, string>();
				conditions.Add(cond, errorMessage);
			}
			Method = method;
		}

		public ExecutionAsync<T> AddCondition(Func<Task<bool>> cond, string errorMessage)
		{
			conditions.Add(cond, errorMessage);
			return this;
		}

		public async Task<Message<T>> Run()
		{
			try
			{
				bool isConditionOccured = false;
				Message<T> resultMessage = new Message<T>();
				if (conditions != null)
				{
					foreach (var condition in conditions)
					{
						if (await condition.Key.Invoke())
						{
							if (resultMessage.Success == true) resultMessage = new Message<T>().AddToMultipleErrorsList(condition.Value);
							else resultMessage.AddToMultipleErrorsList(condition.Value);
							isConditionOccured = true;
						}
					}
				}
				if (!isConditionOccured)
				{
					Method.Invoke();
				}
				return resultMessage;
			}
			catch (Exception ex)
			{
				return new Message<T>(ex.Message +" >>>"+ ex.StackTrace);
			}
		}
	}
}
