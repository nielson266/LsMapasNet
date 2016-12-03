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

        #region ---- INDEX ----
        // GET: Mapa
        public ActionResult Index()
        {
            return View(dbMpContex.Mapas.ToList());
        }
        #endregion

        #region ---- Details ----
        // GET: Mapa/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("index");
        }
        #endregion

        #region ---- CREATE ----
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

                ViewBag.Erro = string.Empty;
                return View(ObjMapa);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message.ToString();
                return View(ObjMapa);
            }
        }
        #endregion

        #region ---- EDITAR ----
        // GET: Mapa/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dbMpContex.Mapas.Where(m => m.id == id).FirstOrDefault());
        }

        // POST: Mapa/Edit/5
        [HttpPost]
        public ActionResult Edit(Mapas ObjMapa)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    dbMpContex.Entry(ObjMapa).State = System.Data.Entity.EntityState.Modified;
                    dbMpContex.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Erro = string.Empty;
                return View(ObjMapa);
            }
            catch(Exception ex)
            {
                ViewBag.Erro = ex.Message.ToString();
                return View(ObjMapa);
            }
        }
        #endregion

        #region ---- MIGRAÇÃO ----
        public ActionResult Migracao()
        {
            var listamap = dbMpContex.Mapas.ToList();

            ViewBag.ListaMapa = new SelectList
                            (
                                listamap,
                                "id",
                                "desc_mapa"
                            );


            ViewBag.ListaMapaMigracao = new SelectList
                            (
                                listamap,
                                "id",
                                "desc_mapa"
                            );
            return View();
        }

        [HttpPost]
        public ActionResult Migracao(string ListaMapa, string ListaMapaMigracao)
        {
            try
            {
                if (!string.IsNullOrEmpty(ListaMapa) && !string.IsNullOrEmpty(ListaMapaMigracao))
                {
                    int idmaparet = Convert.ToInt32(ListaMapa);
                    int idmapaMigracao = Convert.ToInt32(ListaMapaMigracao);

                    var ListRetSurdo = dbMpContex.MapaSurdo.Where(ms => ms.idMapa == idmaparet).ToList();


                    foreach (var item in ListRetSurdo)
                    {
                        MapaSurdo ObjMapaSurdo = new MapaSurdo();
                        ObjMapaSurdo.idMapa = idmapaMigracao;
                        ObjMapaSurdo.idSurdo = item.idSurdo;
                        dbMpContex.MapaSurdo.Add(ObjMapaSurdo);
                        dbMpContex.SaveChanges();
                    }

                    dbMpContex.Database.ExecuteSqlCommand("DELETE FROM mapasurdo where idmapa = {0}", idmaparet);
                    dbMpContex.SaveChanges();

                    dbMpContex.Database.ExecuteSqlCommand("Delete From mapas where id = {0}", idmaparet);

                    dbMpContex.SaveChanges();

                    return RedirectToAction("index");
                }

                ViewBag.Erro = "Dados informados em branco";

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message.ToString();
                return View();
            }
        }

        #endregion

        public ActionResult SurdoCentral(int idmapa, int idsurdo)
        {
            var objms = dbMpContex.Surdo.Where(ms => ms.id == idsurdo).FirstOrDefault();


        }

        #region ---- DELETE ----
        // GET: Mapa/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("index");
        }
        #endregion

        #region ---- IMPRESSAO MAPA ----
        public ActionResult ImpressaoMapa(int id)
        {
            var DtListMapa = dbMpContex.MapaSurdo.Where(m => m.idMapa == id).ToList();

            ViewBag.idMapa = id;
            ViewBag.Mapa = DtListMapa[0].id_mapa.desc_mapa;
            
            return View(DtListMapa);
        }
        #endregion

        #region ---- INCLUIR SURDO AO MAPA ----

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

        #endregion

        #region ---- INCLUIR SURDO AO MAPA - JSON ----
        public ActionResult IncluirSurdoMapaJson(string IdMapa, string SelectIdSurdo)
        {

            MapaSurdo ObjMS = new MapaSurdo();
            ObjMS.idMapa = Convert.ToInt32(IdMapa);

            string[] Mapalinha = SelectIdSurdo.Split('|');

            var nome = Mapalinha[0].ToString();
            var bairro = Mapalinha[1].ToString();
            ObjMS.idSurdo = dbMpContex.Surdo.Where(s => s.bairro.Trim().Contains(bairro.Trim()) && s.nome.Trim().Contains(nome.Trim())).Select(s => s.id).First();

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

        #endregion

        #region ---- LISTA SURDO MAPA - PARTIAL VIEW ----

        public PartialViewResult _listasurdomapa(int id)
        {
            ViewBag.Mapa = dbMpContex.Mapas.Where(m => m.id == id).Select(s => s.desc_mapa).First();
            return PartialView(dbMpContex.MapaSurdo.Where(ms => ms.idMapa == id).ToList());
        }

        #endregion

        #region ---- DROPDOWN LISTA DE SURDO - JSON ----

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

        #endregion

        #region ---- EXCLUIR SURDO MAPA ----

        public ActionResult ExcluirSurdoMapa(string idsurdo)
        {

            try
            {
                var retidsurdo = Convert.ToInt32(idsurdo);

                var ObjMapaSurdo = dbMpContex.MapaSurdo.Where(ms => ms.id == retidsurdo).FirstOrDefault();

                var id = ObjMapaSurdo.idMapa;

                dbMpContex.Entry(ObjMapaSurdo).State = System.Data.Entity.EntityState.Deleted;
                dbMpContex.SaveChanges();

                return RedirectToAction("IncluirSurdoMapa", new { idmapa = id });
            }
            catch (Exception ex)
            {
                return RedirectToAction("IncluirSurdoMapa", new { idmapa = 0 });
            }
        }

        #endregion

        #region ---- IMPRIMIR SELECT MAPA SURDO POR ID ----
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

        #endregion

        #region --- CARREGA DADOS POR ARQUIVOS
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
        #endregion
    }
}
