using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class LlamadaDetalle
    {
        
        private string text;

        [Key]
        public int Id { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadaDetalle(int id, string problema, string solucion)
        {
            Id = id;
            Problema = problema;
            Solucion = solucion;
        }

        public LlamadaDetalle(int id, int v, string problema)
        {
            
        }

        public LlamadaDetalle(int id, int v, string problema, string text) : this(id, v, problema)
        {
            this.text = text;
        }
    }
}
