using System;

namespace Domain
{
    public class Administrator 
    {
        public Guid Id { get; set; }
        public AppUser AppUser { get; set; }
    }
}