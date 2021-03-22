using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class Timesheet
    {
        [Key]
        [Column("TimesheetID")]
        public int TimesheetId { get; set; }
        [Column("TaskID")]
        public int TaskId { get; set; }
        [Column("EmployeeTaskID")]
        public int EmployeeTaskId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime WorkDate { get; set; }
        [Column(TypeName = "decimal(8, 1)")]
        public decimal HoursWorked { get; set; }

        [ForeignKey(nameof(EmployeeTaskId))]
        [InverseProperty("Timesheets")]
        public virtual EmployeeTask EmployeeTask { get; set; }
    }
}
