using AutoMapper;
using Cadastro_API_1.GerenCore.Exceçoes;
using Cadastro_API_1.GerenServicos.DTO;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.Utilidades;
using Cadastro_API_1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_API_1.Controllers
{
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IMapper mapper, IUsuarioServico usuarioServico)
        {
            _mapper = mapper;
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        [Route("/api/v1/usuario/create")]

        public async Task<IActionResult> Create([FromBody] CreateUsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioViewModel);
                var usuarioCreated = await _usuarioServico.Create(usuarioDTO);
                return Ok(new ResultadoViewModel
                {
                    Message = "Usuario criado com sucesso!",
                    Success = true,
                    Data = usuarioCreated
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
        [Route("/api/v1/usuario/update/{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioViewModel);
                var usuarioUpdate = await _usuarioServico.Update(id, usuarioDTO);
                return Ok(new ResultadoViewModel
                {
                    Message = "Usuario criado com sucesso!",
                    Success = true,
                    Data = usuarioUpdate
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
        [Route("/api/v1/usuario/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _usuarioServico.Remove(id);
                
                return Ok(new ResultadoViewModel
                {
                    Message = "Usuario removido com sucesso!",
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
        [Route("/api/v1/usuario/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _usuarioServico.Get(id);

                if(user == null)
                    return Ok(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado.",
                        Success = true,
                        Data = user
                    });

                    return Ok(new ResultadoViewModel
                    {
                        Message = "Usuário encontrado com sucesso!",
                        Success = true,
                        Data = user
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
        [Route("/api/v1/usuario/search-by-nome")]
        public async Task<IActionResult> SearchByNome([FromQuery] string nome)
        {
            try
            {
                var alluser = await _usuarioServico.SearchByNome(nome);

                if (alluser == null)
                    return Ok(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o nome informado.",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = alluser
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
        [Route("/api/v1/usuario/get-by-CPF")]
        public async Task<IActionResult> GetByCPF([FromQuery] string cpf)
        {
            try
            {
                var user = await _usuarioServico.GetByCPF(cpf);

                if (user == null)
                    return NotFound(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o CPF informado.",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
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
        [Route("/api/v1/usuario/usuario-telefones/{id:long}")]
        public async Task<IActionResult> BuscarUsuarioTelefones(long id)
        {
            try
            {
                var usuarioTelefones = await _usuarioServico.BuscarTelefonesUsuario(id);

                if (usuarioTelefones == null)
                    return NotFound(new ResultadoViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o CPF informado.",
                        Success = true,
                        Data = usuarioTelefones
                    });

                return Ok(new ResultadoViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = usuarioTelefones
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
