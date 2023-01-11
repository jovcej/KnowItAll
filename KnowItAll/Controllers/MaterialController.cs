using KnowItAll.Data;
using KnowItAll.Interface;
using KnowItAll.Models;
using KnowItAll.Service;
using Microsoft.AspNetCore.Mvc;

namespace KnowItAll.Controllers
{
    [Route("material")]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [Route("index")]
        [Route("")]
        [Route("~/")]
        public async Task<IActionResult> Index()
        {
            var mat = await _materialService.GetMaterials();
            return View(mat);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {          
            return View("Add", new MaterialDto());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(MaterialDto material)
        {
            var ret = await _materialService.CreateMaterial(material);
            return View("~/Views/Material/Index.cshtml");
        }

    }
}
