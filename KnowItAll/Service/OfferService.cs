using KnowItAll.Data;
using KnowItAll.Enum;
using KnowItAll.Interface;
using KnowItAll.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;

namespace KnowItAll.Service
{
    public class OfferService : IOfferService
    {

        private readonly DataContext _context;

        public OfferService(DataContext context)
        {
            _context = context;
        }

        public async Task<Offer> CreateOffer(OfferCreateDto OfferCreate)
        {
            Offer offer = new Offer();

            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            foreach (OfferDto item in OfferCreate.QuantityMaterial)
            {
                var Materialid =  _context.Materials.Where(x => x.Name == item.Material).Select(x => x.MaterialId).FirstOrDefault();
                var MaterialPrice = _context.Materials.Where(x => x.Name == item.Material).Select(x => x.Price).FirstOrDefault();
                                                    
                var _materialoffer = new Material_Offer()
                {
                    OfferId = offer.OfferId,
                    //Offer = new Offer()
                    //{                     
                    //    Status = KnowItAll.Enum.Status.Accepted,
                    //    Price = MaterialPrice,
                    //    Quantity = item.Quantity
                        
                    //},
                    MaterialId = Materialid,                                     
                    Quantity = item.Quantity,
                    //Material = _context.Materials.Where();
                                    
                };
                _context.Material_Offers.Add(_materialoffer);
                await _context.SaveChangesAsync();               
            }
           
            return offer;
        }

        public async Task<List<Offer>> GetOffers()
        {
            return await _context.Offers.ToListAsync();
        }


        public async Task<Offer> UpdateOffer(OfferCreateDto offercreate)
        {
            Offer offer = new Offer();

            var countsand = 0;
            var countwater = 0;
            var countcotton = 0;


            offer.Quantity += offercreate.QuantityMaterial.ElementAt(0).Quantity;

            //Calc Offer Price

            //offer.Price += (_materialoffer.Material.Price * offercreate.QuantityMaterial.ElementAt(0).Material);


            if (offercreate.QuantityMaterial.ElementAt(0).Material == "Sand")
            {
                countsand += offercreate.QuantityMaterial.ElementAt(0).Quantity;
            }
            if (offercreate.QuantityMaterial.ElementAt(0).Material == "Cotton")
            {
                countcotton += offercreate.QuantityMaterial.ElementAt(0).Quantity;
            }
            if (offercreate.QuantityMaterial.ElementAt(0).Material == "Water")
            {
                countwater += offercreate.QuantityMaterial.ElementAt(0).Quantity;
            }

            //if (countcotton > 0 && countcotton / countwater != 3)
            //{
            //    throw new Exception("Cotton must 3:1 Water");

            //}
            //if (countsand > 0 && countsand / countwater != 2)
            //{
            //    throw new Exception("Sand must 2:1 Water");
            //}

            offer.Time = CalcTime(offer);

            _context.Update(offer);
            await _context.SaveChangesAsync();

            return offer;
        }

        public async Task<Offer> GetById(int id)
        {
            return await _context.Offers.Where(x => x.OfferId == id).FirstOrDefaultAsync();
        }


        public async Task<bool> ChangeOfferStatus(int id, Status status)
        {
            var offer = await _context.Offers.Where(x => x.OfferId == id).FirstOrDefaultAsync();
            offer.Status = status;

            _context.Update(offer);
            await _context.SaveChangesAsync();

            return true;
        }


        public int CalcTime(Offer offer)
        {
            //offer based on price
            if (offer.Price <= 10)
            {
                offer.Time += 0;
            }
            if (offer.Price > 10 && offer.Price <= 25)
            {
                offer.Time += 7;
            }
            if (offer.Price > 25 && offer.Price <= 100)
            {
                offer.Time += 45;
            }
            if (offer.Price > 100)
            {
                offer.Time += 180;
            }
            // offer based on Quantity
            if (offer.Quantity <= 3)
            {
                offer.Time += 0;
            }
            if (offer.Quantity > 3 && offer.Quantity <= 12)
            {
                offer.Time += 3;
            }
            if (offer.Quantity > 12 && offer.Quantity <= 50)
            {
                offer.Time += 21;
            }
            if (offer.Quantity > 50)
            {
                offer.Time += 60;
            }

            return offer.Time;
        }

    }
}
