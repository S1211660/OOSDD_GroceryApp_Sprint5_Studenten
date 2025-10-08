using NUnit.Framework;
using Grocery.Core.Models;
using System;

namespace TestCore
{
    [TestFixture]
    public class UC14_ProductPriceTests
    {
        [Test]
        [TestCase(1.99)]
        [TestCase(0.00)]
        [TestCase(10.50)]
        [TestCase(999.99)]
        public void TC_14U01_UC14_NFR2_PriceFormat_MaxTwoDecimals(decimal price)
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, DateOnly.MinValue, price);

            // Act
            var roundedPrice = Math.Round(product.Price, 2);

            // Assert
            Assert.That(product.Price, Is.EqualTo(roundedPrice),
                $"Prijs {product.Price} moet maximaal 2 decimalen hebben");
        }

        [Test]
        [TestCase(1.49, 1.49)]
        [TestCase(3.99, 3.99)]
        [TestCase(2.29, 2.29)]
        [TestCase(4.59, 4.59)]
        [TestCase(0.00, 0.00)]
        public void TC_14U02_UC14_NFR1_PriceFormat_CorrectCurrency(decimal inputPrice, decimal expectedPrice)
        {
            // Arrange & Act
            var product = new Product(1, "Test Product", 100, DateOnly.MinValue, inputPrice);

            // Assert
            Assert.That(product.Price, Is.TypeOf<decimal>(),
                "Prijs moet van type decimal zijn");
            Assert.That(product.Price, Is.EqualTo(expectedPrice),
                $"Prijs moet correct worden opgeslagen: verwacht {expectedPrice}, gekregen {product.Price}");
            Assert.That(product.Price, Is.GreaterThanOrEqualTo(0),
                "Prijs moet een positief bedrag zijn");
        }
    }
}