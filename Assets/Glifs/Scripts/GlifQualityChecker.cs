using UnityEngine;

public static class GlifQualityChecker
{
    private static float _esp = 3f/512;
    public static float CheckWithoutColor(Texture2D pattern, Texture2D paint)
    {
        int patternPixelCounter = 0;
        int paintMissCounter = 0;
        int paintDificitCounter = 0;
        float maxPaintA = 0f;

        if (pattern.width != paint.width || pattern.height != paint.height)
        {
            throw new System.Exception("Картины имеют разные размеры!");
        }

        for (int x = 0; x < pattern.width; x++)
        {
            for (int y = 0; y < pattern.height; y++)
            {
                Color patternColor = pattern.GetPixel(x, y);
                Color paintColor = paint.GetPixel(x, y);
                maxPaintA = Mathf.Max(maxPaintA, paintColor.a);
                if (patternColor.a > 0) {
                    patternPixelCounter++;
                    if (paintColor.a < _esp)
                        paintDificitCounter++;
                }
                if (paintColor.a > _esp && patternColor.a < _esp) paintMissCounter++;

            }
        }

        float res = 1f - (float)paintMissCounter/patternPixelCounter - (float)paintDificitCounter/patternPixelCounter;
        Debug.Log($"{res} {patternPixelCounter} {paintMissCounter} {paintDificitCounter}");
        return res;
    }
}
