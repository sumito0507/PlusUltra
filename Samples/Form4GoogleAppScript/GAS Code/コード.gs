function myFunction() {
  Logger.log(DriveApp.getRootFolder().getName());
  Logger.log(ScriptApp.getOAuthToken());
}

function doPost(e) {
  return ContentService.createTextOutput(e.postData.contents);
}

function doGet() {
//  return HtmlService.createHtmlOutputFromFile('index');
  return HtmlService.createTemplateFromFile("index").evaluate();
}

function getData(tag){
  if(tag == "title"){
    return "Hello!";
  }else if(tag == "token"){
    return ScriptApp.getOAuthToken();
  }
}