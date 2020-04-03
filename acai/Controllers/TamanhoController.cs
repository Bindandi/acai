
using acai.Context;
using acai.Model;
using acai.Models;
using acai.Repository;
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
    public class TamanhoController : Controller
    {
        private static TamanhoRepository _repositoryTamanho;
        public TamanhoController(TamanhoRepository repositoryTamanho)
        {
            _repositoryTamanho = repositoryTamanho;
            
        }           
       
        public async Task<List<Tamanho>> GetById(int id)
        {
            Expression<Func<Tamanho, bool>> where;
            where = o => o.Id == id;
            List<Tamanho> p = await _repositoryTamanho.Get(where);
            return p;
        }
       
    }
}
