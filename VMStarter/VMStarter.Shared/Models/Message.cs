using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Models
{
    public class Message<T>
    {
		public bool Success { get; private set; }
		public string Text { get { return string.Join(", ", Errors.ToArray()); } }
        public List<string> Errors { get; set; }
		public T ResponseObject { get; private set; }

		public Message()
		{
			Success = true;
			ResponseObject = default(T);
		}

		public Message(string errorMessage)
		{
			Success = false;
            Errors = new List<string>();
            Errors.Add(errorMessage);
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
            Errors = new List<string>();
            Errors.Add(errorMessage);
			ResponseObject = responseMessage;
		}

        public Message<T> AddNewMessage(string message)
        {
            Errors.Add(message);
            return this;
        }

		public Message<T> AddToMultipleErrorsList(string errorMessage){
			if (Success == true) Success = false;
			Errors.Add(errorMessage);
			return this;
		}
	}
}
