using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.LinkedList
{
    internal class LargestRectangleInHistogram_84
    {
        //public int LargestRectangleArea(int[] heights)
        //{
        //    int max = heights.Max();
        //    int min = heights.Min();

        //    if (min * heights.Length > max * heights.Length - min * heights.Length)
        //        return min * heights.Length;

        //    int countSquare = 1;
        //    for (int i = heights.Length; i > 0; i--)
        //        countSquare += i;

        //    int[] square = new int[countSquare];
        //    int index = 0;
        //    for (int i = 0; i < heights.Length; i++)
        //    {
        //        for (int j = 1; j < heights.Length - i + 1; j++)
        //        {
        //            var vector = heights.Skip(i).Take(j).ToArray();
        //            if (vector.Contains(min))
        //                continue;

        //            square[index] = vector.Min() * heights.Length;
        //            index++;
        //        }
        //    }

        //    return square.Max();
        //}


        //public int LargestRectangleArea(int[] heights)
        //{
        //    int max = heights.Max();
        //    int min = heights.Min();

        //    if (min * heights.Length > max * heights.Length - min * heights.Length)
        //        return min * heights.Length;

        //    int maxSquare = min * heights.Length;

        //    for (int i = heights.Length - 1; i > 0; i--)
        //    {
        //        int[] temp = new int[heights.Length - i + 1];
        //        int index = 0;
        //        for (int j = 0; j + i <= heights.Length; j++)
        //        {
        //            var vector = heights.Take(new Range(j, i + j)).ToArray();

        //            //Console.WriteLine(string.Join(",", vector));

        //            if (vector.Contains(min))
        //                continue;

        //            temp[index] = vector.Min() * vector.Length;
        //            index++;
        //        }

        //        int tempMax = temp.Max();
        //        if (maxSquare <= tempMax)
        //            maxSquare = tempMax;

        //    }

        //    return maxSquare;
        //}

        //public int LargestRectangleArea(int[] heights)
        //{
        //    int max = heights.Max();
        //    int min = heights.Min();

        //    if (min * heights.Length > max * heights.Length - min * heights.Length)
        //        return min * heights.Length;

        //    int maxSquare = min * heights.Length;
        //    do
        //    {
        //        min = heights.Min();
        //        int countMin = 1;
        //        for (int i = 0; i < heights.Length; i++)
        //        {
        //            if (heights[i] == min)
        //                countMin++;
        //        }

        //        int[][] vectors = new int[countMin][];

        //        int ind = 0;
        //        for (int i = 0; i <= countMin; i++)
        //        {
        //            for (int j = ind; j < heights.Length; j++)
        //            {
        //                if (heights[j] == min || j == heights.Length)
        //                {
        //                    vectors[i] = heights.Take(new Range(ind, j)).ToArray();
        //                    ind = j + 1;
        //                    break;
        //                }
        //            }
        //            if (i + 1 == countMin && ind != heights.Length)
        //            {
        //                vectors[i] = heights.Take(new Range(ind, heights.Length)).ToArray();
        //                break;
        //            }
        //        }

        //        int[] temp = new int[countMin];
        //        for (int i = 0; i < countMin; i++)
        //        {
        //            if ((vectors[i]?.Length ?? 0) > 0)
        //                temp[i] = vectors[i].Min() * vectors[i].Length;
        //        }

        //        int tempMax = temp.Max();
        //        if (maxSquare <= tempMax)
        //        {
        //            maxSquare = tempMax;
        //            heights = vectors[temp.ToList().IndexOf(tempMax)];
        //        }
        //        else
        //            break;

        //    } while (true);

        //    return maxSquare; //109134
        //}


        public int LargestRectangleArea(int[] heights)
        {
            int maxSquare = 0;
            do
            {
                int min = heights.Min();
                int countMin = 1;
                for (int i = 0; i < heights.Length; i++)
                {
                    if (heights[i] == min)
                        countMin++;
                }

                int[][] vectors = new int[countMin][];

                int ind = 0;
                for (int i = 0; i <= countMin; i++)
                {
                    for (int j = ind; j < heights.Length; j++)
                    {
                        if (heights[j] == min || j == heights.Length)
                        {
                            vectors[i] = heights.Take(new Range(ind, j)).ToArray();
                            ind = j + 1;
                            break;
                        }
                    }
                    if (i + 1 == countMin && ind != heights.Length)
                    {
                        vectors[i] = heights.Take(new Range(ind, heights.Length)).ToArray();
                        break;
                    }
                }

                int[] temp = new int[countMin];
                for (int i = 0; i < countMin; i++)
                {
                    if ((vectors[i]?.Length ?? 0) > 0)
                        temp[i] = vectors[i].Min() * vectors[i].Length;
                }

                int tempMax = temp.Max();
                if (maxSquare <= tempMax)
                {
                    maxSquare = tempMax;
                    heights = vectors[temp.ToList().IndexOf(tempMax)];
                }
                else
                    break;

            } while (true);

            return maxSquare; //109134
        }
    }
}
