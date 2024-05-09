using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entites
{
    public class Question : BaseEntity
    {
        [Column("question_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string Image { get; set; }
        public required string Content { get; set; } = default!;
        public DateTimeOffset? Published { get; set; }
        public virtual Tracking Tracking { get; set; } = default!;


    }
}
