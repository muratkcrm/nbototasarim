using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
    public class UserApiContext:DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options) : base(options)
        {

        }
    }
}
