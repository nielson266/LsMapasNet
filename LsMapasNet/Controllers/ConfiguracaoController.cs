using LsMapasNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LsMapasNet.Controllers
{
    public class ConfiguracaoController : Controller
    {
        // GET: Configuracao

        Backup ObjBackup;
        public ActionResult Backup()
        {
            return View();
        }
        public ActionResult Restaurar()
        {
            return View();
        }

        public JsonResult BackupJson()
        {
            ObjBackup = new Models.Backup();
            string patharquivo = string.Empty;
            List<string> objRet = new List<string>();

            if (ObjBackup.BackupDataBase(out patharquivo))
            {
                objRet.Add("OK");
                objRet.Add(patharquivo);


                return Json(objRet, JsonRequestBehavior.AllowGet);
            }
            else
            {
                objRet.Add("Erro");
                return Json(objRet, JsonRequestBehavior.AllowGet);
            }
        }
        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Backups\backup.sql");
            string fileName = "backup.sql";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}