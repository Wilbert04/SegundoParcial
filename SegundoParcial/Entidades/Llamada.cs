using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Llamada
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey("LLamadaid")]
        public virtual List<LlamadaDetalle> Detalles { get; set; }

        public Llamada()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Detalles = new List<LlamadaDetalle>();
        }
    }
}
