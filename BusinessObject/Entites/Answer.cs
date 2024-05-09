using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entites
{
    public class Answer : BaseEntity
    {
        [ForeignKey(nameof(Question))] public string QuestionId { get; set; }
        public string Answers { get; set; }
        public string? Description { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual Question Question { get; set; } = default!;

    }
}
