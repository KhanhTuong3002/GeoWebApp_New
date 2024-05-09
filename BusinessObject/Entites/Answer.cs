using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entites
{
    public class Answer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id {  get; set; }
        [ForeignKey(nameof(Question))] public int QuestionId { get; set; }
        public string Answers { get; set; }
        public string? Description { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual Question Question { get; set; } = default!;

    }
}
