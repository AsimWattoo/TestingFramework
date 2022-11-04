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
            Project project = new Project();

            TestObject<Project> proj = project.ToTestObject(true)
                .Required(p => p.Description, "Description for a project is required")
                .Length(p => p.Description, 3, 5, "Description should be in range 3 - 5 characters")
                .NumberRange(p => p.Id, 0, 100, "Id must be geater than 0 and less than 100");

            TestResult res = proj.Execute();

            Console.WriteLine(res);

            Console.ReadKey();
        }
    }

    
    public class Project
    {
        public string Name { get; set; } = null;

        public int Id { get; set; } = 1;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; } = "Hell";

        public List<string> TeamMembers { get; set; }
    }
}
