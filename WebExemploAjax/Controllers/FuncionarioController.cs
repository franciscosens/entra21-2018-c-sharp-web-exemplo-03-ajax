using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Model;
using Newtonsoft.Json;
using Repository;

namespace WebExemploAjax.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            List<Funcionario> funcionarios = new FuncionarioRepositorio().ObterTodos();
            ViewBag.Funcionarios = funcionarios;
            return View();
        }
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Funcionario funcionario)
        {
            int id = new FuncionarioRepositorio().Inserir(funcionario);
            return Content(JsonConvert.SerializeObject(new {id = id}));

        }


        [HttpGet]
        public ActionResult ObterTodosPorJSON()
        {
            List<Funcionario> funcionarios = new FuncionarioRepositorio().ObterTodos();
            return Content(JsonConvert.SerializeObject(funcionarios));
        }
        [HttpGet]
        public ActionResult CadastroModal()
        {
            return View();
        }
    }
}