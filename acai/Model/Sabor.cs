using acai.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acai.Models
{
    
    public class Sabor: BaseModel
    {
        public Sabor()
        {
        }

        public Sabor(int id, string descricao, TimeSpan tmp)
        {
            Id = id;
            Descricao = descricao;
            Tmp = tmp;
        }

        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        [Required]
        public TimeSpan Tmp { get; set; }

        public override BaseModel WithId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
