using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{    //3. A "startup.cs" do webservice não tem rota (vem crua)
     //será colocada aqui. Vamos definir a rota para requisição de serviço
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        //7. instanciar a classe
        Cidades cidade = new Cidades();
      
        [HttpGet]
        public IEnumerable<Cidades> Get(){
            return cidade.Listar();
        }
        // //5. neste exemplo, além de requisitar o serviço, será passado um parâmetro [id]
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     //5. neste método, ele retorna uma string/cidade que esta na posição [id]
        //     return new string[]{
        //          "Curitiba","Porto Alegre","Salvador","Belo Horizonte","Bonito","São Paulo",
        //        "Santos","Fortaleza","Ubatuba","Caraguatatuba","São Sebastião"
        //     }[id];


        //4. Exibe os dados como resposta para a aquisição:
        //[HttpGet]
        // public IEnumerable<string> NomeGet(){
        //     return new string[]{
        //         "Curitiba","Porto Alegre","Salvador","Belo Horizonte","Bonito","São Paulo",
        //         "Santos","Fortaleza","Ubatuba","Caraguatatuba","São Sebastião"
        //     };
    }
}


