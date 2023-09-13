using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace knowledgebase.Data
{
    [BsonIgnoreExtraElements]
    public class knowledgebase
    {
  
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("Product_name")]
        public string ProductName { get; set; }

        [BsonElement("Product_description")]
        public string ProductDescription { get; set; }

        [BsonElement("faq")]
        public List<Faq> Faq { get; set; }

        [BsonElement("infoText")]
        public List<InfoText> InfoText { get; set; }

        [BsonElement("infoDoc")]
        public List<InfoDoc> InfoDoc { get; set; }

        

    }

    public class Faq
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("faqlabel")]
        public string FaqLabel { get; set; }

        [BsonElement("questions")]
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("question")]
        public string QuestionText { get; set; }

        [BsonElement("faqanswer")]
        public string FaqAnswer { get; set; }
    }

    public class InfoText
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("infoLabel")]
        public string InfoLabel { get; set; }

        [BsonElement("infoDescr")]
        public string InfoDescription { get; set; }
    }

    public class InfoDoc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("DocLabel")]
        public string DocLabel { get; set; }

        [BsonElement("DocPath")]    
        public string DocPath { get; set; }
    }

    

}
