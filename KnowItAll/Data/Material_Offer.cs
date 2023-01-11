namespace KnowItAll.Data
{
    public class Material_Offer
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public int Quantity { get; set; }
        public int OfferId { get; set; }
        public Offer? Offer { get; set; }

    }
}
