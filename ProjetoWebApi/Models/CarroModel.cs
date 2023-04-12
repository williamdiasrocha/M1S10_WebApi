using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebApi;

namespace ProjetoWebApi.Models
{
    [Table("Carros")]
    public class CarroModel
    {
        [Column("Id"),Key] public int Id { get; set; }
        [Column("Nome"), Required] public string Nome { get; set; }
        [Column("DataLocacao")] public DateTime DataLocacao { get; set; }
        [Column("Id_Marca"), ForeignKey("MarcaModel")] public int IdMarca { get; set; }
        public MarcaModel Marca { get; set; }
        
    }
}