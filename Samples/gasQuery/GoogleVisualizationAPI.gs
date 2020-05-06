var SS_URL = "https://docs.google.com/spreadsheets/d/16G7aZUhrQta4YdBKBd4nfR_la9merzOmcS-8vsYou2M/edit#gid=0";
var SS_ID = "16G7aZUhrQta4YdBKBd4nfR_la9merzOmcS-8vsYou2M";
var SH_ID = "645988052";
var BASE_URL = "https://docs.google.com/spreadsheets/d/";
var URL = BASE_URL + SS_ID + "/gviz/tq?gid=" + SH_ID + "&tqx=out:json&tq=";

SpreadsheetApp.openById(SS_ID);

function get_public_data() {
  var options = null;
  data_via_gviz(options);
}

function get_private_data() {
  var access_token = get_access_token();
  var headers = get_headers(access_token);
  var options = get_options(headers);
  data_via_gviz(options);
}

function get_access_token() {
  var access_token = ScriptApp.getOAuthToken();
  return access_token;
}

function get_headers(access_token) {
  var headers = {
    "Authorization": "Bearer " + access_token
  }
  return headers;
}

function get_options(headers) {
  var options = {
    "contentType": "application/json",
    "headers": headers,
    "muteHttpExceptions": true
  }
  return options;
}

function data_via_gviz(options) {
  var query = encodeURIComponent("SELECT A, B");
  var response = UrlFetchApp.fetch(URL + query, options);
  var jobj = get_jobj(response);
  var array = get_array(jobj);
  Logger.log([response, array]);
}

function get_jobj(response) {
  var data = response.getContentText();
  data = data.split("google.visualization.Query.setResponse(")[1];
  data = data.substr(0, data.length - 2);
  var jobj = JSON.parse(data);
  return jobj;
}

function get_array(jobj) {
  var rowlen = jobj["table"]["rows"].length;
  var collen = jobj["table"]["cols"].length;
  var array = [];
  for (var i = 0; i < rowlen; i++) {
    var values = [];
    for (var j = 0; j < collen; j++) {
      values.push(jobj["table"]["rows"][i]["c"][j]["v"]);
    }
    array.push(values);
  }
  return array;
}