function myFunction() {
  
}
function doGet(e){
  //indexファイルのオブジェクト
  var htmlOutput = HtmlService.createTemplateFromFile("countdown").evaluate();
  htmlOutput
    .setTitle('Sample')
    .addMetaTag('viewport', 'width=device-width, initial-scale=1')
  return htmlOutput;
}