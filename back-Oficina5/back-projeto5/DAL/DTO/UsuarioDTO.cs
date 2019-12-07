using System;
using System.Collections.Generic;
using back_projeto5.DAL.Model;

namespace back_projeto5.DAL.DTO
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}