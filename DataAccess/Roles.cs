using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class GeoTycoonDbcontext
    {
        private static partial class Default
        {
            public static readonly IdentityRole[] Roles =
            [
                new IdentityRole("Administrator"),
                new IdentityRole("Teacher"),
                new IdentityRole("Pending"),
                new IdentityRole("Student")
            ];
        }
    }
}
