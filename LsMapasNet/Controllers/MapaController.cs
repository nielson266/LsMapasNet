using LsMapasNet.Contexto;
using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LsMapasNet.Controllers
{
    public class MapaController : Controller
    {
        private LsMapaContext dbMpContex = new LsMapaContext();
        // GET: Mapa
        public ActionResult Index()
        {
            //CarregaMapaScript();
            //CarregaMapaSurdoScript();

            return View(dbMpContex.Mapas.ToList());
        }

        // GET: Mapa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mapa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mapa/Create
        [HttpPost]
        public ActionResult Create(Mapas ObjMapa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbMpContex.Mapas.Add(ObjMapa);
                    dbMpContex.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View(ObjMapa);

            }
            catch (Exception Ex)
            {
                return View(ObjMapa);
            }
        }

        // GET: Mapa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mapa/Edit/5
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

        // GET: Mapa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult ImpressaoMapa(int id)
        {

            var DtListMapa = dbMpContex.MapaSurdo.Where(m => m.idMapa == id).ToList();

            ViewBag.idMapa = id;
            ViewBag.Mapa = DtListMapa[0].id_mapa.desc_mapa;


            return View(DtListMapa);
        }

        public ActionResult IncluirSurdoMapa(int? idmapa)
        {
            string listbairros = "'SÃO MATEUS','SANTA LUZIA','SANTA CLARA','S','RIACHO SUJO','MONTE','PALESTINA','ITAPIPOCA','PENTECOSTE','ALTO GUARAMIRANGA','BOA VISTA','CAMPINAS','CAN','CANIDEZINHO','IMACULADA CONC.','JOAO PAULO II'";
            ViewBag.SelectIdSurdo = from s in dbMpContex.Surdo
                                    where !dbMpContex.MapaSurdo.Any(ms => (ms.idSurdo == s.id)) && (!listbairros.Contains(s.bairro))
                                    orderby s.nome
                                    select new { s.id, nome = s.nome + " | " + s.bairro };

            ViewBag.ListMapaSurdo = dbMpContex.MapaSurdo.Where(ms => ms.idMapa == idmapa).ToList();

            ViewBag.IdMapa = idmapa;
            
            return View();
        }

        public ActionResult IncluirSurdoMapaJson(string IdMapa, string SelectIdSurdo)
        {

            MapaSurdo ObjMS = new MapaSurdo();
            ObjMS.idMapa = Convert.ToInt32(IdMapa);

            string[] Mapalinha = SelectIdSurdo.Split('|');

            ObjMS.idSurdo = dbMpContex.Surdo.Where(s => s.bairro.Contains(Mapalinha[1]) && s.nome.Contains(Mapalinha[0])).Select(s => s.id).First();

            dbMpContex.MapaSurdo.Add(ObjMS);
            dbMpContex.SaveChanges();

            string listbairros = "'SÃO MATEUS','SANTA LUZIA','SANTA CLARA','S','RIACHO SUJO','MONTE','PALESTINA','ITAPIPOCA','PENTECOSTE','ALTO GUARAMIRANGA','BOA VISTA','CAMPINAS','CAN','CANIDEZINHO','IMACULADA CONC.','JOAO PAULO II'";
            ViewBag.SelectIdSurdo = from s in dbMpContex.Surdo
                                    where !dbMpContex.MapaSurdo.Any(ms => (ms.idSurdo == s.id)) && (!listbairros.Contains(s.bairro))
                                    orderby s.nome
                                    select new { s.id, nome = s.nome + " | " + s.bairro };

            var idMapaPar = Convert.ToInt32(IdMapa);
            ViewBag.IdMapa = Convert.ToInt32(IdMapa);

            return Json("OK");
        }

        public PartialViewResult _listasurdomapa(int id)
        {
            ViewBag.Mapa = dbMpContex.Mapas.Where(m => m.id == id).Select(s => s.desc_mapa).First();
            return PartialView(dbMpContex.MapaSurdo.Where(ms => ms.idMapa == id).ToList());
        }

        public JsonResult dropdownlistsurdo()
        {
            string listbairros = "'SÃO MATEUS','SANTA LUZIA','SANTA CLARA','S','RIACHO SUJO','MONTE','PALESTINA','ITAPIPOCA','PENTECOSTE','ALTO GUARAMIRANGA','BOA VISTA','CAMPINAS','CAN','CANIDEZINHO','IMACULADA CONC.','JOAO PAULO II'";
            var ListSurdo = from s in dbMpContex.Surdo
                            where !dbMpContex.MapaSurdo.Any(ms => (ms.idSurdo == s.id)) && (!listbairros.Contains(s.bairro))
                            orderby s.nome
                            select new { s.id, nome = s.nome + " | " + s.bairro };



            List<string> dados = new List<string>();

            foreach (var item in ListSurdo)
            {
                dados.Add(item.nome);
            }

            return Json(dados, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteSurdoMapa(int id)
        {
            return View();
        }

        public ActionResult imprimir_listalatlongmapa(int id)
        {

            List<object> coordenadassurdo = new List<object>();

            var DtListMapa = dbMpContex.MapaSurdo.Where(m => m.idMapa == id).ToList();

            var longmapa = Convert.ToDouble(DtListMapa[0].id_mapa.centromapa_long.Substring(0, 3) + "," + DtListMapa[0].id_mapa.centromapa_long.Substring(3, DtListMapa[0].id_mapa.centromapa_long.Length - 3));
            var latMapa = Convert.ToDouble(DtListMapa[0].id_mapa.centromapa_lat.Substring(0, 2) + "," + DtListMapa[0].id_mapa.centromapa_lat.Substring(2, DtListMapa[0].id_mapa.centromapa_lat.Length - 2));
            var zmapa = DtListMapa[0].id_mapa.zoommapa;

            foreach (var item in DtListMapa)
            {
                coordenadassurdo.Add(new
                {
                    surdolong = Convert.ToDouble(item.id_surdo.longitude.Substring(0, 3) + "," + item.id_surdo.longitude.Substring(3, item.id_surdo.longitude.Length - 3)),
                    surdolat = Convert.ToDouble(item.id_surdo.latitude.Substring(0, 2) + "," + item.id_surdo.latitude.Substring(2, item.id_surdo.latitude.Length - 2)),
                });
            }

            List<object> dados = new List<object>();

            dados.Add(new
            {
                listll = coordenadassurdo,
                centlong = longmapa,
                centlat = latMapa,
                zoommapa = zmapa
            });

            return Json(dados, JsonRequestBehavior.AllowGet);
        }

        // POST: Mapa/Delete/5
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

        void CarregaMapaScript()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapa.txt");

            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapa.txt");


            while ((line = file.ReadLine()) != null)
            {
                Mapas ObjMapa = new Mapas();

                string[] Mapalinha = line.Split('|');

                ObjMapa.id = Convert.ToInt32(Mapalinha[1]);
                ObjMapa.desc_mapa = Mapalinha[2];
                ObjMapa.obs = Mapalinha[3];
                ObjMapa.centromapa_lat = Mapalinha[4];
                ObjMapa.centromapa_long = Mapalinha[5];
                ObjMapa.id_surdo = Convert.ToInt32(Mapalinha[6]);
                ObjMapa.zoommapa = Convert.ToDecimal(Mapalinha[7].Replace(".", ","));


                dbMpContex.Mapas.Add(ObjMapa);
                dbMpContex.SaveChanges();

                counter++;
            }
        }

        void CarregaMapaSurdoScript()
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapaSurdo.txt");

            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapaSurdo.txt");


            while ((line = file.ReadLine()) != null)
            {
                MapaSurdo ObjMapaSurdo = new MapaSurdo();

                string[] Mapalinha = line.Split('|');

                //ObjMapaSurdo.id = Convert.ToInt32(Mapalinha[0]);
                ObjMapaSurdo.idMapa = Convert.ToInt32(Mapalinha[1]);
                ObjMapaSurdo.idSurdo = Convert.ToInt32(Mapalinha[2]);


                try
                {
                    dbMpContex.MapaSurdo.Add(ObjMapaSurdo);
                    dbMpContex.SaveChanges();
                }
                catch (Exception ex)
                {
                    counter++;
                }

                counter++;
            }
        }
    }
}
