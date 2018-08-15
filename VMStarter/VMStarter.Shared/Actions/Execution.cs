using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Shared.Actions
{
    public class Execution<T>
    {
		private Dictionary<Func<bool>, string> conditions { get; set; }
		private Action Method { get; set; }

		public Execution(Action action)
		{
			Method = action;
			conditions = null;

		}

		public Execution(Action method, Func<bool> cond, string errorMessage)
		{
			if (conditions == null)
			{
				conditions = new Dictionary<Func<bool>, string>();
				conditions.Add(cond, errorMessage);
			}
			Method = method;
		}

		public Execution<T> AddCondition(Func<bool> cond, string errorMessage)
		{
			conditions.Add(cond, errorMessage);
			return this;
		}

		public Message<T> Execute()
		{
			try
			{
				bool isConditionOccured = false;
				Message<T> resultMessage = new Message<T>();
				if (conditions != null)
				{
					foreach (var condition in conditions)
					{
						if (condition.Key.Invoke())
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
				return new Message<T>(ex.Message+ " >>>"+ ex.StackTrace);
			}
		}
	}
}
