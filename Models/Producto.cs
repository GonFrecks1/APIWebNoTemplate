using System;

namespace WebApiCRUD.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateInsert { get; set; }
        public Decimal Price { get; set; }
        public bool Active { get; set; }
    }
}