
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
    public class SaborController : Controller
    {
        private static SaborRepository _repositorySabor;
        public SaborController(SaborRepository repositorySabor)
        {
            _repositorySabor = repositorySabor;
            
        }           
       
        public async Task<List<Sabor>> GetById(int id)
        {
            Expression<Func<Sabor, bool>> where;

            where = o => o.Id == id;
            List<Sabor> p = await _repositorySabor.Get(where,true,1);
            return p;
        }
       
    }
}
