using System.Collections.Generic;

namespace GildedRose.Console
{
  public   class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue; // Sulfuras ne change jamais
                }

                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrie(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePasses(item);
                }
                else if (item.Name.Contains("Conjured"))
                {
                    UpdateConjuredItem(item);
                }
                else
                {
                    UpdateNormalItem(item);
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    SellinRules(item);
                }
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);
        }

        private void UpdateBackstagePasses(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11) IncreaseQuality(item);
            if (item.SellIn < 6) IncreaseQuality(item);
        }

        private void UpdateNormalItem(Item item)
        {
            DecreaseQuality(item);
        }

        private void UpdateConjuredItem(Item item)
        {
            DecreaseQuality(item, 2);
        }

        private void SellinRules(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0; // Expiré
            }
            else if (item.Name==("Conjured Mana Cake"))
            {
                DecreaseQuality(item, 2);
            }
            else
            {
                DecreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality(Item item,int decrement=1)
        {
            
            item.Quality -= decrement;
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }



}

public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }


