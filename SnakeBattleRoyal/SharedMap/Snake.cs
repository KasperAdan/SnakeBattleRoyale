using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace SharedMap
{
    class Snake
    {
        public string name;
        public bool alive;
        public Direction direction;
        public List<Vector2> body;
        public Color color;

        public Snake(string name, List<Vector2> body, Color color)
        {
            this.name = name;
            this.alive = true;
            this.direction = Direction.NONE;
            this.body = body;
            this.color = color;
        }

        internal void Update()
        {
            List<Vector2> newBody = new List<Vector2>();
            switch (direction)
            {
                case Direction.UP:
                    newBody.Add(new Vector2(body[0].X-1, body[0].Y));
                    for (int i = 0; i < body.Count-1; i++)
                    {
                        newBody.Add(body[i]);
                    }
                    break;
                case Direction.RIGHT:
                    newBody.Add(new Vector2(body[0].X, body[0].Y+1));
                    for (int i = 0; i < body.Count - 1; i++)
                    {
                        newBody.Add(body[i]);
                    }
                    break;
                case Direction.DOWN:
                    newBody.Add(new Vector2(body[0].X + 1, body[0].Y));
                    for (int i = 0; i < body.Count - 1; i++)
                    {
                        newBody.Add(body[i]);
                    }
                    break;
                case Direction.LEFT:
                    newBody.Add(new Vector2(body[0].X, body[0].Y - 1));
                    for (int i = 0; i < body.Count - 1; i++)
                    {
                        newBody.Add(body[i]);
                    }
                    break;
                case Direction.NONE:
                    break;
            }
            if (newBody[0].X < 0 || newBody[0].X > MapData.COLUMNS || newBody[0].Y < 0 || newBody[0].Y > MapData.ROWS)
            {
                alive = false;
            }
            else
            {
                body = newBody;
            }
        }
    }
}
