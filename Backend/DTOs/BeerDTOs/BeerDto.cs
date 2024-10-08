namespace Backend.DTOs.BeerDTOs
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Alcohol { get; set; }
        public int BrandID { get; set; }
    }
}
