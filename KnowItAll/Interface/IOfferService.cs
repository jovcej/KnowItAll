using KnowItAll.Data;
using KnowItAll.Enum;
using KnowItAll.Models;

namespace KnowItAll.Interface
{
    public interface IOfferService
    {
        Task<List<Offer>> GetOffers();

        Task<Offer> GetById(int id);

        Task<Offer> CreateOffer(OfferCreateDto offercreate);

        Task<Offer> UpdateOffer(OfferCreateDto offercreate);

        //Task<bool> Delete(int id);

        Task<bool> ChangeOfferStatus(int id, Status status);
    }
}
