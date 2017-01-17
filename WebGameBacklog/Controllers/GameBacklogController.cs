using System;
using System.Web.Mvc;
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

        public ActionResult Index()
        {
            var games = _gameBacklogService.GetAllForBacklog(Guid.NewGuid());
            return View();
        }
    }
}