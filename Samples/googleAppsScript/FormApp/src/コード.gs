//URLをたたいたときに呼ばれる
function doGet(req) {
  const template = 'form';
  return HtmlService.createTemplateFromFile(template).evaluate();
}
// CSSを読み込む関数
function include(filename) {
  return HtmlService.createHtmlOutputFromFile(filename).getContent();
}