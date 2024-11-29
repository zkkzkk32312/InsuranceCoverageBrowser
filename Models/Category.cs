namespace InsuranceCoverageBrowser.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new();
        public decimal Price => Items.Sum(item => item.Price);
    }
}
