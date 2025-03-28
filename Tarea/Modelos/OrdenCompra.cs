﻿using System.ComponentModel.DataAnnotations;

namespace Tarea.Modelos
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        [Required]
        public string Cliente { get; set; } = string.Empty;


        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;


        public decimal Total { get; set; }

        public List<OrdenProducto> Productos { get; set; } = new();
    }
}


