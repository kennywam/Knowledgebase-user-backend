using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace knowledgebase.Data
{
    public class knowledgebase
    {
  
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Product_id")]
        public int ProductId { get; set; }

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
        [BsonElement("faqlabel")]
        public string FaqLabel { get; set; }

        [BsonElement("questions")]
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        [BsonElement("question")]
        public string QuestionText { get; set; }

        [BsonElement("faqanswer")]
        public string FaqAnswer { get; set; }
    }

    public class InfoText
    {
        [BsonElement("infoLabel")]
        public string InfoLabel { get; set; }

        [BsonElement("infoDescr")]
        public string InfoDescription { get; set; }
    }

    public class InfoDoc
    {
        [BsonElement("DocLabel")]
        public string DocLabel { get; set; }

        [BsonElement("DocPath")]
        public string DocPath { get; set; }
    }

}
