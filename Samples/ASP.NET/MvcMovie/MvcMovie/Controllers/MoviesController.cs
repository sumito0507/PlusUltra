using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieGenre">ジャンル</param>
        /// <param name="searchString">検索ワード</param>
        /// <returns></returns>
        public ActionResult Index(string movieGenre, string searchString, DateTime? releaseDate, decimal? price)
        {
            var GenreList = new List<string>();
            // ジャンルをデータベースから検索
            var GenreQry = from d in db.Movies orderby d.Genre select d.Genre;
            GenreList.AddRange(GenreQry.Distinct());
            // ViewBagにSelectListとして保存
            ViewBag.movieGenre = new SelectList(GenreList);

            var movies = from m in db.Movies select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                // タイトルでフィルタリング
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            if (releaseDate != null)
            {
                // リリース日でフィルタリング
                movies = movies.Where(s => s.ReleaseDate == releaseDate);
            }
            if (!string.IsNullOrEmpty(movieGenre))
            {
                // ジャンルでフィルタリング
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            if (price != null)
            {
                // 値段でフィルタリング
                movies = movies.Where(s => s.Price == price);
            }

            //return View(db.Movies.ToList());
            return View(movies);
        }

        // POST: Movies/SearchIndex
        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3>Form [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Director,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Director,ReleaseDate,Genre,Price")] Movie movie)
        {
            // 取得したデータ がMovieオブジェクトの編集・更新に利用できるかどうかチェック
            if (ModelState.IsValid)
            {
                // DBに保存
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                // 保存後Indexに戻り、Movieの一覧を表示。いま保存したばかりのデータも一緒に表示する
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
