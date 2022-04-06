using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApi.Models;

namespace RestApi.Configuration
{
    public class JobEfConfiguration: IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(e => e.Id).HasName("Job_pk");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).HasMaxLength(40).IsRequired();

            var jobs = new List<Job>();
            jobs.Add(new Job {Id = 1, Name = "Junior Developer"});
            jobs.Add(new Job {Id = 2, Name = "Mid Developer"});
            jobs.Add(new Job {Id = 3, Name = "Senior Developer"});

            builder.HasData(jobs);
        }
    }
}