using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entites
{
    public class Tracking : BaseEntity
    {
        [Column("tracking_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [ForeignKey(nameof(UserQuestion))] public string questionId { get; set; }
        public virtual UserQuestion UserQuestion { get; set; } = default!;
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public string Answers { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
