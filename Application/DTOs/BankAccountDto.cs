using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class BankAccountDto
    {
        public string Name { get; set; }
        public long AccountNumber { get; set; }
        public float Balance { get; set; }
    }
}