using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleLevels = new HashSet<RoleLevel>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(RoleLevel.Role))]
        public virtual ICollection<RoleLevel> RoleLevels { get; set; }
        [InverseProperty(nameof(User.Role))]
        public virtual ICollection<User> Users { get; set; }
    }
}
