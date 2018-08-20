using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Exceptions;
using VMStarter.Shared.Models;

namespace VMStarter.Demo.Domain.Clients
{
    public class ClientDomain : IAggregateRoot
    {
        public ClientDomain(string firstName, string lastName, string address, int id=0)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new DomainPropertyNotAllowedNullException<ClientDomain>("firstName");
            if (string.IsNullOrWhiteSpace(lastName)) throw new DomainPropertyNotAllowedNullException<ClientDomain>("lastName");
            if (string.IsNullOrWhiteSpace(address)) throw new DomainPropertyNotAllowedNullException<ClientDomain>("address");
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
    }
}
