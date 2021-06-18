using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("Estimates")]
    public class Estimates
    {
        [Column("State")]
        public int State { get; set; }
        [Column("Districts")]
        public int Districts { get; set; }
        [Column("EstimatesPopulation")]
        public double EstimatesPopulation { get; set; }
        [Column("EstimatesHouseholds")]
        public double EstimatesHouseholds { get; set; }
    }
}
