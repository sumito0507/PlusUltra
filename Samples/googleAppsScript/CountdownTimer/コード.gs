
function doGet(e){
  //indexファイルのオブジェクト
  var htmlOutput = HtmlService.createTemplateFromFile("countdown");
  htmlOutput.message = 'hoge';
  
  return htmlOutput.evaluate()
    .setTitle('Sample')
    .addMetaTag('viewport', 'width=device-width, initial-scale=1');
}

function getHelloWorld() {
  return '<h1>hello world</h1>';
}


function doPost(e) {
  var ss       = SpreadsheetApp.getActiveSpreadsheet();
  var sheet    = ss.getSheetByName('シート1');
//  var PostData = JSON.parse(e.postData.contents);
//
//  // 行の最後に値を追加
//  sheet.appendRow([PostData.fruit, PostData.price]);
  console.log('doPost !!');
  console.info(e.postData.contents);
  // 結果を返す  
  var output = ContentService.createTextOutput();
  output.setMimeType(ContentService.MimeType.JSON);
  output.setContent(JSON.stringify({ message: "success!" }));
  return output;
//  return ContentService.createTextOutput("Hello World");
//  return ContentService.createTextOutput(e.postData.contents);
}

function myFunction() {
  Logger.log(DriveApp.getRootFolder().getName());
  Logger.log(ScriptApp.getOAuthToken());
}
