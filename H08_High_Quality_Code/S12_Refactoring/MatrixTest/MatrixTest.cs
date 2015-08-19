namespace MatrixTest
{
    using System;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MatrixProgram;

    [TestClass]
    public class MatrixTest
    {        
        [TestMethod]
        public void TestChamngeWalkDirectionTopLeftDiagonal()
        {
            int dx = 1;
            int dy = 1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(1, dx);
            Assert.AreEqual(0, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionLeftDiagonal()
        {
            int dx = 1;
            int dy = 0;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(1, dx);
            Assert.AreEqual(-1, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionLeftBottomDiagonal()
        {
            int dx = 1;
            int dy = -1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(0, dx);
            Assert.AreEqual(-1, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionBottomDiagonal()
        {
            int dx = 0;
            int dy = -1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(-1, dx);
            Assert.AreEqual(-1, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionRightBottomDiagonal()
        {
            int dx = -1;
            int dy = -1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(-1, dx);
            Assert.AreEqual(0, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionRightDiagonal()
        {
            int dx = -1;
            int dy = 0;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(-1, dx);
            Assert.AreEqual(1, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionRightTopDiagonal()
        {
            int dx = -1;
            int dy = 1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(0, dx);
            Assert.AreEqual(1, dy);
        }

        [TestMethod]
        public void TestChamngeWalkDirectionTopDiagonal()
        {
            int dx = 0;
            int dy = 1;
            Matrix.ChangeWalkDirection(ref dx, ref dy);
            Assert.AreEqual(1, dx);
            Assert.AreEqual(1, dy);
        }
       
        [TestMethod]
        public void TestIsAnyPosibleWalkDirectionFalse()
        {
            int x = 1;
            int y = 1;
            int[,] matrix = new int[3, 3] { {1, 2, 3 },
                                           {4, 2, 6 },
                                           {8, 7, 3 }};
            bool isPosiblDirection = Matrix.IsAnyPosibleWalkDirection(matrix, x, y);
            Assert.IsFalse(isPosiblDirection, "Return true, but hadn't possible walk direction.");
        }

        [TestMethod]
        public void TestIsAnyPosibleWalkDirection_One()
        {
            int x = 1;
            int y = 1;
            int[,] matrix = new int[3, 3] { {1, 2, 3 },
                                           {4, 2, 6 },
                                           {8, 7, 0 }};
            bool isPosiblDirection = Matrix.IsAnyPosibleWalkDirection(matrix, x, y);
            Assert.IsTrue(isPosiblDirection, "It has a possible walk direction, but is not found.");
        }

        [TestMethod]
        public void TestIsAnyPosibleWalkDirection_Two()
        {
            int x = 1;
            int y = 1;
            int[,] matrix = new int[3, 3] { {1, 2, 3 },
                                           {4, 2, 0 },
                                           {8, 7, 0 }};
            bool isPosiblDirection = Matrix.IsAnyPosibleWalkDirection(matrix, x, y);
            Assert.IsTrue(isPosiblDirection, "It has a possible walk direction, but is not found.");
        }

        [TestMethod]
        public void TestIsAnyPosibleWalkDirection_Four()
        {
            int x = 1;
            int y = 1;
            int[,] matrix = new int[3, 3] { {1, 0, 3 },
                                           {0, 2, 0 },
                                           {8, 0, 3 }};
            bool isPosiblDirection = Matrix.IsAnyPosibleWalkDirection(matrix, x, y);
            Assert.IsTrue(isPosiblDirection, "It has a possible walk direction, but is not found.");
        }

        [TestMethod]
        public void TestIsAnyPosibleWalkDirection_All()
        {
            int x = 1;
            int y = 1;
            int[,] matrix = new int[3, 3] { {0, 0, 0 },
                                           {0, 1, 0 },
                                           {0, 0, 0 }};
            bool isPosiblDirection = Matrix.IsAnyPosibleWalkDirection(matrix, x, y);
            Assert.IsTrue(isPosiblDirection, "It has a possible walk direction, but is not found.");
        }
       
        [TestMethod]
        public void TestFindNotVisitedCellForEmptyMatrix()
        {
            int x;
            int y;
            int[,] matrix = new int[3, 3] { {0, 0, 0 },
                                           {0, 0, 0 },
                                           {0, 0, 0 }};
            bool isFoundCell = Matrix.FindNotVisitedCell(matrix, out x, out y);
            Assert.IsTrue(isFoundCell, "Cell not found");
            Assert.AreEqual(0, x, "Found element has wrong x position.");
            Assert.AreEqual(0, y, "Found element has wrong y position.");
        }

        [TestMethod]
        public void TestFindNotVisitedCellForAllFullMatrix()
        {
            int x;
            int y;
            int[,] matrix = new int[3, 3] { {1, 7, 8 },
                                           {6, 2, 9 },
                                           {5, 4, 3 }};
            bool isFoundCell = Matrix.FindNotVisitedCell(matrix, out x, out y);
            Assert.IsFalse(isFoundCell, "Cell found");
        }

        [TestMethod]
        public void TestFindNotVisitedCellForSemiFullMatrix()
        {
            int x;
            int y;
            int[,] matrix = new int[3, 3] { {1, 7, 8 },
                                           {0, 0, 9 },
                                           {0, 0, 0 }};
            bool isFoundCell = Matrix.FindNotVisitedCell(matrix, out x, out y);
            Assert.IsTrue(isFoundCell, "Cell not found");
            Assert.AreEqual(1, x, "Found element has wrong x position.");
            Assert.AreEqual(0, y, "Found element has wrong y position.");
        }

        [TestMethod]
        public void TestFindNotVisitedCellForSemiFullMatrix1()
        {
            int x;
            int y;
            int[,] matrix = new int[3, 3] { {1, 7, 8 },
                                           {4, 2, 0 },
                                           {5, 0, 0 }};
            bool isFoundCell = Matrix.FindNotVisitedCell(matrix, out x, out y);
            Assert.IsTrue(isFoundCell, "Cell not found");
            Assert.AreEqual(1, x, "Found element has wrong x position.");
            Assert.AreEqual(2, y, "Found element has wrong y position.");
        }        
    }
}
