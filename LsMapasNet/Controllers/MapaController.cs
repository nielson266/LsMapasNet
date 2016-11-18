﻿using LsMapasNet.Contexto;
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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


        public ActionResult imprimir_listalatlongmapa(int id)
        {
            return View();
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
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapa.txt");

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapa.txt");


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
                ObjMapa.zoommapa = Convert.ToDecimal(Mapalinha[7].Replace(".",","));


                dbMpContex.Mapas.Add(ObjMapa);
                dbMpContex.SaveChanges();

                counter++;
            }
        }

        void CarregaMapaSurdoScript()
        {
            int counter = 0;
            string line;
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\dp\Documents\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapa.txt");

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Sistemas\LsMapasNet\LsMapasNet\arquivos\scriptMapaSurdo.txt");


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
                catch(Exception ex)
                {
                    counter++;
                }

                counter++;
            }
        }
    }
}
