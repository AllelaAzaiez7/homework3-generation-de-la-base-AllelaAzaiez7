using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructures.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //renommer la table associative
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(t => t.ToTable("VolsPassenger"));
            builder.HasOne(f => f.Plane)
                .WithMany(p => p.Flights)
                // .HasForeignKey(f=>f.PlaneFk)
                .OnDelete(DeleteBehavior.Cascade);
            //<==> [foreignKey]
        }
    }
}