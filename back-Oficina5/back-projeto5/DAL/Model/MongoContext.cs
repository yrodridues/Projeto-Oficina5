using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace back_projeto5.DAL.Model
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Configuracoes> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Usuario> CollectionUsuario => _db.GetCollection<Usuario>("Usuario");
        public IMongoCollection<Mensagem> CollectionMensagem => _db.GetCollection<Mensagem>("Mensagem");
    }
}