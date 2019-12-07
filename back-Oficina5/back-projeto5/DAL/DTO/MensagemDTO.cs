using System;
using System.Collections.Generic;
using back_projeto5.DAL.Model;

namespace back_projeto5.DAL.DTO
{
    public class MensagemDTO
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}