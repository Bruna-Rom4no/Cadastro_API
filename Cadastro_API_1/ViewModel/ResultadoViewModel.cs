using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.ViewModel
{
    public class ResultadoViewModel
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public dynamic Data { get; set; }
    }
}
