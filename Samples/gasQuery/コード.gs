// GoogleAppsScript��SQL���ۂ�DB�������郉�C�u���������܂����B
// https://qiita.com/roana0229/items/fea931fcabc57f193620

function myFunction() {
  try{
    var id = '16G7aZUhrQta4YdBKBd4nfR_la9merzOmcS-8vsYou2M';
    var name = 'covid19';
    var sssql = new SpreadSheetsSQL();
//    sssql.open(id, name)
    
    var array = sssql.open(id, name).select(['No', ',���\_�N����', '����_�N��', '����_����']).filter('����_�N�� = 20��').result();
    console.log(array);
  }catch(e){
    Logger.log(e);
  }
}

function createDatabase(){
   var data = new google.visualization.arrayToDataTable([
     ['���O', '����', '���B��'],
     ['Mike',  10000, 0.2 ],
     ['Jim',   8000,  1.0],
     ['Alice', 12500, 0.9 ],
     ['Bob',   7000, 0.7 ]
 ]);
  
  console.log(data);
}

function sample_sendMailChart() {

  // �f�[�^�\���̒�`
  var data = Charts.newDataTable()
      .addColumn(Charts.ColumnType.STRING, '�׋��')
      .addColumn(Charts.ColumnType.NUMBER, '�Q���Ґ�')
      .addColumn(Charts.ColumnType.NUMBER, '�L�����Z����');  

  // �e�X�g�f�[�^��ς߂�
  data.addRow(['A001:�׋���1',10,1])
      .addRow(['A002:�׋���2',8,2])
      .addRow(['A003:�׋���3',9,3])
      .addRow(['A004:�׋���4',14,4])
      .addRow(['A005:�׋���5',22,0])
      .build();

  // �O���t�Ƀe�X�g�f�[�^���Z�b�g���ĉ摜�ɂ���
  var chart = Charts.newColumnChart()
      .setDataTable(data)
      .setOption('legend.position', 'in') //�}����O���t�̓����ɂ���
      .setStacked() //�O���t��ςݏグ���ɂ���
      .build()
      .getBlob();  

  // ���[���ō쐬�����O���t�摜�𖄂ߍ���ő��M
  MailApp.sendEmail({
    to: 'sakura.mille.feuille@gmail.com', // �����p�ɕύX����
    subject: '�ytest�zGAS��Chart',
    htmlBody: "�`���[�g�T���v���F<img src='cid:sampleCharts'> �ł�! <br>",
    inlineImages: {
      sampleCharts: chart
    }
  });
}