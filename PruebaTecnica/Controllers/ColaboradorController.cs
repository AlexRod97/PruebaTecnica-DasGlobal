using Dapper;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Opcion", 1);
            param.Add("@Nombre", null);
            param.Add("@Cui", null);

            return View(DapperORM.ReturnList<ColaboradorModel>("usp_Colaborador", param));
        }


    }
}