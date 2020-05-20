using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.App.ViewModels
{
    public class DisciplinaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Disciplina")]
        public string NomeDisciplina { get; set; }

        public IEnumerable<NotaViewModel> Nota { get; set; }

        //public IEnumerable<TurmaDisciplina> TurmasDisciplinas { get; set; }

        //public IEnumerable<DisciplinaProfessor> DisciplinaProfessores { get; set; }
    }
}
