namespace foodapp.Models
{
    public class DishIngredient
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int ingredientId {  get; set; }
        public ingredient ingredient { get; set; } 
    }
}
