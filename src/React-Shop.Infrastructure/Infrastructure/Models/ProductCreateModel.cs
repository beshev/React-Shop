namespace Infrastructure.Models
{
    using System.Collections.Generic;

    public class ProductCreateModel : ProductBaseModel
    {
        public virtual ImageCreateModel Image { get; set; }

        public virtual IEnumerable<ImageCreateModel> AdditionalImages { get; set; }
    }
}
