using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    internal class CoinCounter
    {
        public static double CalculatePerimeter(List<Point> contour)
        {
            double perimeter = 0;
            for (int i = 0; i < contour.Count; i++)
            {
                Point current = contour[i];
                Point next = contour[(i + 1) % contour.Count]; // Loop back to the first point
                double distance = Math.Sqrt(Math.Pow(next.X - current.X, 2) + Math.Pow(next.Y - current.Y, 2));
                perimeter += distance;
            }
            return perimeter;
        }

        public static double CalculateArea(List<Point> contour)
        {
            double area = 0;
            for (int i = 0; i < contour.Count; i++)
            {
                Point current = contour[i];
                Point next = contour[(i + 1) % contour.Count];
                area += current.X * next.Y - current.Y * next.X;
            }
            return Math.Abs(area) / 2.0;
        }

        public static Rectangle GetBoundingBox(List<Point> contour)
        {
            int minX = contour.Min(p => p.X);
            int maxX = contour.Max(p => p.X);
            int minY = contour.Min(p => p.Y);
            int maxY = contour.Max(p => p.Y);

            return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
        }

        public static bool isInside(List<Point> a, List<Point> b)
        {
            Rectangle bbox1 = GetBoundingBox(a);
            Rectangle bbox2 = GetBoundingBox(b);
            return bbox1.Left >= bbox2.Left && bbox1.Right <= bbox2.Right && bbox1.Top >= bbox2.Top && bbox1.Bottom <= bbox2.Bottom;
        }

        public static List<List<Point>> FilterContours(List<List<Point>> contours)
        {
            List<List<Point>> filteredContours = new List<List<Point>>();

            for (int i = 0; i < contours.Count; i++)
            {
                bool isNested = false;
                double area1 = CalculateArea(contours[i]);

                for (int j = 0; j < contours.Count; j++)
                {
                    if (i == j) continue;

                    double area2 = CalculateArea(contours[j]);

                    if (isInside(contours[i], contours[j]) && area2 < area1 * 4)
                    {
                        isNested = true;
                        break;
                    }
                }

                if (!isNested)
                {
                    filteredContours.Add(contours[i]);
                }
            }

            return filteredContours;
        }

        public static Tuple<List<List<Point>>, List<int>, List<double>> CountCoins(List<List<Point>> contours, double circularityThreshold = 0.75, int areaThreshold = 50)
        {
            List<List<Point>> coins = new List<List<Point>>();

            foreach (var contour in contours)
            {

                double perimeter = CoinCounter.CalculatePerimeter(contour);
                double area = CoinCounter.CalculateArea(contour);

                if (perimeter == 0) continue;

                double circularity = (4 * Math.PI * area) / (perimeter * perimeter);

                // Check if the contour qualifies as a coin
                if (circularity >= circularityThreshold && area > areaThreshold)
                {
                    coins.Add(contour);
                }
            }

            coins = FilterContours(coins);

            List<List<Point>> final = new List<List<Point>>();
            List<int> value = new List<int>();
            List<double> sizes = new List<double>();

            for (int i = 0; i < coins.Count; i++)
            {
                if (CalculateArea(coins[i]) < 500) continue;

                double size = CalculateArea(coins[i]);
                bool isCent = false;

                for (int j = 0; j < coins.Count; j++)
                {
                    if (i == j) continue;

                    if (isInside(coins[j], coins[i]))
                    {
                        final.Add(coins[i].Union(coins[j]).ToList());
                        value.Add(5);
                        sizes.Add(CalculateArea(coins[i]));
                        isCent = true;
                        break;
                    }
                }

                if (!isCent)
                {
                    final.Add(coins[i]);
                    sizes.Add(size);

                    value.Add(size < 4000 ? 10 : size < 5000 ? 25 : size < 8000 ? 100 : 500);
                }

            }

            return new Tuple<List<List<Point>>, List<int>, List<double>>(final, value, sizes);
        }
    }
}
