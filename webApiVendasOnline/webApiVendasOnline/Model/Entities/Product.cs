using System.Text.Json.Serialization;

namespace webApiVendasOnline.Entities
   {
    /// <summary>
    /// Represents a product in the online sales system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the bar code of the product (maximum 20 characters).
        /// </summary>
        [JsonPropertyName("bar_code")]
        public string BarCode { get; set; } // Bar code, 20 chars

        /// <summary>
        /// Gets or sets the date when the product started selling.
        /// </summary>
        [JsonPropertyName("start_sell_date")]
        public DateTime StartSellDate { get; set; } // Date of start sell

        /// <summary>
        /// Gets or sets a value indicating whether the product is discontinued.
        /// </summary>
        [JsonPropertyName("is_discontinued")]
        public bool IsDiscontinued { get; set; } // Discontinued status

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; set; } // Common attribute: Category

        /// <summary>
        /// Gets or sets the quantity of the product in stock.
        /// </summary>
        [JsonPropertyName("stock_quantity")]
        public int StockQuantity { get; set; } // Common attribute: Stock quantity

        /// <summary>
        /// Gets or sets the manufacturer of the product.
        /// </summary>
        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; } // Common attribute: Manufacturer

        /// <summary>
        /// Gets or sets the ICMS state taxes for the product.
        /// </summary>
        [JsonPropertyName("icms_state_taxes")]
        public decimal ICMSStateTaxes { get; set; } // ICMS state taxes

        /// <summary>
        /// Gets or sets the IPI federal taxes for the product.
        /// </summary>
        [JsonPropertyName("ipi_federal_taxes")]
        public decimal IPIFederalTaxes { get; set; } // IPI federal taxes
    }
   }
   