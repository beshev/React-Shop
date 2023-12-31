﻿namespace Data.Entities
{
    using System.Collections.Generic;

    public class ProductEntity : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool HasCustomText { get; set; }

        public bool IsOutOfStock { get; set; }

        public bool HasFontStyle { get; set; }

        public int ImagesCount { get; set; }

        public ImageEntity Image { get; set; }

        public IEnumerable<ImageEntity> AdditionalImages { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
