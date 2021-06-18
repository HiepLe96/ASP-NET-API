using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    [Table("Actuals")]
    public class Actuals
    {
        [Column("State")]
        public int State { get; set; }
        [Column("ActualPopulation")]
        public double ActualPopulation { get; set; }
        [Column("ActualHouseholds")]
        public double ActualHouseholds { get; set; }
    }
}
