using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;


namespace SharedMap
{
    class MapData
    {
        public static readonly int COLUMNS = 80;
        public static readonly int ROWS = 45;

        private Tiles[,] Map;
        private Snake[] Snakes;

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
        }

        public MapData(string json)
        {
            Map = JsonConvert.DeserializeObject<Tiles[,]>(json);
        }

        public void UpdateSnakes()
        {
            foreach (var snake in Snakes)
            {
                snake.Update();
            }
        }

        private void UpdateMap()
        {
            //check for collision 

            //Clear map
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Map[i, j] = Tiles.Empty;
                }
            }

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
        }



        public string GetMapJson()
        {
            return JsonConvert.SerializeObject(Map);
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
