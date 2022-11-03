using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestFramework.Extensions;
using TestFramework.Models;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Project p = new Project();

            TestResult res = p.ToTestObject(true).Required((Project project) => project.Name, "Name for a project is required").Execute();

            Console.WriteLine(res.Errors.First());

            Console.ReadKey();
        }
    }

    
    public class Project
    {
        public string Name { get; set; } = null;

        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public List<string> TeamMembers { get; set; }
    }
}
