using System;
using Xunit;
using SystemIO;

namespace XUnitSystemIOTDD
{
    public class UnitTest1
    {

        [Fact]
        public void createfile()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "harry", "sally" };
            Program.CreateFile(path, initialWords);
        }
            
        [Fact]
        public void createfile2()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "jimmy", "john" };
            Program.CreateFile(path, initialWords);
            
        }

        [Fact]
        public void createfile3()
        {
            string path = "../../../test.txt";
            string[] initialWords = { "apple", "oranges" };
            Program.CreateFile(path, initialWords);
            
        }

        [Fact]
        public void WordAdd()
        {
            string path = "../../../test.txt";
            Program.WordAdd(path, "coco");

            Assert.Contains("coco", Program.ReadWords(path));
        }
        [Fact]
        public void WordAdd2()
        {
            string path = "../../../test.txt";
            Program.WordAdd(path, "dog");

            Assert.Contains("dog", Program.ReadWords(path));
        }
        [Fact]
        public void WordAdd3()
        {
            string path = "../../../test.txt";
            Program.WordAdd(path, "dorthy");

            Assert.Contains("coco", Program.ReadWords(path));
        }


        [Fact]
        public void WordRemove()
        {
            string path = "../../../test.txt";
            Program.WordRemove(path, "coco");

            Assert.DoesNotContain("coco", Program.ReadWords(path));
        }

        [Fact]
        public void WordRemove2()
        {
            string path = "../../../test.txt";
            Program.WordRemove(path, "harry");

            Assert.DoesNotContain("harry", Program.ReadWords(path));
        }

        [Fact]
        public void WordRemove3()
        {
            string path = "../../../test.txt";
            Program.WordRemove(path, "jimmy");

            Assert.DoesNotContain("jimmy", Program.ReadWords(path));
        }
    }
}
