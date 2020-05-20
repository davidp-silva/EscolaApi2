using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ds.App.ViewModels
{
    public class PeriodoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        [DisplayName("Período")]
        public string NomePeriodo { get; set; }

        public IEnumerable<NotaViewModel> Nota { get; set; }
    }
}
