using back_projeto5.DAL.Model;
using back_projeto5.DAL.DAO;
using back_projeto5.DAL.DTO;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace back_projeto5.DAL.DAO
{
    public class ServicoDAO : IServicoDAO
    {
        private readonly IMongoContext _context;

        public ServicoDAO(IMongoContext context)
        {
            _context = context;
        }

        public void AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario novoUsuario = new Usuario
            {
                UserId = usuarioDTO.UserId,
                Title = usuarioDTO.Title.ToLower(),
                Body = usuarioDTO.Body.ToLower()
            };
            _context.CollectionUsuario.InsertOne(novoUsuario);
        }

        public void AtualizarUsuario(string Id, UsuarioDTO usuarioDTO)
        {
            Usuario novoUsuario = new Usuario
            {
                UserId = usuarioDTO.UserId,
                Id = Id,
                Title = usuarioDTO.Title.ToLower(),
                Body = usuarioDTO.Body.ToLower()
            };
            _context.CollectionUsuario.ReplaceOne(user => user.Id == Id, novoUsuario);
        }

        public void DeletarUsuario(string Id)
        {
            _context.CollectionUsuario.DeleteOne(user => user.Id == Id);
        }

        public void EnviarMensagem(MensagemDTO mensagemDTO)
        {
            Mensagem novaMensagem = new Mensagem
            {
                PostId = mensagemDTO.PostId,
                Name = mensagemDTO.Name.ToLower(),
                Email = mensagemDTO.Email,
                Body = mensagemDTO.Body.ToLower()
            };
            _context.CollectionMensagem.InsertOne(novaMensagem);
        }

        public List<UsuarioDTO> ObterTodosUsuarios()
        {
            List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            var user = _context.CollectionUsuario.Find<Usuario>(usu => true).ToList();

            foreach (var item in user)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO
                {
                    UserId = item.UserId,
                    Id = item.Id,
                    Title = item.Title,
                    Body = item.Body
                };
                usuarioDTOs.Add(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public UsuarioDTO ObterUsuarioPorId(string Id)
        {
            var user = _context.CollectionUsuario.Find<Usuario>(usu => usu.Id == Id).First();
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                UserId = user.UserId,
                Id = Id,
                Title = user.Title,
                Body = user.Body
            };
            return usuarioDTO;
        }

        public List<MensagemDTO> ObterTodasMensagens()
        {
            List<MensagemDTO> mensagemDTOs = new List<MensagemDTO>();
            var mensage = _context.CollectionMensagem.Find<Mensagem>(mens => true).ToList();

            foreach (var item in mensage)
            {
                MensagemDTO mensagemDTO = new MensagemDTO
                {
                    PostId = item.PostId,
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Body = item.Body
                };
                mensagemDTOs.Add(mensagemDTO);
            }
            return mensagemDTOs;
        }

        public List<MensagemDTO> ObterMensagemPorIdPost(string PostId)
        {
            List<MensagemDTO> mensagemDTOs = new List<MensagemDTO>();
            var mensage = _context.CollectionMensagem.Find<Mensagem>(mens => mens.PostId == PostId).ToList();
            foreach (var item in mensage)
            {
                MensagemDTO mensagemDTO = new MensagemDTO
                {
                    PostId = PostId,
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Body = item.Body
                };
                mensagemDTOs.Add(mensagemDTO);
            }
            return mensagemDTOs;
        }

        public List<UsuarioDTO> ObterPostPorIdUsuario(string UserId)
        {
            List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            var user = _context.CollectionUsuario.Find<Usuario>(usu => usu.UserId == UserId).ToList();
            foreach (var item in user)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO
                {
                    UserId = UserId,
                    Id = item.Id,
                    Title = item.Title,
                    Body = item.Body
                };
                usuarioDTOs.Add(usuarioDTO);
            }
            return usuarioDTOs;
        }
    }
}