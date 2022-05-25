using System;
using System.Collections.Generic;

#nullable disable

namespace taller_be.Models
{
    public partial class ItemTask
    {
        public decimal Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? Caduca { get; set; }
        public string Visible { get; set; }
        public string Terminada { get; set; }
        public decimal? Lista { get; set; }

        public virtual TaskList ListaNavigation { get; set; }
    }
}
