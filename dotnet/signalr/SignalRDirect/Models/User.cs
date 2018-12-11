using System.Collections.Generic;

namespace SignalRDirect
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Call> Calls { get; set; }
    }
}