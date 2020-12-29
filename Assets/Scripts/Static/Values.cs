using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values {
    public static Color[] ColorPalette = new Color[] {
        new Color (0.8f, 0.4f, 0.4f, 0.8f), // RED
        new Color (0, 0.8f, 0, 0.8f), // GREEN
        new Color (0, 0.4f, 0.8f, 0.8f), // BLUE
        new Color (0, 0.8f, 0.8f, 0.8f), // CYAN
        new Color (0.8f, 0, 0.4f, 0.8f), // MAGENTA
        new Color (0.8f, 0.8f, 0, 0.8f), // YELLOW
        new Color (0f, 0f, 0f, 0.8f), // BLACK
        new Color (0.7f, 0.7f, 0.7f, 0.8f), // WHITE
        new Color (0.7f, 0.7f, 0.7f, 0.8f), // CURRENT (WHITE)
    };

    public static class Colors {
        public static int RED = 0;
        public static int GREEN = 1;
        public static int BLUE = 2;
        public static int CYAN = 3;
        public static int MAGENTA = 4;
        public static int YELLOW = 5;
        public static int BLACK = 6;
        public static int WHITE = 7;
        public static int CURRENT = 8;
    }

    public static Color GetCurrentColorAdjusted () {
        Color color = ColorPalette[Colors.CURRENT];
        Color color2 = new Color (color.r, color.g, color.b, 0.6f);

        return color2;
    }
}