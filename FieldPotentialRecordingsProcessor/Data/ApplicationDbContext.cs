using FieldPotentialRecordingsProcessor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FieldPotentialRecordingsProcessor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RecordingSession> RecordingSessions { get; set; }
        public DbSet<RawData> RawDatas { get; set; }
        public DbSet<ProcessedDataSet> ProcessedDataSets { get; set; }
        public DbSet<Rat> Rats { get; set; }
    }
}
