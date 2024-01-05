namespace Infrastructure.Models
{
    using System;
    using System.Collections.Generic;

    public class ProductModel : ProductBaseModel
    {
        public bool IsOutOfStock { get; set; }

        public virtual ImageModel Image { get; set; }

        public virtual IEnumerable<ImageModel> AdditionalImages { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
