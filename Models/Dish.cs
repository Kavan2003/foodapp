namespace foodapp.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURl { get; set; }
        public double price { get; set; }
        public List<DishIngredient>? DishIngredients {get; set;}
    }
}
