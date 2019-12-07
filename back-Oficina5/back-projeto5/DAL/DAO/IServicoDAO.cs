using back_projeto5.DAL.DTO;
using back_projeto5.DAL.Model;
using System;
using System.Collections.Generic;

namespace back_projeto5.DAL.DAO
{
    public interface IServicoDAO
    {
        List<UsuarioDTO> ObterTodosUsuarios();
        UsuarioDTO ObterUsuarioPorId(string Id);
        List<MensagemDTO> ObterTodasMensagens();
        List<MensagemDTO> ObterMensagemPorIdPost(string PostId);
        List<UsuarioDTO> ObterPostPorIdUsuario(string UserId);

        void AdicionarUsuario(UsuarioDTO usuarioDTO);
        void AtualizarUsuario(string Id,UsuarioDTO usuarioDTO);
        void EnviarMensagem(MensagemDTO mensagemDTO);
        void DeletarUsuario(string Id);
    }
}