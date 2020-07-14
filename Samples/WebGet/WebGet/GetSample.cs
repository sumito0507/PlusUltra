using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGet
{
    class GetSample
    {
        public bool Execute(string url)
        {
            try
            {

                //HttpWebRequestを作成
#if false
                System.Net.HttpWebRequest webreq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                //または、
#else
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
#endif
                //サーバーからの応答を受信するためのHttpWebResponseを取得
                System.Net.HttpWebResponse webres = (System.Net.HttpWebResponse)webreq.GetResponse();
                //または、
                //System.Net.WebResponse webres = webreq.GetResponse();

                //応答データを受信するためのStreamを取得
                System.IO.Stream st = webres.GetResponseStream();
                //文字コードを指定して、StreamReaderを作成
                System.IO.StreamReader sr = new System.IO.StreamReader(st, System.Text.Encoding.UTF8);
                //System.Text.Encoding shift_jis = System.Text.Encoding.GetEncoding("shift_jis");

                //データをすべて受信
                string htmlSource = sr.ReadToEnd();
                //閉じる
                st.Close();
                webres.Close();
                //「st.Close()」や「webres.Close()」だけでもよい

                //取得したソースを表示する
                Console.WriteLine(htmlSource);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return true;
        }
    }
}
