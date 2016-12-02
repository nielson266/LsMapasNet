using LsMapasNet.Contexto;
using LsMapasNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LsMapasNet.Controllers
{
    public class ConfiguracaoController : Controller
    {
        // GET: Configuracao

        Backup ObjBackup;

        private LsMapaContext dbMpContex = new LsMapaContext();

        #region ---- BACKUP ----
        public ActionResult Backup()
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

        #endregion

        #region ---- RESTAURAR ----
        public ActionResult Restaurar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Restaurar(HttpPostedFileBase file)
        {
            ObjBackup = new Models.Backup();
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    CriarPastaRestauracao();
                    string path = Path.Combine(Server.MapPath("~/restauracao"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    if (dbMpContex.Database.Exists())
                    {
                        dbMpContex.Database.Delete();
                        try
                        {
                            dbMpContex.Database.Create();
                        }
                        catch(Exception ex)
                        {
                            ObjBackup.RestauraDataBase(path);
                        }

                    }
                    else
                    {
                        dbMpContex.Database.Create();
                        ObjBackup.RestauraDataBase(path);
                    }

                    return RedirectToAction("index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Erro = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Erro = "NÃO FOI SELECIONADO NENHUM ARQUIVO";
            }
            return View();
        }

        public void CriarPastaRestauracao()
        {
            if (!Directory.Exists(Server.MapPath("~/restauracao")))
            {
                Directory.CreateDirectory(Server.MapPath("~/restauracao"));
            }
            else
            {
                Directory.Delete(Server.MapPath("~/restauracao"), true);
                Directory.CreateDirectory(Server.MapPath("~/restauracao"));
            }

        }

        #endregion

        #region ---- DATABASE ERRO - Base não existe ----
        public ActionResult DatabaseErro()
        {
            return View();
        }
        public JsonResult CreateDataBase()
        {
            List<string> ListRetorno = new List<string>();
            try
            {
                dbMpContex.Database.Initialize(true);
                ListRetorno.Add("OK");
                ListRetorno.Add("CRIADO COM SUCESSO");
                return Json(ListRetorno, JsonRequestBehavior.AllowGet);
            }
            catch(Exception Ex)
            {
                ListRetorno.Add("ERRO");
                ListRetorno.Add(Ex.Message.ToString());
                return Json(ListRetorno,JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}