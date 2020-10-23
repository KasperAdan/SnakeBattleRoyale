using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;


namespace SharedMap
{
    class MapData
    {
        public static readonly int COLUMNS = 80;
        public static readonly int ROWS = 45;

        public static Tiles[,] Map;
        public Snake[] Snakes;
        public static List<Point> Apples = new List<Point>();

        public MapData(string[] names, Color[] colors)
        {
            Map = new Tiles[ROWS, COLUMNS];
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Map[i, j] = Tiles.Empty;
                }
            }

            Snakes = new Snake[names.Count()];
            for (int i = 0; i < names.Count(); i++)
            {
                Snakes[i] = new Snake(names[i], GetStartPositions(i), colors[i]);
            }
            UpdateMap();
            for (int i = 0; i < names.Count() * 3; i++)

            {

                AddApple();

            }
            UpdateMap();
        }
        public MapData(string json)
        {
            Map = JsonConvert.DeserializeObject<Tiles[,]>(json);
        }

        public void UpdateDirection(string playerName, Direction newDirection)
        {
            foreach (Snake snake in Snakes)
            {
                if (snake.name == playerName)
                {

                    if (snake.previousMove == Direction.NONE)
                    {
                        if (snake.body[1].Y > snake.body[0].Y && newDirection != Direction.RIGHT)
                        {
                            snake.direction = newDirection;
                        }
                        else if (snake.body[1].Y < snake.body[0].Y && newDirection != Direction.LEFT)
                        {
                            snake.direction = newDirection;
                        }
                    }
                    else
                    {
                        switch (newDirection)
                        {
                            case Direction.UP:
                                if (snake.previousMove != Direction.DOWN)
                                {
                                    snake.direction = newDirection;
                                }
                                break;
                            case Direction.RIGHT:
                                if (snake.previousMove != Direction.LEFT)
                                {
                                    snake.direction = newDirection;
                                }
                                break;
                            case Direction.DOWN:
                                if (snake.previousMove != Direction.UP)
                                {
                                    snake.direction = newDirection;
                                }
                                break;
                            case Direction.LEFT:
                                if (snake.previousMove != Direction.RIGHT)
                                {
                                    snake.direction = newDirection;
                                }
                                break;
                            case Direction.NONE:
                                break;
                        }
                    }
                }
            }
        }

        public bool UpdateSnakes()
        {
            bool playerDied = false;
            foreach (var snake in Snakes)
            {
                if (snake.alive)
                {
                    snake.Update(Map);
                    if (!snake.alive)
                    {
                        playerDied = true;
                    }
                }
            }
            return playerDied;
        }

        public void UpdateMap()
        {
            //Clear map
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Map[i, j] = Tiles.Empty;
                }
            }

            //fill map
            for (int j = 0; j < Snakes.Count(); j++)
            {
                Snake snake = Snakes[j];
                if (snake.alive)
                {
                    for (int i = 0; i < snake.body.Count; i++)
                    {
                        if (i == 0)
                        {
                            Map[(int)snake.body[i].X, (int)snake.body[i].Y] = (Tiles)Enum.Parse(typeof(Tiles), $"HeadPlayer{j + 1}");
                        }
                        else
                        {
                            Map[(int)snake.body[i].X, (int)snake.body[i].Y] = (Tiles)Enum.Parse(typeof(Tiles), $"BodyPlayer{j + 1}");
                        }
                    }
                }
            }

            //Add apples
            foreach (var apple in Apples)
            {
                Map[apple.X, apple.Y] = Tiles.Apple;
            }
        }

        public string GetMapJson()
        {
            return JsonConvert.SerializeObject(Map);
        }

        public string GetPlayerJson()
        {
            JObject playerJson =
                new JObject(
                    new JProperty("amount", Snakes.Count()),
                    new JProperty("players",
                    new JArray(from s in Snakes
                               select
                                     new JObject(
                                         new JProperty("username", s.name),
                                         new JProperty("alive", s.alive),
                                         new JProperty("score", s.body.Count),
                                         new JProperty("color", s.color.ToArgb())))));
            return playerJson.ToString(Formatting.None);
        }

        public static void AddApple()
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(ROWS);
                int y = random.Next(COLUMNS);
                if (Map[x, y] == Tiles.Empty)
                {
                    Apples.Add(new Point(x, y));
                    return;
                }
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (Map[i, j] == Tiles.Empty)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(Map[i, j] + ", ");
                    }
                }
                Console.WriteLine();
            }
        }

        private List<Vector2> GetStartPositions(int player)
        {
            switch (player + 1)
            {
                case 1:
                    return new List<Vector2> {  { new Vector2(2, 7) },
                                                { new Vector2(2, 6) },
                                                { new Vector2(2, 5) },
                                                { new Vector2(2, 4) },
                                                { new Vector2(2, 3) },
                                                { new Vector2(2, 2) }};
                case 2:
                    return new List<Vector2> {  { new Vector2(2, 37) },
                                                { new Vector2(2, 38) },
                                                { new Vector2(2, 39) },
                                                { new Vector2(2, 40) },
                                                { new Vector2(2, 41) },
                                                { new Vector2(2, 42) }};
                case 3:
                    return new List<Vector2> {  { new Vector2(2, 72) },
                                                { new Vector2(2, 73) },
                                                { new Vector2(2, 74) },
                                                { new Vector2(2, 75) },
                                                { new Vector2(2, 76) },
                                                { new Vector2(2, 77) }};
                case 4:
                    return new List<Vector2> {  { new Vector2(22, 20) },
                                                { new Vector2(22, 19) },
                                                { new Vector2(22, 18) },
                                                { new Vector2(22, 17) },
                                                { new Vector2(22, 16) },
                                                { new Vector2(22, 15) }};
                case 5:
                    return new List<Vector2> {  { new Vector2(22, 60) },
                                                { new Vector2(22, 61) },
                                                { new Vector2(22, 62) },
                                                { new Vector2(22, 63) },
                                                { new Vector2(22, 64) },
                                                { new Vector2(22, 65) }};
                case 6:
                    return new List<Vector2> {  { new Vector2(43, 2) },
                                                { new Vector2(43, 3) },
                                                { new Vector2(43, 4) },
                                                { new Vector2(43, 5) },
                                                { new Vector2(43, 6) },
                                                { new Vector2(43, 7) }};
                case 7:
                    return new List<Vector2> {  { new Vector2(43, 37) },
                                                { new Vector2(43, 38) },
                                                { new Vector2(43, 39) },
                                                { new Vector2(43, 40) },
                                                { new Vector2(43, 41) },
                                                { new Vector2(43, 42) }};
                case 8:
                    return new List<Vector2> {  { new Vector2(43, 72) },
                                                { new Vector2(43, 73) },
                                                { new Vector2(43, 74) },
                                                { new Vector2(43, 75) },
                                                { new Vector2(43, 76) },
                                                { new Vector2(43, 77) }};
                default:
                    return new List<Vector2> { };
            }
        }

    }
}
