﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);


            builder.HasData(
           new Product
           {
               Id = 1,
               Name = "Caderno",
               Description = "Caderno Espiral Capa de Surf",
               Price = 9.45m
           },
           new Product
           {
               Id = 2,
               Name = "Borracha",
               Description = "Borracha Branca pequena",
               Price = 3.23m
           },
           new Product
           {
               Id = 3,
               Name = "Estojo",
               Description = "Estojo de pano",
               Price = 5.56m
           }

           );

        }

    }
}
