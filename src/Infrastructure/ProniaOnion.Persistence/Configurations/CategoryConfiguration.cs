﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Configurations
{
    internal class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(c=>c.Name).IsUnique();
        }
    }
}