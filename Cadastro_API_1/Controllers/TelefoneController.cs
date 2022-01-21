using AutoMapper;
using Cadastro_API_1.GerenCore.Exceçoes;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.Utilidades;
using Cadastro_API_1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cadastro_API_1.Controllers
{
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITelefoneServico _telefoneServico;

        public TelefoneController(IMapper mapper, ITelefoneServico telefoneServico)
        {
            _mapper = mapper;
            _telefoneServico = telefoneServico;
        }

        [HttpPost]
        [Route("/api/v1/telefone/create")]

        public async Task<IActionResult> Create([FromBody] CreateTelefoneViewModel telefoneViewModel)
        {
            try
            {
                var teleDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);
                var teleCreated = await _telefoneServico.Create(teleDTO);
                return Ok(new ResultadoViewModel
                {
                    Message = "Usuario criado com sucesso!",
                    Success = true,
                    Data = teleCreated
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/telefone/update/{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateTelefoneViewModel telefoneViewModel)
        {
            try
            {
                var telDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);
                var telUpdate = await _telefoneServico.Update(id, telDTO);
                return Ok(new ResultadoViewModel
                {
                    Message = "Telefone criado com sucesso!",
                    Success = true,
                    Data = telUpdate
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/telefone/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _telefoneServico.Remove(id);

                return Ok(new ResultadoViewModel
                {
                    Message = "Telefone removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/telefone/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var tel = await _telefoneServico.Get(id);

                if (tel == null)
                    return Ok(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado.",
                        Success = true,
                        Data = tel
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = tel
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/usuario/get-by-Numero")]
        public async Task<IActionResult> GetByNumero([FromQuery] string numero)
        {
            try
            {
                var tel = await _telefoneServico.SearchByNumero(numero);

                if (tel == null)
                    return Ok(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o numero informado.",
                        Success = true,
                        Data = tel
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = tel
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/usuario/search-by-numero")]
        public async Task<IActionResult> SearchByNumero([FromQuery] string numero)
        {
            try
            {
                var alltel = await _telefoneServico.SearchByNumero(numero);

                if (alltel == null)
                    return Ok(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o numero informado.",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = alltel
                });
            }
            catch (ExcecaoDominio ex)
            {
                return BadRequest(Respostas.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Respostas.ApplicationErrorMessage());
            }
        }
    }
}
