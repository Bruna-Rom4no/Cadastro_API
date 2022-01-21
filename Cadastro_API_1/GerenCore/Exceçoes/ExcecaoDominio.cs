using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.GerenCore.Exceçoes
{
    public class ExcecaoDominio : Exception
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public ExcecaoDominio() { }

        public ExcecaoDominio(string message, List<string> erros) : base(message)
        {
            _erros = erros;
        }

        public ExcecaoDominio(string message) : base(message) { }

        public ExcecaoDominio(string message, Exception innerException) : base(message, innerException) { }
    }
}
