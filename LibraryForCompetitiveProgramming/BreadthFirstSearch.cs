using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesForCompetitiveProgramming.BreadthFirstSearch
{
    class BreadthFirstSearch
    {
        //arrayを使って書き換えたやつ
        public static int CheckExistPathUsingArray(bool[,] maze, int x, int y)
        {
            var queue = new Queue<int[]>();

            queue.Enqueue(new int[2] { x, y });

            var xSize = maze.GetLength(0);
            var ySize = maze.GetLength(1);

            var visited = new bool[xSize, ySize];
            var count = new int[xSize, ySize];

            visited[x, y] = true;

            var finished = false;

            while (!finished)
            {
                if (queue.Count == 0)
                {
                    finished = true;
                    continue;
                }

                var cell = queue.Dequeue();

                var right = new int[2] { cell[0] + 1, cell[1] };
                if (cell[0] < xSize - 1)
                {
                    if (maze[right[0], right[1]] && !visited[right[0], right[1]])
                    {
                        visited[right[0], right[1]] = true;
                        queue.Enqueue(new int[2] { right[0], right[1] });
                        count[right[0], right[1]] = count[cell[0], cell[1]] + 1;
                    }
                }

                var down = new int[2] { cell[0], cell[1] + 1 };
                if (cell[1] < ySize - 1)
                {
                    if (maze[down[0], down[1]] && !visited[down[0], down[1]])
                    {
                        visited[down[0], down[1]] = true;
                        queue.Enqueue(new int[2] { down[0], down[1] });
                        count[down[0], down[1]] = count[cell[0], cell[1]] + 1;
                    }
                }

                var left = new int[2] { cell[0] - 1, cell[1] };
                if (cell[0] > 0)
                {
                    if (maze[left[0], left[1]] && !visited[left[0], left[1]])
                    {
                        visited[left[0], left[1]] = true;
                        queue.Enqueue(new int[2] { left[0], left[1] });
                        count[left[0], left[1]] = count[cell[0], cell[1]] + 1;
                    }
                }


                var up = new int[2] { cell[0], cell[1] - 1 };
                if (cell[1] > 0)
                {
                    if (maze[up[0], up[1]] && !visited[up[0], up[1]])
                    {
                        visited[up[0], up[1]] = true;
                        queue.Enqueue(new int[2] { up[0], up[1] });
                        count[up[0], up[1]] = count[cell[0], cell[1]] + 1;
                    }
                }
            }

            var ans = 0;
            foreach (var score in count)
            {
                if (ans < score)
                {
                    ans = score;
                }
            }
            return ans;
        }

        //とりあえず力づくで書いてみたやつ
        public static int CheckExistPath(Maze maze, Cell start, Cell goal)
        {
            var queue = new Queue<int[]>();

            queue.Enqueue(new int[2] { start.X, start.Y });

            //そもそも配列で持たせた方が良い？
            foreach (var cell in maze.Map)
            {
                cell.Visited = false;
                cell.Count = 0;
            }
            start.Visited = true;


            var finished = false;

            var count = 0;

            var goalX = goal.X;
            var goalY = goal.Y;

            var ans = 0;

            while (!finished)
            {
                if (queue.Count == 0)
                {
                    finished = true;
                    continue;
                }

                var cell = queue.Dequeue();


                count++;


                var currentCount = maze.Map[cell[0], cell[1]].Count;


                var right = new int[2] { cell[0] + 1, cell[1] };
                if (cell[0] < maze.XSize - 1)
                {
                    if (maze.Map[right[0], right[1]].IsPath && !maze.Map[right[0], right[1]].Visited)
                    {
                        maze.Map[right[0], right[1]].Visited = true;
                        queue.Enqueue(new int[2] { right[0], right[1] });
                        maze.Map[right[0], right[1]].Count = currentCount + 1;
                    }
                }
                var down = new int[2] { cell[0], cell[1] + 1 };
                if (cell[1] < maze.YSize - 1)
                {
                    if (maze.Map[down[0], down[1]].IsPath && !maze.Map[down[0], down[1]].Visited)
                    {
                        maze.Map[down[0], down[1]].Visited = true;
                        queue.Enqueue(new int[2] { down[0], down[1] });
                        maze.Map[down[0], down[1]].Count = currentCount + 1;
                    }
                }
                var left = new int[2] { cell[0] - 1, cell[1] };
                if (cell[0] > 0)
                {
                    if (maze.Map[left[0], left[1]].IsPath && !maze.Map[left[0], left[1]].Visited)
                    {
                        maze.Map[left[0], left[1]].Visited = true;
                        queue.Enqueue(new int[2] { left[0], left[1] });
                        maze.Map[left[0], left[1]].Count = currentCount + 1;
                    }
                }

                var up = new int[2] { cell[0], cell[1] - 1 };
                if (cell[1] > 0)
                {
                    if (maze.Map[up[0], up[1]].IsPath && !maze.Map[up[0], up[1]].Visited)
                    {
                        maze.Map[up[0], up[1]].Visited = true;
                        queue.Enqueue(new int[2] { up[0], up[1] });
                        maze.Map[up[0], up[1]].Count = currentCount + 1;
                    }
                }

                if (maze.Map[goalX, goalY].Visited == true)
                {
                    finished = true;
                    ans = currentCount + 1;
                }


            }

            return ans;

        }

    }

    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visited { get; set; }
        public bool IsPath { get; set; }
        public int Count { get; set; }

        public Cell(int x, int y, bool isPath)
        {
            this.X = x;
            this.Y = y;
            this.Visited = false;
            this.IsPath = isPath;
        }
    }

    class Maze
    {
        public int XSize { get; set; }
        public int YSize { get; set; }
        public Cell[,] Map { get; set; }

        public Maze(int xSize, int ySize)
        {
            this.XSize = xSize;
            this.YSize = ySize;
            this.Map = new Cell[xSize, ySize];
        }

        public void LoadMapData(int x, int y, bool isPath)
        {
            this.Map[x, y] = new Cell(x, y, isPath);
        }

    }
}
