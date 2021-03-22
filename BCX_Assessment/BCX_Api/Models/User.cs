using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class User
    {
        public User()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Required]
        [StringLength(255)]
        public string ProfilePicture { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(EmployeeTask.User))]
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
