using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class HelperFunctions
    {
        public static float[] GetXYCoordinate(int numberOfElements, float[] distanceBetweenObjects, float[] current, float yMin = 0)
        {
            float factor = (float)Math.Round(Math.Pow((float)numberOfElements, 1f / 2f));

            float x = current[0], y = current[1];

            y += distanceBetweenObjects[1] + 0.1f;

            if ((y - yMin) / distanceBetweenObjects[1] >= factor)
            {
                y = yMin;
                x += distanceBetweenObjects[0] + 0.1f;
            }

            return new float[] { x, y, 0 };
        }

        public static float[] GetXYZCoordinate(int numberOfElements, float distanceBetweenObjects, float[] current)
        {
            float factor = (float)Math.Round(Math.Pow((float)numberOfElements, 1f / 3f));
            float x = current[0], y = current[1], z = current[2];

            y += distanceBetweenObjects + 0.1f;

            if (y / distanceBetweenObjects >= factor)
            {
                y = 0;
                x += distanceBetweenObjects + 0.1f;

                if (x / distanceBetweenObjects >= factor)
                {
                    x = 0;
                    z += distanceBetweenObjects + 0.1f;
                }
            }

            return new float[] { x, y, z };
        }

        public static string FilterByString(string columnName, string operation, string columnValue)
        {
            return columnName + " " + operation + " \'" + columnValue + "\'";
        }
    }
}
