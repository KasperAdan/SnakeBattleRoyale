using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SharedMap
{
    class Snake
    {
        public string name;
        public bool alive;
        public Direction direction;
        public List<Vector2> body;
        public Color color;
        public Direction previousMove = Direction.NONE;

        public Snake(string name, List<Vector2> body, Color color)
        {
            this.name = name;
            this.alive = true;
            this.direction = Direction.NONE;
            this.body = body;
            this.color = color;
        }

        internal void Update(Tiles[,] map)
        {
            int newHeadX = (int)body[0].X;
            int newHeadY = (int)body[0].Y;
            previousMove = direction;
            switch (direction)
            {
                case Direction.UP:
                    newHeadX = (int)body[0].X - 1;
                    break;
                case Direction.RIGHT:
                    newHeadY = (int)body[0].Y + 1;
                    break;
                case Direction.DOWN:
                    newHeadX = (int)body[0].X + 1;
                    break;
                case Direction.LEFT:
                    newHeadY = (int)body[0].Y - 1;
                    break;
                case Direction.NONE:
                    return;
            }

            if (newHeadX < 0 || newHeadX >= MapData.ROWS || newHeadY < 0 || newHeadY >= MapData.COLUMNS)
            {
                alive = false;
            }
            else
            {
                Tiles newTile = map[newHeadX, newHeadY];
                List<Vector2> newBody = new List<Vector2>();

                switch (newTile)
                {
                    case Tiles.Empty:
                        newBody.Add(new Vector2(newHeadX, newHeadY));
                        for (int i = 0; i < body.Count-1; i++)
                        {
                            newBody.Add(new Vector2(body[i].X, body[i].Y));
                        }
                        body = newBody;
                        break;
                    case Tiles.HeadPlayer1:
                    case Tiles.HeadPlayer2:
                    case Tiles.HeadPlayer3:
                    case Tiles.HeadPlayer4:
                    case Tiles.HeadPlayer5:
                    case Tiles.HeadPlayer6:
                    case Tiles.HeadPlayer7:
                    case Tiles.HeadPlayer8:
                        this.alive = false;
                        break;
                    case Tiles.BodyPlayer1:
                    case Tiles.BodyPlayer2:
                    case Tiles.BodyPlayer3:
                    case Tiles.BodyPlayer4:
                    case Tiles.BodyPlayer5:
                    case Tiles.BodyPlayer6:
                    case Tiles.BodyPlayer7:
                    case Tiles.BodyPlayer8:
                        this.alive = false;
                        break;
                    case Tiles.Apple:
                        newBody.Add(new Vector2(newHeadX, newHeadY));
                        for (int i = 0; i < body.Count; i++)
                        {
                            newBody.Add(new Vector2(body[i].X, body[i].Y));
                        }
                        body = newBody;
                        MapData.Apples.Remove(new Point(newHeadX, newHeadY));
                        MapData.AddApple();
                        break;
                }
            }
        }
    }
}
