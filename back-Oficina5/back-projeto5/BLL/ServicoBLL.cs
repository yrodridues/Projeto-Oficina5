using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_projeto5.DAL.DTO;
using back_projeto5.DAL.DAO;
using back_projeto5.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace back_projeto5.BLL
{
    public class ServicoBLL : IServicoBLL
    {
        public readonly IServicoDAO _servicoDAO;

        public ServicoBLL(IServicoDAO servicoDAO)
        {
            _servicoDAO = servicoDAO;
        }

        public void AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                _servicoDAO.AdicionarUsuario(usuarioDTO);
            }
            catch (System.Exception ex)
            {
                
                throw new SystemException(ex.Message);
            }
        }

        public void AtualizarUsuario(string Id, UsuarioDTO usuarioDTO)
        {
            bool hasAny = (_servicoDAO.ObterUsuarioPorId(Id)) != null;
            if(!hasAny){ throw new SystemException("Id não encontrado"); }
            try
            {
                _servicoDAO.AtualizarUsuario(Id, usuarioDTO);
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public void DeletarUsuario(string Id)
        {
            bool hasAny = (_servicoDAO.ObterUsuarioPorId(Id)) != null;
            if(!hasAny){ throw new SystemException("Id não encontrado"); }
            try
            {
                _servicoDAO.DeletarUsuario(Id);
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public void EnviarMensagem(MensagemDTO mensagemDTO)
        {
            try
            {
                _servicoDAO.EnviarMensagem(mensagemDTO);
            }
            catch (System.Exception ex)
            {
                
                throw new SystemException(ex.Message);
            }
        }

        public List<UsuarioDTO> ObterTodosUsuarios()
        {
            try
            {
                var listaUsuarios = _servicoDAO.ObterTodosUsuarios();
                return listaUsuarios;
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public UsuarioDTO ObterUsuarioPorId(string Id)
        {
            try
            {
                var usuarios = _servicoDAO.ObterUsuarioPorId(Id);
                return usuarios;
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public List<MensagemDTO> ObterTodasMensagens()
        {
            try
            {
                var listaMensagens = _servicoDAO.ObterTodasMensagens();
                return listaMensagens;
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public List<MensagemDTO> ObterMensagemPorIdPost(string PostId)
        {
            try
            {
                var listaMensagens = _servicoDAO.ObterMensagemPorIdPost(PostId);
                return listaMensagens;
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }

        public List<UsuarioDTO> ObterPostPorIdUsuario(string UserId)
        {
            try
            {
                var listaUsuarios = _servicoDAO.ObterPostPorIdUsuario(UserId);
                return listaUsuarios;
            }
            catch (System.Exception ex)
            {                
                throw new SystemException(ex.Message);
            }
        }
    }
}