using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acai.Context;
using acai.Model;
using acai.Models;



namespace acai.Repository
{
    public class PedidoRepository : BaseRepository<Pedido, DataContext>
    {
        DataContext context;
        public PedidoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void CarregaPedido(Pedido pedido)
        {
            var query = (from p in context.Pedido
                         join pi in context.PedidoItem on p.Id equals pi.PedidoId
                         join t in context.Tamanho on pi.TamanhoId equals t.Id
                         join s in context.Sabor on pi.SaborId equals s.Id
                         join pia in context.PedidoItemAdicional on pi.Id equals pia.PedidoItemId into leftPedidoItemAdicional
                         from lPedidoItemAdicional in leftPedidoItemAdicional.DefaultIfEmpty()
                         join a in context.Adicional on lPedidoItemAdicional.AdicionalId equals a.Id into leftAdicional
                         from lAdicional in leftAdicional.DefaultIfEmpty()
                         where p.Id == pedido.Id
                         select new
                         {
                             sabor = s,
                             tamanho = t,
                             adicional = lAdicional

                         });

            var o = query.ToList();

                   
         
            foreach(var item in pedido.Itens)
            {
                pedido.ValorTotal += item.Tamanho.Preco;
                pedido.TempoTotal += item.Sabor.Tmp + item.Tamanho.Tmp;
                if (item.Adicionais != null)
                {
                    foreach (var adicional in item.Adicionais)
                    {
                        pedido.ValorTotal += adicional.Adicional.Preco;
                        pedido.TempoTotal += adicional.Adicional.Tmp;

                    }
                }
                else
                    item.Adicionais = new List<PedidoItemAdicional>();
                
            }
            
        }
    }
}
