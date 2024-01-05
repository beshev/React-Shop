namespace React_Shop.Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateApiModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool HasCustomText { get; set; }

        public bool IsOutOfStock { get; set; }

        public bool HasFontStyle { get; set; }

        public int ImagesCount { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<IFormFile> AdditionalImages { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
