using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ProjetoWebApi;

namespace ProjetoWebApi.Models
{
    [Table("Marca")]
    public class MarcaModel
    {
        [Column("Id"),Key] public int Id { get; set; }
        [Column("Nome"),Required] public string Nome { get; set; }
        public ICollection<CarroModel> CarrosColecao { get; set; }
    }
}