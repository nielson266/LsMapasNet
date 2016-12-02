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
        List<Surdo> ObjList;

        #region ------- INDEX -------
        // GET: Surdo
        public ActionResult Index(string SearchSurdo)
        {
            try
            {
                ObjList = new List<Surdo>();
                ObjList = dbMpContex.Surdo.ToList();

                if (!string.IsNullOrEmpty(SearchSurdo))
                {
                    ObjList = ObjList.Where(c => c.nome.Contains(SearchSurdo)).ToList();
                }

                return View(ObjList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region ------- DETAILS -------
        // GET: Surdo/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("INDEX");
        }
        #endregion

        #region ------- CREATE -------
        // GET: Surdo/Create
        public ActionResult Create()
        {
            ViewBag.ListStatus = ListStatus();
            return View();
        }
        // POST: Surdo/Create
        [HttpPost]
        public ActionResult Create(Surdo collection, string ListStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = dbMpContex.Surdo.Select(s => s.id).DefaultIfEmpty(0).Max();

                    collection.id = dbMpContex.Surdo.Select(s => s.id).DefaultIfEmpty(0).Max() + 1;
                    dbMpContex.Surdo.Add(collection);
                    dbMpContex.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ListStatus = ListStatus;
                ViewBag.Erro = string.Empty;
                return View(collection);
            }
            catch (Exception ex)
            {
                ViewBag.ListStatus = ListStatus;
                ViewBag.Erro = ex.Message.ToString();
                return View();
            }
        }
        #endregion

        #region ------- EDITAR -------
        // GET: Surdo/Edit/5
        public ActionResult Edit(int id)
        {
            var RetSurdo = dbMpContex.Surdo.Where(s => s.id == id).First();

            ViewBag.ListStatus = ListStatus(RetSurdo.status);

            return View(RetSurdo); ;
        }

        // POST: Surdo/Edit/5
        [HttpPost]
        public ActionResult Edit(Surdo ObjSurdo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbMpContex.Entry(ObjSurdo).State = System.Data.Entity.EntityState.Modified;

                    dbMpContex.SaveChanges();

                    return RedirectToAction("Index");
                }

                ViewBag.ListStatus = ListStatus(ObjSurdo.status);
                ViewBag.Erro = string.Empty;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ListStatus = ListStatus(ObjSurdo.status);
                ViewBag.Erro = ex.Message.ToString();
                return View();
            }
        }
        #endregion

        #region ------- DELETE -------
        // GET: Surdo/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
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
        #endregion

        #region ------- LER ARQUIVO -------
        void LerArquivo()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptSurdo.txt");


            while ((line = file.ReadLine()) != null)
            {
                Surdo ObjSurdo = new Surdo();

                string[] surdolinha = line.Split('|');


                ObjSurdo.id = Convert.ToInt32(surdolinha[1]);

                if (Convert.ToInt32(surdolinha[1]) == 279)
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
        #endregion

        #region ------- LISTA DE STATUS -------
        public List<SelectListItem> ListStatus()
        {
            List<SelectListItem> LstStatus = new List<SelectListItem>();

            LstStatus.Add(new SelectListItem
            {
                Text = "Ativo",
                Value = "A"
            });
            LstStatus.Add(new SelectListItem
            {
                Text = "Mundou-se",
                Value = "M"
            });
            LstStatus.Add(new SelectListItem
            {
                Text = "Não Visitar",
                Value = "N"
            });

            return LstStatus;
        }

        public List<SelectListItem> ListStatus(string status)
        {
            List<SelectListItem> LstStatus = new List<SelectListItem>();

            if (status == "A")
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Ativo",
                    Value = "A",
                    Selected = true,
                });
            }
            else
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Ativo",
                    Value = "A"
                });
            }
            if (status == "M")
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Mundou-se",
                    Value = "M",
                    Selected = true
                });
            }
            else
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Mundou-se",
                    Value = "M"
                });
            }

            if (status == "N")
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Não Visitar",
                    Value = "N",
                    Selected = true
                });
            }
            else
            {
                LstStatus.Add(new SelectListItem
                {
                    Text = "Não Visitar",
                    Value = "N"
                });
            }

            return LstStatus;
        }
        #endregion
    }
}
