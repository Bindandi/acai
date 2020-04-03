
using acai.Context;
using acai.Model;
using acai.Models;
using acai.Repository;
using acai.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace acai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private static PedidoRepository _repositoryPedido;
        
        private SaborController controllerSabor;
        private TamanhoController controllerTamanho;
        private AdicionalController controllerAdicional;

        public PedidoController(PedidoRepository repositoryPedido, SaborRepository repositorySabor, TamanhoRepository repositoryTamanho, AdicionalRepository repositoryAdicional)
        {
            _repositoryPedido = repositoryPedido;
            
            controllerSabor = new SaborController(repositorySabor);
            controllerTamanho = new TamanhoController(repositoryTamanho);
            controllerAdicional = new AdicionalController(repositoryAdicional);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pedido>> Insert(Pedido pedido)
        {
            await validarModel(pedido);
            await InserirPedido(pedido);
           
            return pedido;

        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return "ok";
        }

        public async Task InserirPedido(Pedido obj)
        {
            await _repositoryPedido.AddAsync(obj);
            await _repositoryPedido.SaveChangesAsync();
            
            _repositoryPedido.CarregaPedido(obj);
            await _repositoryPedido.UpdateAsync(obj);
            await _repositoryPedido.SaveChangesAsync();
        }

        
       
        public static async Task<List<Pedido>> GetById(int id)
        {
            Expression<Func<Pedido, bool>> where = o => o.Id == id;
            List<Pedido> p = await _repositoryPedido.Get(where);
            return p;
        }
        
        public async Task validarModel(Pedido pedido)
        {
            
            ValidarItemUnico(pedido);
            await ValidarSabor(pedido.Itens[0].SaborId);
            await ValidarTamanho(pedido.Itens[0].TamanhoId);
            foreach(var adicional in pedido.Itens[0].Adicionais)
            {
                await ValidarAdicional(adicional.AdicionalId);
            }   
            
        }

        private void ValidarItemUnico(Pedido pedido)
        {
            if (pedido.Itens == null || pedido.Itens.Count > 1)
                throw new BusinessException("O pedido só pode ter um unico açai.");       
        }
        private async Task ValidarSabor(int id)
        {
            
            var s = await controllerSabor.GetById(id);
            if (s.Count == 0)
                throw new BusinessExceptionExists(nameof(Sabor), "id", false);
        }
        private async Task ValidarTamanho(int id)
        {
            var t = await controllerTamanho.GetById(id);
            if (t.Count == 0)
                throw new BusinessExceptionExists(nameof(Tamanho), "id", false);
        }
        private async Task ValidarAdicional(int id)
        {
            var a = await controllerAdicional.GetById(id);
            if (a.Count == 0)
                throw new BusinessExceptionExists(nameof(Adicional), "id", false);
        }
    }
}
