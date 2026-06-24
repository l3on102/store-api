using Api.Model;
using Bogus;
namespace Api.Seed
{
    public static class FakeProductGenerator
    {
        public static List<Product> GenerateProductList(int count = 10)
        {
            var categories = new[] { "категория 1", "категория 2", "категория 3" };
            var specialTags = new[] { "новинка", "популярный", "рекомендуемый" };

            return new Faker<Product>("ru")
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.Name, f => f.Commerce.ProductName())
            .RuleFor(m => m.Description, f => f.Lorem.Sentence())
            .RuleFor(m => m.SpecialTag, f => f.PickRandom(specialTags))
            .RuleFor(m => m.Category, f => f.PickRandom(categories))
            .RuleFor(m => m.Price, f => Math.Round(f.Random.Double(1, 1000), 2))
            .RuleFor(m => m.Image, f => $"https://imgplaceholdr.com/200x200/cccccc/969696/png?text_size=40")
            .Generate(count);



        }
    }
}