using System;

namespace Domain
{
    public class UserHistory
    {
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestMethod { get; set; }
        public string Operation { get; set; }
    }
}