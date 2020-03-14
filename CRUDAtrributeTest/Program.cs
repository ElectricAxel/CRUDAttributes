using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAttribute;

namespace CRUDAtrributeTest {
    class Program {
        static void Main(string[] args) {

            Test t1 = new CRUDAtrributeTest.Test(1, "Hola");
            Test t2 = new CRUDAtrributeTest.Test(2, "Mundo");

            System.Console.WriteLine(BDBuilder.BuildInsert(t1));
            System.Console.WriteLine(BDBuilder.BuildInsert(t2));

            System.Console.ReadKey();
        }
    }


    [DBClassAttribute("Test")]
    class Test {

        [DBPropertyAttribute("IdTest")]
        public int TestId { get; set; }
        [DBPropertyAttribute("Nombre")]
        public string Name { get; set; }

        public Test() {
            TestId = 0;
            Name = "";
        }

        public Test(int testId, string name) {
            this.TestId = testId;
            this.Name = name;
        }
    }
}
