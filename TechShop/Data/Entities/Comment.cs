using System;

namespace TechShop.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public DateTime DateOfCreat { get; set; }

        public long ProductID { get; set; }
        public Product Product { get; set; }
    }
}
