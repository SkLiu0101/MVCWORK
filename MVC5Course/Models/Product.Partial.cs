namespace MVC5Course.Models
{
    using MVC5Course.Models.DataTypes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock < 10 && this.Price > 1000)
            {
                yield return new ValidationResult("Stock 要大於10 還有 Price 要小於1000", new string[]{ "Price", "Stock" });
            }

        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
       // [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
       // [身份證字號]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
