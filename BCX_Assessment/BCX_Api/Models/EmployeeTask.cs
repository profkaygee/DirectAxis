using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class EmployeeTask
    {
        public EmployeeTask()
        {
            Timesheets = new HashSet<Timesheet>();
        }

        [Key]
        [Column("EmployeeTaskID")]
        public int EmployeeTaskId { get; set; }
        [Column("TaskID")]
        public int TaskId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }

        [ForeignKey(nameof(TaskId))]
        [InverseProperty("EmployeeTasks")]
        public virtual Task Task { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("EmployeeTasks")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Timesheet.EmployeeTask))]
        public virtual ICollection<Timesheet> Timesheets { get; set; }
    }
}
