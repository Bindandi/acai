using acai.Model;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acai.Models
{
    
    public class PedidoItem:BaseModel
    {
        public PedidoItem()
        {
        }

        public PedidoItem(int saborId, int tamanhoId, List<PedidoItemAdicional> adicionais)
        {
            Id = 0;
            SaborId = saborId;
            TamanhoId = tamanhoId;
            Adicionais = adicionais;
        }

        public PedidoItem(int id, int saborId, int tamanhoId, List<PedidoItemAdicional> adicionais)
        {
            Id = id;
            SaborId = saborId;
            TamanhoId = tamanhoId;
            Adicionais = adicionais;
        }

        [ForeignKey(nameof(Sabor))]
        public int SaborId { get; set; }
        public Sabor Sabor { get; set; }
        [ForeignKey(nameof(Tamanho))]
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }
        
        public List<PedidoItemAdicional> Adicionais { get; set; }
        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }

        public override BaseModel WithId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
