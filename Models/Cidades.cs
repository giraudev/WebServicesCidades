using System.Collections.Generic;

namespace WebServicesCidades.Models
{
    public class Cidades
    {
        //6. criar atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        // public List<Cidades> Listar()
        // {
        //     return new List<Cidades>(){
        //         new Cidades{Id=10,Nome="Belo Horizonte",Estado="MG",Habitantes=552},
        //         new Cidades{Id=11,Nome="Bertioga",Estado="SP",Habitantes=552},
        //         new Cidades{Id=12,Nome="Marília",Estado="SP",Habitantes=552},
        //         new Cidades{Id=13,Nome="Itu",Estado="SP",Habitantes=552},
        //         new Cidades{Id=14,Nome="Búzios",Estado="RJ",Habitantes=552},
        //         new Cidades{Id=15,Nome="Santos",Estado="SP",Habitantes=552},
        //         new Cidades{Id=16,Nome="Salvador",Estado="BA",Habitantes=552},
        //         new Cidades{Id=17,Nome="Porto Seguro",Estado="BA",Habitantes=552},
        //     };
        // }
    }
}