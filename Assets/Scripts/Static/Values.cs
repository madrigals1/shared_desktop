using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values {
    public static Color[] ColorPalette = new Color[] {
        new Color (0.8f, 0.4f, 0.4f, 0.8f), // RED
        new Color (0, 0.8f, 0, 0.5f), // GREEN
        new Color (0, 0.4f, 0.8f, 0.5f), // BLUE
        new Color (0, 0.8f, 0.8f, 0.5f), // CYAN
        new Color (0.8f, 0, 0.4f, 0.5f), // MAGENTA
        new Color (0.8f, 0.8f, 0, 0.5f), // YELLOW
        new Color (0f, 0f, 0f, 0.5f), // BLACK
        new Color (1f, 1f, 1f, 0.5f), // WHITE
        new Color (1f, 1f, 1f, 0.5f), // CURRENT (WHITE)
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
        Color color2 = new Color (color.r, color.g, color.b, 0.15f);

        return color2;
    }
}