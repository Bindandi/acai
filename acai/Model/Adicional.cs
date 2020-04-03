using acai.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace acai.Models
{
    
    public class Adicional:BaseModel
    {

        public Adicional()
        {
        }

        public Adicional(int id, string descricao, TimeSpan tmp, double ml, double preco)
        {
            Id = id;
            Descricao = descricao;
            Tmp = tmp;
            Preco = preco;
        }

        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public TimeSpan Tmp { get; set; }

        public override BaseModel WithId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
