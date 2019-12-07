using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_projeto5.DAL.Model
{
    public class Mensagem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PostId")]
        public string PostId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Body")]
        public string Body { get; set; }
    }
}