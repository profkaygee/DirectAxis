using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class Task
    {
        public Task()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        [Column("TaskID")]
        public int TaskId { get; set; }
        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }
        public int MaxDuration { get; set; }

        [InverseProperty(nameof(EmployeeTask.Task))]
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
