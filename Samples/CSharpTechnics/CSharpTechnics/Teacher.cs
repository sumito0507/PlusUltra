using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnics
{
    // 【C#】ショートコード・テクニック
    // https://qiita.com/kyohmizu/items/b7b8de409d9e5b0f2626

    class Teacher :Person
    {
        private List<Student> _Students = new List<Student>();
        //public List<Student> Students
        //{
        //    get { return _Students; }
        //}
        public List<Student> Students => _Students;

        public Teacher(IEnumerable<Student> students)
        {
            _Students.AddRange(students);
        }

        //public double AverageScore()
        //{
        //    if (_Students.Count == 0)
        //    {
        //        return 0;
        //    }
        //    return _Students.Average(student => student.Score);
        //}
        public double AverageScore() => _Students.Select(student => student.Score).DefaultIfEmpty(0).Average();// ★DefaultIfEmpty
    }
}
