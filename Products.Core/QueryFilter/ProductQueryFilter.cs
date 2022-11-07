using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.QueryFilter
{
    public class ProductQueryFilter
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Image { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
