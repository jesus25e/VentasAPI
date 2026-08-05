using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Models
{
    public class PaginationRequest
    {
        private const int MaxPageSize = 100;
        public int Page { get; init; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;

            init => _pageSize =
                value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
