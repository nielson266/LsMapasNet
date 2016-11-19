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
        public ActionResult Index(string SearchSurdo)
        {
            //var listSurdo = dbMpContex.Surdo.ToList();
            try
            {
                var listsurdo = dbMpContex.Surdo.ToList();

                if (!string.IsNullOrEmpty(SearchSurdo))
                    listsurdo = listsurdo.Where(s => s.nome.Contains(SearchSurdo)).ToList();


                    //LerArquivo();
                    return View(listsurdo);
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
            List<SelectListItem> ListStatus = new List<SelectListItem>();
            ListStatus.Add(new SelectListItem
            {
                Text = "Ativo", Value = "A"
            });
            ListStatus.Add(new SelectListItem
            {
                Text = "Mundou-se",
                Value = "M"
            });
            ListStatus.Add(new SelectListItem
            {
                Text = "Não Visitar",
                Value = "N"
            });

            ViewBag.ListStatus = ListStatus;

            return View(dbMpContex.Surdo.Where(s=> s.id == id).First());
        }

        // POST: Surdo/Edit/5
        [HttpPost]
        public ActionResult Edit(Surdo ObjSurdo, string ListStatus)
        {
            try
            {
                ObjSurdo.status = ListStatus;
                dbMpContex.Surdo.Add(ObjSurdo);
                dbMpContex.SaveChanges();

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
            System.IO.StreamReader file =  new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptSurdo.txt");


            while ((line = file.ReadLine()) != null)
            {
                Surdo ObjSurdo = new Surdo();

                string[] surdolinha = line.Split('|');


                ObjSurdo.id = Convert.ToInt32(surdolinha[1]);

                if(Convert.ToInt32(surdolinha[1]) == 279)
                    counter++;
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


            counter++;

        }
    }
}
