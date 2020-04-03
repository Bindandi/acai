using acai.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acai.Models
{
    
    public class Pedido:BaseModel
    {
        public Pedido()
        {
        }

        public Pedido(List<PedidoItem> itens, double valorTotal, TimeSpan tempoTotal)
        {
            Id = 0;
            Itens = itens;
            ValorTotal = valorTotal;
            TempoTotal = tempoTotal;
        }

        public Pedido(int id, List<PedidoItem> itens, double valorTotal, TimeSpan tempoTotal)
        {
            Id = id;
            Itens = itens;
            ValorTotal = valorTotal;
            TempoTotal = tempoTotal;
        }
        [Required]
        public double ValorTotal { get; set; }
        [Required]
        public TimeSpan TempoTotal { get; set; }

        public List<PedidoItem> Itens { get; set; }

        public override BaseModel WithId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
