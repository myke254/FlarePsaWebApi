using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare.Data.Entities
{
   public enum Currency
    {
        [Display(Name = "Kenyan Shilling /=")]
        KES,
        [Display(Name = "United States Dollar $")]
        USD,
        [Display(Name = "Mexican Peso $")]
        MXN,
        [Display(Name = "Japanese Yen ¥")]
        JPY,
        [Display(Name = "Ugandan Shilling USh")]
        USh,
        [Display(Name = "Tanzanian Shilling TSh")]
        TSh,
        [Display(Name = "Nigerian Naira ₦")]
        Naira,
    }
}
