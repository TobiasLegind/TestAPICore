using System;

namespace TestAPICore.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
