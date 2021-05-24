using Dapper;
using Newtonsoft.Json;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;

namespace PruebaTecnica.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Opcion", 1);
            param.Add("@Nombre", null);
            param.Add("@Pais", null);


            return View(DapperORM.ReturnList<EmpresaModel>("usp_Empresa", param));
        }
               
        public ActionResult uploadJson()
        {          

            return View();
        }


        [HttpPost]
        public ActionResult upload(HttpPostedFileBase json)
        {

            if(!json.FileName.EndsWith(".json"))
            {
                ViewBag.errmsg = "Only json files allowed"; 
            }
            else
            {
                json.SaveAs(Server.MapPath("~/empfolder/" + Path.GetFileName(json.FileName)));
                StreamReader reader = new StreamReader(Server.MapPath("~/empfolder/" + Path.GetFileName(json.FileName)));
                string jsonData = reader.ReadToEnd();


                var modelEmpresa = JsonConvert.DeserializeObject<empresa>(jsonData);
                JArray sucursal = (JArray)modelEmpresa.Singles.ElementAt(2).Value;

                foreach (var item in sucursal)
                {
                    var modelSucursal = JsonConvert.DeserializeObject<sucursal>(item.ToString());
                }
                                   

                ViewBag.Message = "Selected " + Path.GetFileName(json.FileName) + "File is saved successfully";
            }            

            return RedirectToAction("Index");
        }
    }
}