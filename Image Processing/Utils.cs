using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    internal class Utils
    {

        private static readonly Point[] Neighbors =
    {
        new Point(0, -1),  // N
        new Point(1, -1),  // NE
        new Point(1, 0),   // E
        new Point(1, 1),   // SE
        new Point(0, 1),   // S
        new Point(-1, 1),  // SW
        new Point(-1, 0),  // W
        new Point(-1, -1)  // NW
    };

        public static List<List<Point>> TraceContours(Bitmap binaryImage)
        {
            int width = binaryImage.Width;
            int height = binaryImage.Height;
            bool[,] visited = new bool[width, height];
            List<List<Point>> contours = new List<List<Point>>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (binaryImage.GetPixel(x, y).R == 255 && !visited[x, y])
                    {
                        List<Point> contour = TraceSingleContour(binaryImage, visited, x, y);
                        if (contour.Count > 0)
                            contours.Add(contour);
                    }
                }
            }
            return contours;
        }
        private static List<Point> TraceSingleContour(Bitmap binaryImage, bool[,] visited, int startX, int startY)
        {
            List<Point> contour = new List<Point>();
            Point current = new Point(startX, startY);
            Point prev = new Point(startX, startY - 1); // Start above the first pixel (N)

            do
            {
                contour.Add(current);
                visited[current.X, current.Y] = true;

                Point next = FindNextContourPoint(binaryImage, current, prev);
                prev = current;
                current = next;

                if (current == Point.Empty)
                    break;

            } while (current != new Point(startX, startY));

            return contour;
        }
        private static Point FindNextContourPoint(Bitmap binaryImage, Point current, Point prev)
        {
            int width = binaryImage.Width;
            int height = binaryImage.Height;

            int prevIndex = Array.IndexOf(Neighbors, new Point(prev.X - current.X, prev.Y - current.Y));
            int startIndex = (prevIndex + 1) % 8;

            for (int i = 0; i < 8; i++)
            {
                int neighborIndex = (startIndex + i) % 8;
                Point offset = Neighbors[neighborIndex];
                Point neighbor = new Point(current.X + offset.X, current.Y + offset.Y);

                if (neighbor.X >= 0 && neighbor.X < width && neighbor.Y >= 0 && neighbor.Y < height &&
                    binaryImage.GetPixel(neighbor.X, neighbor.Y).R == 255)
                {
                    return neighbor;
                }
            }

            return Point.Empty; // No next point found
        }

        public static Bitmap DrawContour(Bitmap bitmap, List<Point> contour)
        {
            Bitmap resultBitmap = new Bitmap(bitmap);

            int contourThickness = 3;

            foreach (var point in contour)
            {
                resultBitmap.SetPixel(point.X, point.Y, Color.Green);

                for (int dx = -contourThickness; dx <= contourThickness; dx++)
                {
                    for (int dy = -contourThickness; dy <= contourThickness; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;

                        int newX = point.X + dx;
                        int newY = point.Y + dy;

                        if (newX >= 0 && newX < bitmap.Width && newY >= 0 && newY < bitmap.Height)
                        {
                            resultBitmap.SetPixel(newX, newY, Color.Green);
                        }
                    }
                }
            }

            return resultBitmap;
        }
    }
}
