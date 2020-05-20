using System.Collections;
using System.Collections.Generic;

namespace Ds.Business.Models
{
    public class Disciplina : Entity
    {
        public string NomeDisciplina { get; set; }

        public Diario Diario { get; set; }

        public IEnumerable< Nota> Nota { get; set; }

        public IEnumerable<TurmaDisciplina> TurmasDisciplinas { get; set; }

        public IEnumerable<DisciplinaProfessor> DisciplinaProfessores { get; set; }
    }
}