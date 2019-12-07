using MongoDB.Driver;

namespace back_projeto5.DAL.Model
{
    public interface IMongoContext
    {
        IMongoCollection<Usuario> CollectionUsuario { get; }        
        IMongoCollection<Mensagem> CollectionMensagem { get; }        
    }
}