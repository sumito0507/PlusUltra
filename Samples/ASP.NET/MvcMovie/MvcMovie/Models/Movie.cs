using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcMovie.Models
{
    /// <summary>
    ///  映画のタイトル等を管理するデータベース
    /// </summary>
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1), Required]
        [Display(Name = "タイトル")]
        public string Title { get; set; }

        [Display(Name = "監督")]
        public string Director { get; set; }

        [Display(Name="リリース日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "ジャンル")]
        public string Genre { get; set; }

        [Display(Name = "価格")]
        [DataType(DataType.Currency)]
        [Range(1, 999999, ErrorMessage = "{0}は{1}～{2}の間で入力してください。 ")]
        public decimal Price { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}