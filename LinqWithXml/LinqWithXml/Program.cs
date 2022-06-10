using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentXml =
                @"<Students>
                   <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                </Student>

                 <Student>
                        <Name>Carla</Name>
                        <Age>17</Age>
                        <University>Yale</University>
                </Student>

                 <Student>
                        <Name>Leyla</Name>
                        <Age>19</Age>
                        <University>Beijing Tech</University>
                </Student>
                </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc= XDocument.Parse(studentXml);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value
                           };
            foreach(var student in students)
            {
                Console.WriteLine("student with name {0}, age {1} and University {2}",student.Name,student.Age, student.University);
            }
            
            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;
            foreach(var student in sortedStudents)
            {
                Console.WriteLine("student with name {0}, age {1} and University {2}", student.Name, student.Age, student.University);
            }
            Console.ReadKey();
        }
    }
}
