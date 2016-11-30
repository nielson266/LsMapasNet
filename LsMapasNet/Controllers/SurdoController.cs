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
        // GET: Surdo
        public ActionResult Index(string SearchSurdo)
        {
            //var listSurdo = dbMpContex.Surdo.ToList();
            try
            {
                ObjList = new List<Surdo>();
                ObjList = dbMpContex.Surdo.ToList();

                if (!string.IsNullOrEmpty(SearchSurdo))
                {
                    ObjList = ObjList.Where(c => c.nome.Contains(SearchSurdo)).ToList();
                }
                    


                    //LerArquivo();
                    return View(ObjList);
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

            List<SelectListItem> ListStatus = new List<SelectListItem>();
            ListStatus.Add(new SelectListItem
            {
                Text = "Ativo",
                Value = "A"
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
            return View();
        }

        // POST: Surdo/Create
        [HttpPost]
        public ActionResult Create(Surdo collection, string ListStatus)
        {
            try
            {
                //if (ListStatus != string.Empty)
                //{
                //    collection.status = ListStatus;
                //}



                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    collection.id = dbMpContex.Surdo.Max(s => s.id) + 1;
                    dbMpContex.Surdo.Add(collection);
                    dbMpContex.SaveChanges();
                    return RedirectToAction("Index");
                }
                List<SelectListItem> ListStatusCbo = new List<SelectListItem>();
                ListStatusCbo.Add(new SelectListItem
                {
                    Text = "Ativo",
                    Value = "A"
                });
                ListStatusCbo.Add(new SelectListItem
                {
                    Text = "Mundou-se",
                    Value = "M"
                });
                ListStatusCbo.Add(new SelectListItem
                {
                    Text = "Não Visitar",
                    Value = "N"
                });

                ViewBag.ListStatus = ListStatusCbo;

                return View(collection);
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

            var RetSurdo = dbMpContex.Surdo.Where(s => s.id == id).First();

            if (RetSurdo.status == "A")
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Ativo",
                    Value = "A",
                    Selected = true,
                });
            }
            else
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Ativo",
                    Value = "A"
                });
            }
            if (RetSurdo.status == "M")
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Mundou-se",
                    Value = "M",
                    Selected = true
                });
            }
            else
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Mundou-se",
                    Value = "M"
                });
            }

            if (RetSurdo.status == "N")
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Não Visitar",
                    Value = "N",
                    Selected = true
                });
            }
            else
            {
                ListStatus.Add(new SelectListItem
                {
                    Text = "Não Visitar",
                    Value = "N"
                });
            }

            ViewBag.ListStatus = ListStatus;

            return View(RetSurdo); ;
        }

        // POST: Surdo/Edit/5
        [HttpPost]
        public ActionResult Edit(Surdo ObjSurdo)
        {
            try
            {
                List<SelectListItem> ListStatus = new List<SelectListItem>();

                if (ModelState.IsValid)
                {
                    dbMpContex.Entry(ObjSurdo).State = System.Data.Entity.EntityState.Modified;

                    dbMpContex.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    if (ObjSurdo.status == "A")
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Ativo",
                            Value = "A",
                            Selected = true,
                        });
                    }
                    else
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Ativo",
                            Value = "A"
                        });
                    }
                    if (ObjSurdo.status == "M")
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Mundou-se",
                            Value = "M",
                            Selected = true
                        });
                    }
                    else
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Mundou-se",
                            Value = "M"
                        });
                    }

                    if (ObjSurdo.status == "N")
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Não Visitar",
                            Value = "N",
                            Selected = true
                        });
                    }
                    else
                    {
                        ListStatus.Add(new SelectListItem
                        {
                            Text = "Não Visitar",
                            Value = "N"
                        });
                    }

                    ViewBag.ListStatus = ListStatus;
                }
                return View();
            }
            catch(Exception Ex)
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
