using System;
using System.Linq;
using System.Web.Mvc;
using WebGameBacklog.Models.GameBacklog;
using WebGameBacklog.Services.Games;

namespace WebGameBacklog.Controllers
{
    public class GameBacklogController : Controller
    {
        private readonly IGameBacklogService _gameBacklogService;

        public GameBacklogController(IGameBacklogService gameBacklogService)
        {
            _gameBacklogService = gameBacklogService;
        }
        
        public ActionResult Index(Guid id)
        {
            var games = _gameBacklogService.GetAllForBacklog(id);            
            return View();
        }
        
        public ActionResult Details(Guid id)
        {
            var game = _gameBacklogService.GetGame(id);
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CreateGamePostModel model)
        {
            try
            {
                _gameBacklogService.Create(model.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GameBacklog/Edit/5
        public ActionResult Edit(Guid id)
        {
            var game = _gameBacklogService.GetGame(id);
            return View();
        }

        // POST: GameBacklog/Edit/5
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

        // GET: GameBacklog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameBacklog/Delete/5
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
    }
}
