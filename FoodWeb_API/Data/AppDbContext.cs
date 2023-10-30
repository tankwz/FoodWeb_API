﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodWeb_API.Data
{
    public class AppDbContext :IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
