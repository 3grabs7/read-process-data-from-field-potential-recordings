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

        DbSet<RecordingSession> RecordingSessions { get; set; }
        DbSet<RawData> RawDatas { get; set; }
        DbSet<ProcessedDataSet> ProcessedDataSets { get; set; }
        DbSet<Rat> Rats { get; set; }
    }
}
