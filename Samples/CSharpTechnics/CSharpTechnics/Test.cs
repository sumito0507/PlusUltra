using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnics
{
    // 【C#】ショートコード・テクニック
    // https://qiita.com/kyohmizu/items/b7b8de409d9e5b0f2626

    class Test
    {
        //public void ResetScore(Student student)
        //{
        //    if (student != null)
        //    {
        //        student.SetScore(0);
        //    }
        //}
        public void ResetScore(Student student) => student?.SetScore(0);// ★null条件演算子

        //public IEnumerable<Student> CreateSample(int count)
        //{
        //    var students = new List<Student>();
        //    for (int number = 1; number <= count; number++)
        //    {
        //        students.Add(new Student($"生徒{number.ToString()}", number));
        //    }
        //    return students;
        //}
        public IEnumerable<Student> CreateSample(int count) => Enumerable.Range(1, count).Select(number => new Student($"生徒{number.ToString()}", number));// ★Enumerableクラス　Range

        //public IEnumerable<Student> GetAllStudents(IEnumerable<Teacher> teachers)
        //{
        //    var students = new List<Student>();
        //    foreach (var teacher in teachers)
        //    {
        //        students.AddRange(teacher.Students);
        //    }
        //    return students;
        //}
        public IEnumerable<Student> GetAllStudents(IEnumerable<Teacher> teachers) => teachers.SelectMany(teacher => teacher.Students);// ★SelectMany

        //public IEnumerable<String> GetStudentNames(IEnumerable<Person> people)
        //{
        //    var studentNames = new List<string>();
        //    foreach (var person in people)
        //    {
        //        var student = person as Student;
        //        if (student != null)
        //        {
        //            studentNames.Add(student.Name);
        //        }
        //    }
        //    return studentNames;
        //}
        public IEnumerable<String> GetStudentNames(IEnumerable<Person> people) => people.OfType<Student>().Select(student => student.Name);// ★OfType
    }
}
