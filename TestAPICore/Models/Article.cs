using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPICore.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
