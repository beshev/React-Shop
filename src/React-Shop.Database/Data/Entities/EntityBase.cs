namespace Data.Entities
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System;

    public class EntityBase
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
