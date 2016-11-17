using LsMapasNet.Contexto;
using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LsMapasNet.Controllers
{
    public class SurdoController : Controller
    {
        private LsMapaContext dbMpContex = new LsMapaContext();
        // GET: Surdo
        public ActionResult Index()
        {
            //var listSurdo = dbMpContex.Surdo.ToList();
            try
            {
                dbMpContex.Surdo.ToList();
                LerArquivo();
                return View(dbMpContex.Surdo.ToList());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // GET: Surdo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Surdo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surdo/Create
        [HttpPost]
        public ActionResult Create(Surdo collection)
        {
            try
            {
                // TODO: Add insert logic here
                dbMpContex.Surdo.Add(collection);
                dbMpContex.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Surdo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Surdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Surdo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Surdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        void LerArquivo()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file =  new System.IO.StreamReader(@"C:\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptbanco.txt");


            while ((line = file.ReadLine()) != null)
            {
                Surdo ObjSurdo = new Surdo();

                string[] surdolinha = line.Split('|');


                ObjSurdo.id = Convert.ToInt32(surdolinha[1]);
                ObjSurdo.nome = surdolinha[2];
                ObjSurdo.endereco = surdolinha[3];
                ObjSurdo.perimetro = surdolinha[4];
                ObjSurdo.classe = surdolinha[5];
                ObjSurdo.latitude = surdolinha[6];
                ObjSurdo.longitude = surdolinha[7];
                ObjSurdo.bairro = surdolinha[8];
                ObjSurdo.status = surdolinha[9];

                dbMpContex.Surdo.Add(ObjSurdo);
                dbMpContex.SaveChanges();

                counter++;
            }




        }
    }
}
