var responseStringOriginal =  oSession.GetResponseBodyAsString();  
FiddlerObject.log(responseStringOriginal); 
var responseJSON = Fiddler.WebFormats.JSON.JsonDecode(responseStringOriginal);
MessageBox.Show(responseJSON.JSONObject["data"]["list"]["2"]["uvSe"]);
MessageBox.Show(responseJSON.JSONObject["data"]["list"]["2"]);
MessageBox.Show(responseJSON.JSONObject["data"]["list"]);
MessageBox.Show(responseJSON.JSONObject["data"]);

responseJSON.JSONObject["data"]["list"]["2"]["uvSe"] = "[1111.00,1639.00,1162.00,1562.00,1784.00,1724.00,1637.00]";
var responseStringDestinal = Fiddler.WebFormats.JSON.JsonEncode(responseJSON.JSONObject);
FiddlerObject.log(responseStringDestinal);
oSession.utilSetResponseBody(responseStringDestinal);


var s = '{"traceId":"0a67bcb114960691278571273e56e1","code":0,"message":"操作成功","data":{"lastDay":"2017-05-28","list":[{"TDay": "2017-05-28","2":{"payBuyerCntSe":[699.00,682.00,674.00,945.00,1113.00,923.00,1015.00],"payItemQty":[1790.00,1396.00,1036.00,1355.00,1558.00,1513.00,1445.00],"clickRate":[0,0,0,0,0,0,0],"itemUv":[20232.00,15640.00,11115.00,10321.00,11726.00,10742.00,10552.00],"sePayRate":[0.1171,0.1023,0.0928,0.1329,0.1373,0.1311,0.1413],"expose":[0.00,0.00,0.00,0.00,0.00,0.00,0.00]}}]}}';
var j = Fiddler.WebFormats.JSON.JsonDecode(s);
j.JSONObject["data"]["list"][0]["2"]["payBuyerCntSe"] = '[ 99999.00, 1396.00, 1036.00, 1355.00, 1558.00, 1513.00, 1445.00 ]';
MessageBox.Show(j.JSONObject["data"]["list"][0]["2"]["payBuyerCntSe"]);