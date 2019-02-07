﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Repositorios.Entity;
using TreinaWeb.Musicas.Web.ViewModels.Album;
using TreinaWeb.Musicas.Web.ViewModels.Musicas;
using TreinaWeb.Repositorios.Comum;

namespace TreinaWeb.Musicas.Web.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        private IRepositorioGenerico<Musica, long> repositorioMusicas = new MusicasRepositorios(new MusicasDbContext());
        private IRepositorioGenerico<Album, int> repositorioAlbums = new AlbumsRepositorio(new MusicasDbContext());

        // GET: Musicas
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>, List<MusicaExibicaoViewModel>>(repositorioMusicas.Selecionar()));
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbums.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Inserir(musica);
             //   db.Musicas.Add(musica);
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbums.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);           
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusicas.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

       
    }
}
