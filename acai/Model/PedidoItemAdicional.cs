using acai.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acai.Models
{
    
    public class PedidoItemAdicional:BaseModel
    {

        public PedidoItemAdicional()
        {
        }

        public PedidoItemAdicional(int adicionalId, int pedidoItemId)
        {
            Id = 0;
            AdicionalId = adicionalId;
            PedidoItemId = pedidoItemId;
        }

        public PedidoItemAdicional(int id, int adicionalId, int pedidoItemId)
        {
            Id = id;
            AdicionalId = adicionalId;
            PedidoItemId = pedidoItemId;
        }

        [ForeignKey(nameof(Adicional))]
        public int AdicionalId { get; set; }
        public Adicional Adicional { get; set; }
        [ForeignKey(nameof(PedidoItem))]
        public int PedidoItemId { get; set; }
        //public PedidoItem PedidoItem { get; set; }

        public override BaseModel WithId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
