// GoogleAppsScriptでSQLっぽくDBを扱えるライブラリを作りました。
// https://qiita.com/roana0229/items/fea931fcabc57f193620

function myFunction() {
  try{
    var id = '16G7aZUhrQta4YdBKBd4nfR_la9merzOmcS-8vsYou2M';
    var name = 'covid19';
    var sssql = new SpreadSheetsSQL();
//    sssql.open(id, name)
    
    var array = sssql.open(id, name).select(['No', ',公表_年月日', '患者_年代', '患者_性別']).filter('患者_年代 = 20代').result();
    console.log(array);
  }catch(e){
    Logger.log(e);
  }
}

function createDatabase(){
   var data = new google.visualization.arrayToDataTable([
     ['名前', '給料', '到達率'],
     ['Mike',  10000, 0.2 ],
     ['Jim',   8000,  1.0],
     ['Alice', 12500, 0.9 ],
     ['Bob',   7000, 0.7 ]
 ]);
  
  console.log(data);
}

function sample_sendMailChart() {

  // データ構造の定義
  var data = Charts.newDataTable()
      .addColumn(Charts.ColumnType.STRING, '勉強会名')
      .addColumn(Charts.ColumnType.NUMBER, '参加者数')
      .addColumn(Charts.ColumnType.NUMBER, 'キャンセル数');  

  // テストデータを積める
  data.addRow(['A001:勉強会1',10,1])
      .addRow(['A002:勉強会2',8,2])
      .addRow(['A003:勉強会3',9,3])
      .addRow(['A004:勉強会4',14,4])
      .addRow(['A005:勉強会5',22,0])
      .build();

  // グラフにテストデータをセットして画像にする
  var chart = Charts.newColumnChart()
      .setDataTable(data)
      .setOption('legend.position', 'in') //凡例をグラフの内側にする
      .setStacked() //グラフを積み上げ式にする
      .build()
      .getBlob();  

  // メールで作成したグラフ画像を埋め込んで送信
  MailApp.sendEmail({
    to: 'sakura.mille.feuille@gmail.com', // 自分用に変更する
    subject: '【test】GASでChart',
    htmlBody: "チャートサンプル：<img src='cid:sampleCharts'> です! <br>",
    inlineImages: {
      sampleCharts: chart
    }
  });
}