﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;

namespace TMS.Domain.EFMapping
{
  public  class RunStatusMap:EntityTypeConfiguration<TestCaseRunStatus>
    {

      public RunStatusMap()
      {

          HasKey(t => t.ID);

          Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

          Property(t => t.Status);
      }
    }
}
