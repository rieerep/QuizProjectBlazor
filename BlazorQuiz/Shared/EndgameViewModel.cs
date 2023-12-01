using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorQuiz.Shared
{
    public class EndgameViewModel
    {
        [Required]
        public int Score { get; set; }

        public Guid? PublicId { get; set; }

    }
}
