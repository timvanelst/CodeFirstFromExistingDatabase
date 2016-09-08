namespace DAL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollment")]
    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int PersonID { get; set; }

        public int? Grade { get; set; }

        public virtual Course Course { get; set; }

        public virtual Person Person { get; set; }
    }
}
