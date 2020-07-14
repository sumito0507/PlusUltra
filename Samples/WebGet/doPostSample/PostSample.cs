using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doPostSample
{
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Windows.Forms;

    class PostSample
    {
        private const string url = "https://script.google.com/macros/s/AKfycbxnYNiM32bZPHpp7KRYX00pnqsKZtxmIzI4Ke1jcaahOoz3fuY/exec";
        private const string AccessToken = "ya29.a0AfH6SMBTV5F9mwdkK2gIusoRfaxqmTkddpc-FWQTVYZS3-N-ptyh_67nFIv_89Ut1sTPOnER3AE382qxgFRRknovxkmgPIGzdy0ZN_Zm340ul38rnmahUN90gWVstZYHNBRh9GpnRuAqh7y4ufjZyauLUIl7sWScZYFl";

        public async Task PostAsync()
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var content = new StringContent("hello", Encoding.UTF8, "text/plain");

            var response = await _httpClient.PostAsync(url, content);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.WriteLine("OK");
            }
        }

        public void WebRequestSample()
        {
            try
            {

                //文字コードを指定する
                System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

                //POST送信する文字列を作成
                string postData = "inlang=ja&word=" + System.Web.HttpUtility.UrlEncode("Hello world !!", enc);
                //バイト型配列に変換
                byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

                //WebRequestの作成
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                HttpWebRequest httpWebRequest = (HttpWebRequest)req;
                //メソッドにPOSTを指定
                httpWebRequest.Method = "POST";
                //ContentTypeを"application/x-www-form-urlencoded"にする
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                //POST送信するデータの長さを指定
                httpWebRequest.ContentLength = postDataBytes.Length;

                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.Accept = "application/json";




                //データをPOST送信するためのStreamを取得
                System.IO.Stream reqStream = httpWebRequest.GetRequestStream();
                //送信するデータを書き込む
                reqStream.Write(postDataBytes, 0, postDataBytes.Length);
                reqStream.Close();

                //サーバーからの応答を受信するためのWebResponseを取得
                long length = 0;
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                    {
                        length = response.ContentLength;
                        //応答データを受信するためのStreamを取得
                        System.IO.Stream resStream = response.GetResponseStream();
                        //受信して表示
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc))
                        {

                            Console.WriteLine(sr.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}

