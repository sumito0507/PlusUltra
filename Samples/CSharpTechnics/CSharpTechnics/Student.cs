using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnics
{
    // 【C#】ショートコード・テクニック
    // https://qiita.com/kyohmizu/items/b7b8de409d9e5b0f2626

    class Student :Person
    {
        private string _Name;
        private int _Number;
        private int _Score;
        //public string Name
        //{
        //    get { return _Name; }
        //}
        public string Name => _Name;// ★メソッド、プロパティのラムダ式記法
        //public int Number
        //{
        //    get { return _Number; }
        //}
        public int Number => _Number;// ★メソッド、プロパティのラムダ式記法
        //public int Score
        //{
        //    get { return _Score; }
        //}
        public int Score => _Score;// ★メソッド、プロパティのラムダ式記法
        public Student(string name, int number)
        {
            _Name = name;
            _Number = number;
        }
        //public void SetScore(int score)
        //{
        //    _Score = score;
        //} 
        public void SetScore(int score) => _Score = score;// ★メソッド、プロパティのラムダ式記法// 戻り値がないメソッド
        //public bool HasName()
        //{
        //    return string.IsNullOrEmpty(_Name);
        //}
        public bool HasName() => string.IsNullOrEmpty(_Name);// ★メソッド、プロパティのラムダ式記法// 戻り値があるメソッド

        //public int CompareNumber(Student student)
        //{
        //    int target = 0;
        //    if (student != null)
        //    {
        //        target = student.Number;
        //    }
        //    return _Number.CompareTo(target);
        //}
        public int CompareNumber(Student student) => _Number.CompareTo(student?.Number ?? 0);// ★null条件演算子＆null合体演算子
    }
}
