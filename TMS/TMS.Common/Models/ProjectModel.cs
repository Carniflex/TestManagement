using System;
using System.Collections.Generic;


namespace TMS.Common.Models
{
   public class ProjectModel:BaseEntityModel
    {

      public string ProjectName { get; set; }

      public UserModel User { get; set; }

      public int UserId { get; set; }

      public IEnumerable<ProjectVersionModel> ProjectVersions { get; set; }

   }
}
