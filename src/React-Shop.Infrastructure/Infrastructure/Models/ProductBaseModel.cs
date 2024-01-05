namespace Infrastructure.Models
{
    using System.Collections.Generic;

    public abstract class ProductBaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool HasCustomText { get; set; }

        public bool HasFontStyle { get; set; }

        public int ImagesCount { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
