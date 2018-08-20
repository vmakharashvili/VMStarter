using System;
using System.Collections.Generic;
using System.Text;
using VMStarter.Shared.Models;

namespace VMStarter.Demo.DAL.Models
{
    public class Client : IDatabase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
