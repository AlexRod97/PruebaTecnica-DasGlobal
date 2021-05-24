using Dapper;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Opcion", 1);
            param.Add("@SucursalID", null);
            param.Add("@EmpresaID", null);
            param.Add("@Nombre", null);
            param.Add("@Direccion", null);
            param.Add("@Telefono", null);

            return View(DapperORM.ReturnList<SucursalModel>("usp_Sucursal", param));
        }

        [HttpPost]
        public ActionResult Edit(SucursalModel sucursalModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Opcion", 2);

            param.Add("@SucursalID", sucursalModel.sucursalID);
            param.Add("EmpresaID", sucursalModel.empresaID);
            param.Add("@Nombre", sucursalModel.nombre);
            param.Add("@Direccion", sucursalModel.direccion);
            param.Add("@Telefono", sucursalModel.telefono);

            DapperORM.ExecuteWithoutReturn("usp_Sucursal", param);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Opcion", 2);
            param.Add("@SucursalID", id);

            param.Add("@EmpresaID", null);
            param.Add("@Nombre", null);
            param.Add("@Direccion", null);
            param.Add("@Telefono", null);

            DapperORM.ExecuteWithoutReturn("usp_Sucursal", param);

            return RedirectToAction("Index");
        }


    }
}