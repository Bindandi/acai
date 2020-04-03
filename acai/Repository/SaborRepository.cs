using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acai.Context;
using acai.Model;
using acai.Models;



namespace acai.Repository
{
    public class SaborRepository : BaseRepository<Sabor, DataContext>
    {
        
        public SaborRepository(DataContext context) : base(context)
        {
            
        }
    }
}
