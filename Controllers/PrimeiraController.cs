using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers
{    //3. A "startup.cs" do webservice não tem rota (vem crua)
     //será colocada aqui. Vamos definir a rota para requisição de serviço
    [Route("api/[controller]")]
    public class PrimeiraController : Controller
    {
        //7. instanciar a classe
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();

        [HttpGet]
        public IEnumerable<Cidades> Get()
        {
            return dao.Listar();
        }

        //__ancoragem do  POst
        [HttpGet("{id}", Name = "CidadeAtual")]
        public Cidades GetCid(int id)
        {
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        //não precisaria ser IActionResult, poderia ser void
        //IActionResult vamos cadastrar e fazer um requisição Get, para ver o que foi cadastrado
        //FromBody é o tipo de dado que vc envia, só nao será enviado o id pois é automatico
        public IActionResult Post([FromBody] Cidades cidades)
        {
            dao.Cadastro(cidades);
            //__criando ponto de ancoragem, após ele cadastrar os dados
            //este item é válido somente se quiser saber oq foi cadastrado
            return CreatedAtRoute("CidadeAtual", new { id = cidades.Id }, cidades);

        }

         [HttpPut]
        public IActionResult Editar([FromBody] Cidades cidade)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    dao.Editar(cidade);
                    return Ok(cidade);
                }

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                
                return BadRequest(allErrors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {

            try
            {
                dao.Excluir(id);
                return Ok(id);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        /*5. neste exemplo, além de requisitar o serviço, será passado um parâmetro [id]
         [HttpGet("{id}")]
         public string Get(int id)
         {
        5. neste método, ele retorna uma string/cidade que esta na posição [id]
             return new string[]{
                  "Curitiba","Porto Alegre","Salvador","Belo Horizonte","Bonito","São Paulo",
                "Santos","Fortaleza","Ubatuba","Caraguatatuba","São Sebastião"
             }[id];


        4. Exibe os dados como resposta para a aquisição:
        [HttpGet]
         public IEnumerable<string> NomeGet(){
             return new string[]{
                 "Curitiba","Porto Alegre","Salvador","Belo Horizonte","Bonito","São Paulo",
                 "Santos","Fortaleza","Ubatuba","Caraguatatuba","São Sebastião"
             };*/


    }
}


