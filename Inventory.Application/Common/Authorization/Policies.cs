using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Authorization
{
    public class Policies
    {
        public const string AdminOnly = "AdminOnly";
        public const string ManagerOnly = "ManagerOnly";
        public const string EmployeeOnly = "EmployeeOnly";
    }
}
