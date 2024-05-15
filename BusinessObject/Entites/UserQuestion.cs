using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entites
{
    public class UserQuestion : BaseEntity
    {
        [Column("Uquestion_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public required string Content { get; set; } = default!;

        [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        public string Option_A { get; set; } = null!;
        public string Option_B { get; set; } = null!;
        public string Option_C { get; set; } = null!;
        public string Option_D { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public bool isCorrect { get; set; }
        public string Description { get; set; }

        [MaxLength(450)]
        [ForeignKey(nameof(IdentityUser))] public string UserId { get; set; }
        public virtual IdentityUser User { get; set; } = default!;
        public string Image { get; set; }

        public DateTime Published { get; set; }
    }
}
