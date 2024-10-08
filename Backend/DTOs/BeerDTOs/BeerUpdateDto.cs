namespace Backend.DTOs.BeerDTOs
{
    public class BeerUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Alcohol { get; set; }
        public int BrandID { get; set; }
    }
}
