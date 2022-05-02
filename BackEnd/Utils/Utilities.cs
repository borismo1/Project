using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BackEnd.Utils
{
    public static class Utilities
    {

        public static async Task SeedDatabaseWithItems(DataContext context,string imagesFolder,int category) 
        {
            string[] images = Directory.GetFiles(imagesFolder);
            List<Item> Items = new List<Item>();

            Random rand = new Random();

            int counter = 1;
            foreach (var image in images)
            {
                Item item = new Item() 
                {
                    Category = category,
                    Description = $"Description-{counter}",
                    IsTrending = rand.NextDouble() >= 0.5,
                    ImageBytes = File.ReadAllBytes(image),
                    Name = $"Name-{counter++}",
                    Price = (rand.NextDouble() * 5)
                };

                Items.Add(item);
            }

            await context.Items.AddRangeAsync(Items.ToArray());

            await context.SaveChangesAsync();
        }

        public static async Task SeedDatabaseWithCategories(DataContext context, Dictionary<string, int> imageVsId)
        {
            List<Category> categories = new List<Category>();

            Random rand = new Random();
            foreach (var KeyValuePair in imageVsId)
            {
                Category cat = new Category()
                {
                    //Id = KeyValuePair.Value,
                    Name = Path.GetFileNameWithoutExtension(KeyValuePair.Key),
                    ImageBytes = File.ReadAllBytes(KeyValuePair.Key)
                };

                categories.Add(cat);
            }

            await context.Categories.AddRangeAsync(categories.ToArray());
            await context.SaveChangesAsync();
        }

    }
}
