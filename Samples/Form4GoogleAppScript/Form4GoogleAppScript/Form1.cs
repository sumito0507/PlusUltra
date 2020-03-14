using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
 * [Google Apps Script]認証が必要なウェブアプリケーションを外部から実行する
 * https://www.ka-net.org/blog/?p=12258
 */
namespace Form4GoogleAppScript
{
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    public partial class Form1 : Form
    {
        /// <summary>
        /// URL
        /// </summary>
        private static readonly string _URL = $"https://script.google.com/macros/s/AKfycbw9yK4jnj3xWejpvYIAJXzXRNuGwZFwr5ZQajnx1xrD28Qc8Ms/exec";
        /// <summary>
        /// OAuth認証のアクセストークン
        /// </summary>
        private static readonly string _AccessToken = $"ya29.a0Adw1xeXFwluMcIS7zAPga7-iIqxAwgy4YpFncYbHY0s-Z8WDOqggn-JgADe24skeET9eRKGSmyV_OF6vMozivzWng4JUoQmOfvtiOX3n5fQo196LgPiL8Y2sbFIYZ40O0KMhFFNS3yrlCtw9kDLPixWFZD-A7L6BI2fx";

        /// <summary>
        /// HTTPリクエスト
        /// </summary>
        /// <remarks>
        /// リソースを食いつぶさいないために、使いまわす。ソケットオープンは1度。
        /// https://qiita.com/nskhara/items/b7c31d60531ffbe29537
        /// </remarks>
        private static HttpClient _HttpClient = new HttpClient();

        private string _Result = "";

        /// <summary>
        /// マウスのクリック位置
        /// </summary>
        private Point mousePoint;

        /***********************************************************************************************************
         * curlコマンドで実行する場合
         * curl -L -d "Hello world." -H "Authorization: Bearer ya29.a0Adw1xeWnwmaNBAq154dA8gdntXgHVlFuMzpin4xsAnWMaCCL9O1jcntfwVK6SKXUN9m9FRayjC1Hd1-XVE3nu8nIC4oD0Z12WQ0znjPLKatKVzvvS1b6oXFoYTugwvkcrX6wG-EjRS-UIracinRQzwMLRFEnfefXWH9V" "https://script.google.com/macros/s/AKfycbw9yK4jnj3xWejpvYIAJXzXRNuGwZFwr5ZQajnx1xrD28Qc8Ms/exec"
         * curl -L -d "Hello world." -H "Authorization: Bearer ya29.a0Adw1xeXFwluMcIS7zAPga7-iIqxAwgy4YpFncYbHY0s-Z8WDOqggn-JgADe24skeET9eRKGSmyV_OF6vMozivzWng4JUoQmOfvtiOX3n5fQo196LgPiL8Y2sbFIYZ40O0KMhFFNS3yrlCtw9kDLPixWFZD-A7L6BI2fx" "https://script.google.com/macros/s/AKfycbw9yK4jnj3xWejpvYIAJXzXRNuGwZFwr5ZQajnx1xrD28Qc8Ms/exec"
         * 
         ************************************************************************************************************/

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void SendData()
        {
            //文字コードを指定する
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("shift_jis");

            //POST送信する文字列を作成
            string postData = "inlang=ja&word=" + System.Web.HttpUtility.UrlEncode("インターネット", enc);
            //バイト型配列に変換
            byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

            //WebRequestの作成
            System.Net.WebRequest req = System.Net.WebRequest.Create("http://www.e-words.ne.jp/search.asp");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = postDataBytes.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            Console.WriteLine(sr.ReadToEnd());
            //閉じる
            sr.Close();
        }


        /// <summary>
        /// HttpClientを使ったデータ送信
        /// </summary>
        private async void SendDatabyHttpClient()
        {
            try
            {


                // OAuth2認証
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken);
                //            var dict = new Dictionary<string, string>() 
                //{
                //    { "type", "embed" },
                //};
                //            var json = JsonSerializer.Serialize(dict);
                //            var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Content-Typeの設定
                var content = new StringContent("Hello world.", Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await _HttpClient.PostAsync(_URL, content);

                var task = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(task);
                textBoxResult.Text = task;
                //return task;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //return null;
            }
        }


        /// <summary>
        /// [イベント]POST送信ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPost_Click(object sender, EventArgs e)
        {
            string command = $"curl -L -d 'Hello world.' -H " + @"""Authorization: Bearer ya29.a0Adw1xeXh5loTQHLmCvfUkUafXb16bpBtY8jN_vKMcczkiyEpyu7_MtYzRBu-09oyp4TmGUuVHDJKqdc0JmvvLDg5bz2YcC8Lc1uQj-cTf87kRmPCSKSLm9f8HXN4wqeM32NZHC30VzBEcINJsX-NUzdUSXee9H6sNM0""" + " " + @"""https://script.google.com/macros/s/AKfycbwo2b2z56QS8d5I1clxqI5nw-3jJNQlhC_NsboS8QGFvd09oWwX/exec""";
#if false
            Process proc = new Process();
            proc.StartInfo.FileName = "curl";
            proc.StartInfo.Arguments = "-L -d 'Hello world.' -H " + @"""Authorization: Bearer ya29.a0Adw1xeXh5loTQHLmCvfUkUafXb16bpBtY8jN_vKMcczkiyEpyu7_MtYzRBu-09oyp4TmGUuVHDJKqdc0JmvvLDg5bz2YcC8Lc1uQj-cTf87kRmPCSKSLm9f8HXN4wqeM32NZHC30VzBEcINJsX-NUzdUSXee9H6sNM0""" + " " + @"""https://script.google.com/macros/s/AKfycbwo2b2z56QS8d5I1clxqI5nw-3jJNQlhC_NsboS8QGFvd09oWwX/exec""";
            proc.Start();
            proc.WaitForExit();
            Console.WriteLine(proc.ExitCode.ToString());
#endif
            SendDatabyHttpClient();
        }

        /// <summary>
        /// [イベント]ロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // フォームの境界線、タイトルバーを無しに設定
            this.FormBorderStyle = FormBorderStyle.None;
            // フォームの不透明度を60%に設定（半透明化）
            this.Opacity = 1;

            int radius = 20;
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            // 左上
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            // 右上
            gp.AddPie(this.Width - diameter, 0, diameter, diameter, 270, 90);
            // 左下
            gp.AddPie(0, this.Height - diameter, diameter, diameter, 90, 90);
            // 右下
            gp.AddPie(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
            // 中央
            gp.AddRectangle(new Rectangle(radius, 0, this.Width - diameter, this.Height));
            // 左
            gp.AddRectangle(new Rectangle(0, radius, radius, this.Height - diameter));
            // 右
            gp.AddRectangle(new Rectangle(this.Width - radius, radius, radius, this.Height - diameter));

            this.Region = new Region(gp);

        }

        /// <summary>
        /// [イベント]右クリックメニュー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// [Form1のMouseMoveイベントハンドラ]
        /// マウスのボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        /// <summary>
        /// [Form1のMouseMoveイベントハンドラ]
        /// マウスが動いたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
                //または、つぎのようにする
                //this.Location = new Point(
                //    this.Location.X + e.X - mousePoint.X,
                //    this.Location.Y + e.Y - mousePoint.Y);
            }
        }
    }
}
