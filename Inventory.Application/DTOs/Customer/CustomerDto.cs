using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Customer
{
    public class CustomerDto
    {
        public string FullName { get; init; } = string.Empty;
        public int Dni { get; init; }
        public string Email { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;

    }
}
