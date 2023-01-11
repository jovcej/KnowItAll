using KnowItAll.Data;
using KnowItAll.Interface;
using KnowItAll.Models;
using KnowItAll.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace KnowItAll.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        //private readonly IMaterialService _materialService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
            //_materialService = materialService;
        }

        public IActionResult Index(OfferDto offer)
        {
            return View();
        }

        [HttpPost]
        [Route("Offer/AddOffer")]
        public async Task<IActionResult> Add(OfferCreateDto offercreate)
        {
            var ret = await _offerService.CreateOffer(offercreate);
            var retOff = await _offerService.UpdateOffer(offercreate);
            return View("~/Views/Offer/Index.cshtml");
        }


        [HttpGet]
        [Route("Offer/GetOffer")]
        public async Task<IActionResult> GetOffers()
        {
            var ret = await _offerService.GetOffers();
            return View("~/Views/Offer/Offers.cshtml", ret);
        }

    }
}
