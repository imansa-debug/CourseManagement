using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Article_MetaData
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد")]
        [MaxLength(ErrorMessage = "تعداد کاراکترهای مجاز برای فیلد{0} 50 عدد است")]
        public string Name { get; set; }
        [Display(Name = "توضیحات مختصر")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد")]
        [MaxLength(ErrorMessage = "تعداد کاراکترهای مجاز برای فیلد{0} 50 عدد است")]
        public string Description { get; set; }
        [Display(Name = "متن مقاله")]

        public string Text { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "ویدئو")]
        public string Video { get; set; }
        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد")]
        [MaxLength(ErrorMessage = "تعداد کاراکترهای مجاز برای فیلد{0} 50 عدد است")]
        public string Author { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public System.DateTime CreateDate { get; set; }

    }
    [MetadataType(typeof(Article_MetaData))]
    public partial class Article
    {

    }
}
