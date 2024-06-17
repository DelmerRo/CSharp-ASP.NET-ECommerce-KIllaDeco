﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = ErrorMsgs.ErrMsgRequired)]
        public int SubCategoryId { get; set; }

        [Display(Name = Alias.Code)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductSku, Restrictions.MaxProductSku, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public int Sku { get; set; }

        [Display(Name = Alias.Name)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductName, MinimumLength = Restrictions.MinProductName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Name { get; set; }

        [Display(Name = Alias.Description)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductDescription, MinimumLength = Restrictions.MinProductDescription, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = Alias.CurrentPrice)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductCurrentPrice, Restrictions.MaxProductCurrentPrice, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public decimal CurrentPrice { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Display(Name = Alias.Active)]
        public bool Active { get; set; }

        [NotMapped]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public IFormFile? ImageUrlFile { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductDescription, MinimumLength = Restrictions.MinProductDescription, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? ImageUrl { get; set; }

        [Display(Name = Alias.AvailableStock)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductAvailableStock, Restrictions.MaxProductAvailableStock, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public int AvailableStock { get; set; }

        [Display(Name = Alias.Weight)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductWeight, Restrictions.MaxProductWeight, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public decimal Weight { get; set; }
       
        [Display(Name = Alias.Dimensions)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductDimensions, MinimumLength = Restrictions.MinProductDimensions, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Dimensions { get; set; }

        [Display(Name = Alias.Color)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductColors, MinimumLength = Restrictions.MinProductColors, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Color { get; set; }

        [Display(Name = Alias.PublicationDate)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorMsgs.InvalidDate)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Display(Name = Alias.Discount)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductDiscount, Restrictions.MaxProductDiscount, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public decimal Discount { get; set; }

        [Display(Name = Alias.SubCategoryName)]
        public SubCategory? SubCategories { get; set; }
        
        public List<StockItem>? StockItems { get; set; }
        public List<Qualification>? Qualifications { get; set; }
        public List<Favorite>? Favorites { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
