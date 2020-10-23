using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;
using SharedMap;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace BoundaryTest
{
    [TestClass]
    public class UnitTest1
    {
        internal Tiles[,] Map { get; private set; }

        [TestInitialize]
        public void Init()
        {
            Map = new Tiles[45, 80];
            for (int i = 0; i < 45; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    Map[i, j] = Tiles.Empty;
                }
            }
        }

        [TestMethod]
        public void TestCeiling()
        {
            Snake snake = new Snake("test", new List<Vector2> { new Vector2(1, 40), new Vector2(2, 40), new Vector2(3, 40) }, Color.Black);
            snake.direction = Direction.UP;
            snake.Update(Map);
            Assert.IsTrue(snake.alive);
            snake.Update(Map);
            Assert.IsFalse(snake.alive);
        }
        [TestMethod]
        public void TestBottom()
        {
            Snake snake = new Snake("test", new List<Vector2> { new Vector2(43, 40), new Vector2(42, 40), new Vector2(41, 40) }, Color.Black);
            snake.direction = Direction.DOWN;
            snake.Update(Map);
            Assert.IsTrue(snake.alive);
            snake.Update(Map);
            Assert.IsFalse(snake.alive);
        }
        [TestMethod]
        public void TestLeftWall()
        {
            Snake snake = new Snake("test", new List<Vector2> { new Vector2(20, 1), new Vector2(20, 2), new Vector2(20, 3) }, Color.Black);
            snake.direction = Direction.LEFT;
            snake.Update(Map);
            Assert.IsTrue(snake.alive);
            snake.Update(Map);
            Assert.IsFalse(snake.alive);
        }
        [TestMethod]
        public void TestRightWall()
        {
            Snake snake = new Snake("test", new List<Vector2> { new Vector2(20, 78), new Vector2(20, 77), new Vector2(20, 76) }, Color.Black);
            snake.direction = Direction.RIGHT;
            snake.Update(Map);
            Assert.IsTrue(snake.alive);
            snake.Update(Map);
            Assert.IsFalse(snake.alive);
        }
    }
}
