namespace foodapp.Models
{
    public class ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishIngredient>? DishIngredients {get; set;}

}
}
