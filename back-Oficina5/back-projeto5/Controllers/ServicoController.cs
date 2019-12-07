using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using back_projeto5.BLL;
using back_projeto5.DAL.Model;
using back_projeto5.DAL.DTO;

namespace back_projeto5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoBLL _servicoBll;

        public ServicoController(IServicoBLL servicoBll)
        {
            _servicoBll = servicoBll;
        }

        [HttpPost("AdicionarUsuario")]
        public ActionResult<Usuario> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                _servicoBll.AdicionarUsuario(usuarioDTO);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpPut("AtualizarUsuario/{Id}")]
        public ActionResult<Usuario> AtualizarUsuario(string Id, UsuarioDTO usuarioDTO)
        {
            try
            {
                _servicoBll.AtualizarUsuario(Id,usuarioDTO);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpDelete("DeletarUsuario/{Id}")]
        public ActionResult<Usuario> DeletarUsuario(string Id)
        {
            try
            {
                _servicoBll.DeletarUsuario(Id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpPost("EnviarMensagem")]
        public ActionResult<Mensagem> EnviarMensagem(MensagemDTO mensagemDTO)
        {
            try
            {
                _servicoBll.EnviarMensagem(mensagemDTO);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpGet("ObterTodosUsuarios")]
        public ActionResult<List<Usuario>> ObterTodosUsuarios()
        {
            try
            {
                return Ok(_servicoBll.ObterTodosUsuarios());  
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        } 
        
        [HttpGet("ObterUsuarioPorId/{Id}")]
        public ActionResult<Usuario> ObterUsuarioPorId(string Id)
        {
            try
            {
                return Ok(_servicoBll.ObterUsuarioPorId(Id));  
            }
            catch (System.Exception ex)
            {
                
                throw new SystemException(ex.Message);
            }
        }

        [HttpGet("ObterTodasMensagens")]
        public ActionResult<List<Mensagem>> ObterTodasMensagens()
        {
            try
            {
                return Ok(_servicoBll.ObterTodasMensagens());  
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpGet("ObterMensagemPorIdPost/{PostId}")]
        public ActionResult<Mensagem> ObterMensagemPorIdPost(string PostId)
        {
            try
            {
                return Ok(_servicoBll.ObterMensagemPorIdPost(PostId));  
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        [HttpGet("ObterPostPorIdUsuario/{UserId}")]
        public ActionResult<Mensagem> ObterPostPorIdUsuario(string UserId)
        {
            try
            {
                return Ok(_servicoBll.ObterPostPorIdUsuario(UserId));  
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }  
    }
}