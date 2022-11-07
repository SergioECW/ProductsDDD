using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Image { get; set; }
    }
}
