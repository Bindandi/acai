
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
    public class AdicionalController : Controller
    {
        private static AdicionalRepository _repositoryAdicional;

        public AdicionalController(AdicionalRepository repositoryAdicional)
        {
            _repositoryAdicional = repositoryAdicional;
            
        }           
       
        public async Task<List<Adicional>> GetById(int id)
        {
            Expression<Func<Adicional, bool>> where;

            where = o => o.Id == id;
            List<Adicional> p = await _repositoryAdicional.Get(where);
            return p;
        }
       
    }
}
