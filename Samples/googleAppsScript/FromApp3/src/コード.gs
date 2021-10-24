/** @format */
/**
 * @OnlyCurrentDoc
 */
/**
 * 2020年6月最新版【仕様変更対応済み】Googleフォームを好きなようにカスタマイズする方法
 * https://www.gorilla-web.net/2020new_google_form_custmize/
 * Googleフォームのデザインをカスタマイズする方法 プラグイン不要で簡単実装！
 * https://tekito-style.me/columns/googleform-design-customize
 * Googleフォームを自由にデザインカスタマイズする方法
 * https://medium.com/@yonemoto/google%E3%83%95%E3%82%A9%E3%83%BC%E3%83%A0%E3%82%92%E8%87%AA%E7%94%B1%E3%81%AB%E3%83%87%E3%82%B6%E3%82%A4%E3%83%B3%E3%82%AB%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%A4%E3%82%BA%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95-f91a617b402b
 * 【デザイン】Google Formをカスタマイズしてみる【Google Form】
 * https://makimakimakino.hatenablog.com/entry/2019/04/20/234842
 * GoogleAppsScriptを使ってGoogleフォームの画面を自由にカスタマイズする！
 * https://masa-enjoy.com/gas-createform
 */

function myFunction() {}

function doGet() {
  const toppage = HtmlService.createTemplateFromFile("index")
  return toppage.evaluate()
}

function include(filename) {
  return HtmlService.createHtmlOutputFromFile(filename).getContent()
}

function getUserAccount() {
  console.log(`Session.getUser().getEmail()             = ${Session.getUser().getEmail()}`)
  console.log(`Session.getActiveUser().getEmail()       = ${Session.getActiveUser().getEmail()}`)
  console.log(`Session.getActiveUser().getUserLoginId() = ${Session.getActiveUser().getUserLoginId()}`)
  console.log(`Session.getEffectiveUser().getEmail()    = ${Session.getEffectiveUser().getEmail()}`)
  return Session.getActiveUser().getEmail()
}

function doPost(postdata) {
  console.log(`postdata = ${JSON.stringify(postdata, null, "\t")}`)

  var sh = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet()
  var time = new Date()

  var username = postdata.parameters.username.toString()
  var description = postdata.parameters.description.toString()

  console.info(`username = ${username}`)
  console.info(`description = ${description}`)
  // sh.appendRow([time, username, description]);

  var resultpage = HtmlService.createTemplateFromFile("result")
  return resultpage.evaluate()
}
