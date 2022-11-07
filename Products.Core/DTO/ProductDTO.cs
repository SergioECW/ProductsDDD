using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Image { get; set; }
    }
}
