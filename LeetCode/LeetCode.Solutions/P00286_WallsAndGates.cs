namespace LeetCode.Solutions.P00286_WallsAndGates;

public class Solution
{
    public void WallsAndGates(int[][] rooms)
    {
        int matrixHeight = rooms.Length;
        int matrixWidth = rooms[0].Length;
        Queue<int[]> Gates = new Queue<int[]>();
        Queue<int[]> Rooms = new Queue<int[]>();
        for (int y = 0; y < matrixHeight; y++)
        {
            for (int x = 0; x < matrixWidth; x++)
            {
                if (rooms[y][x] == 0)
                {
                    Gates.Enqueue(new int[] { y, x });
                }
            }
        }

        while (Gates.Count > 0)
        {
            int[] gate = Gates.Dequeue();
            int y = gate[0];
            int x = gate[1];
            // above
            if (y > 0 && rooms[y - 1][x] > 0)
            {
                rooms[y - 1][x] = 1;
                Rooms.Enqueue(new int[] { y - 1, x });
            }
            // below
            if (rooms.Length > 1 && y < matrixHeight - 1 && rooms[y + 1][x] > 0)
            {
                rooms[y + 1][x] = 1;
                Rooms.Enqueue(new int[] { y + 1, x });
            }
            // l 
            if (x > 0 && rooms[y][x - 1] > 0)
            {
                rooms[y][x - 1] = 1;
                Rooms.Enqueue(new int[] { y, x - 1 });
            }
            // r
            if (rooms[y].Length > 1 && x < matrixWidth - 1 && rooms[y][x + 1] > 0)
            {
                rooms[y][x + 1] = 1;
                Rooms.Enqueue(new int[] { y, x + 1 });
            }

            while (Rooms.Count > 0)
            {
                int[] room = Rooms.Dequeue();
                int ry = room[0];
                int rx = room[1];

                int value = rooms[ry][rx] + 1;

                // above
                if (ry > 0 && rooms[ry - 1][rx] > value)
                {
                    rooms[ry - 1][rx] = value;
                    Rooms.Enqueue(new int[] { ry - 1, rx });
                }
                // below
                if (rooms.Length > 1 && ry < matrixHeight - 1 && rooms[ry + 1][rx] > value)
                {
                    rooms[ry + 1][rx] = value;
                    Rooms.Enqueue(new int[] { ry + 1, rx });
                }
                // l 
                if (rx > 0 && rooms[ry][rx - 1] > value)
                {
                    rooms[ry][rx - 1] = value;
                    Rooms.Enqueue(new int[] { ry, rx - 1 });
                }
                // r
                if (rooms[ry].Length > 1 && rx < matrixWidth - 1 && rooms[ry][rx + 1] > value)
                {
                    rooms[ry][rx + 1] = value;
                    Rooms.Enqueue(new int[] { ry, rx + 1 });
                }
            }
        }
    }
}