using System;

namespace WebApiCRUD.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateInsert { get; set; }
    }
}