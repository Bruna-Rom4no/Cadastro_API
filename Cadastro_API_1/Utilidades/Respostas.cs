using Cadastro_API_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.Utilidades
{
    public class Respostas
    {
        public static ResultadoViewModel ApplicationErrorMessage()
        {
            return new ResultadoViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static ResultadoViewModel DomainErrorMessage(string message)
        {
            return new ResultadoViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultadoViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> erros)
        {
            return new ResultadoViewModel
            {
                Message = message,
                Success = false,
                Data = erros
            };
        }

        public static ResultadoViewModel UnauthorizedErrorMessage()
        {
            return new ResultadoViewModel
            {
                Message = "Algo esta errado, por favor revise!",
                Success = false,
                Data = null
            };
        }
    }
}
