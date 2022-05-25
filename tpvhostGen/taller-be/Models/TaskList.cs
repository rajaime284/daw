using System;
using System.Collections.Generic;

#nullable disable

namespace taller_be.Models
{
    public partial class TaskList
    {
        public TaskList()
        {
            ItemTasks = new HashSet<ItemTask>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Visible { get; set; }
        public string Color { get; set; }

        public virtual ICollection<ItemTask> ItemTasks { get; set; }
    }
}
