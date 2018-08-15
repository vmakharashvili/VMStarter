using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Models
{
    public class Message<T>
    {
		public bool Success { get; private set; }
		public string Text { get; private set; }
		public List<string> MultipleErrors { get; set; }
		public T ResponseObject { get; private set; }

		public Message()
		{
			Success = true;
			ResponseObject = default(T);
		}

		public Message(string errorMessage)
		{
			Success = false;
			Text = errorMessage;
			ResponseObject = default(T);
		}

		public Message(T responseObject)
		{
			Success = true;
			ResponseObject = responseObject;
		}

		public Message(string errorMessage, T responseMessage)
		{
			Success = false;
			Text = errorMessage;
			ResponseObject = responseMessage;
		}

		public Message<T> AddToMultipleErrorsList(string errorMessage){
			if (Success == true) Success = false;
			MultipleErrors.Add(errorMessage);
			return this;
		}
	}
}
