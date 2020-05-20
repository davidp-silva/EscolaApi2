using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ds.App.ViewModels
{
    public class AlunoViewModel :PessoaViewModel
    {
        [IgnoreMap]
        public IEnumerable<NotaViewModel> Nota { get; set; }

     //
    }
}
