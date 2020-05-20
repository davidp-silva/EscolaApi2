using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.App.ViewModels
{
    public class NotaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [DisplayName("Nota")]
        public decimal ValorNota { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Disciplina")]
        public Guid DisciplinaId { get; set; }

        public string NomeDisciplina { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Período")]
        public Guid PeriodoId { get; set; }

        public string NomePeriodo { get; set; }
        

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Aluno")]
        public Guid AlunoId { get; set; }

        public string NomeAluno { get; set; }

    }
}
