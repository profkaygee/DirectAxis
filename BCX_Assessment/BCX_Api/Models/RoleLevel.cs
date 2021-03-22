using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BCX_Api.Models
{
    public partial class RoleLevel
    {
        [Key]
        [Column("LevelID")]
        public int LevelId { get; set; }
        [Required]
        [StringLength(50)]
        public string LevelName { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal RatePerHour { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RoleLevels")]
        public virtual Role Role { get; set; }
    }
}
