using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void AgedBrie_IncreaseQuality()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            var app = new Program() { Items = new List<Item> { item } };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(1, item.Quality);  // =1
        }

        [Fact]
        public void BackstagePasses_IncreaseQuality_WhenSellInIsLessThan11()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            var app = new Program() { Items = new List<Item> { item } };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(22, item.Quality);  // =2
        }

        [Fact]
        public void BackstagePasses_QualityZero_AfterConcert()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            var app = new Program() { Items = new List<Item> { item } };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.Quality);  // =0
        }

        [Fact]
        public void ItemQualityCannotGoToZero()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 };
            var app = new Program() { Items = new List<Item> { item } };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.Quality);  // La qualité = 0
        }
        [Fact]
        public void ConjuredItem_DecreaseQualityTwiceAsFast()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            var app = new Program() { Items = new List<Item> { item } };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(4, item.Quality);  // La qualité doit diminuer de 2
        }

    }
}