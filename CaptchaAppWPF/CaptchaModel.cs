using System;
using System.Collections.Generic;
using System.Text;
using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models.Abstract;

namespace CaptchaAppWPF
{
    public class CaptchaModel : YoloModel
    {
        public override int Width { get; set; } = 416;
        public override int Height { get; set; } = 416;
        public override int Depth { get; set; } = 3;

        public override int Dimensions { get; set; } = 46;

        public override int[] Strides { get; set; } = new int[] { 8, 16, 32, 64 };

        public override int[][][] Anchors { get; set; } = new int[][][]
        {
            new int[][] { new int[] { 019, 027 }, new int[] { 044, 040 }, new int[] { 038, 094 } },
            new int[][] { new int[] { 096, 068 }, new int[] { 086, 152 }, new int[] { 180, 137 } },
            new int[][] { new int[] { 140, 301 }, new int[] { 303, 264 }, new int[] { 238, 542 } },
            new int[][] { new int[] { 436, 615 }, new int[] { 739, 380 }, new int[] { 925, 792 } }
        };

        public override int[] Shapes { get; set; } = new int[] { 160, 80, 40, 20 };

        public override float Confidence { get; set; } = 0.20f;
        public override float MulConfidence { get; set; } = 0.25f;
        public override float Overlap { get; set; } = 0.45f;

        public override string[] Outputs { get; set; } = new[] { "output" };

        public override List<YoloLabel> Labels { get; set; } = new List<YoloLabel>()
        {
            new YoloLabel { Id = 1, Name = "3" },
            new YoloLabel { Id = 2, Name = "4" },
            new YoloLabel { Id = 3, Name = "6" },
            new YoloLabel { Id = 4, Name = "7" },
            new YoloLabel { Id = 5, Name = "9" },
            new YoloLabel { Id = 6, Name = "D" },
            new YoloLabel { Id = 7, Name = "E" },
            new YoloLabel { Id = 8, Name = "F" },
            new YoloLabel { Id = 9, Name = "G" },
            new YoloLabel { Id = 10, Name = "H" },
            new YoloLabel { Id = 11, Name = "J" },
            new YoloLabel { Id = 12, Name = "K" },
            new YoloLabel { Id = 13, Name = "L" },
            new YoloLabel { Id = 14, Name = "M" },
            new YoloLabel { Id = 15, Name = "N" },
            new YoloLabel { Id = 16, Name = "P" },
            new YoloLabel { Id = 17, Name = "Q" },
            new YoloLabel { Id = 18, Name = "R" },
            new YoloLabel { Id = 19, Name = "T" },
            new YoloLabel { Id = 20, Name = "U" },
            new YoloLabel { Id = 21, Name = "V" },
            new YoloLabel { Id = 22, Name = "W" },
            new YoloLabel { Id = 23, Name = "X" },
            new YoloLabel { Id = 24, Name = "Y" },
            new YoloLabel { Id = 25, Name = "Z" },
            new YoloLabel { Id = 26, Name = "a" },
            new YoloLabel { Id = 27, Name = "at" },
            new YoloLabel { Id = 28, Name = "b" },
            new YoloLabel { Id = 29, Name = "d" },
            new YoloLabel { Id = 30, Name = "e" },
            new YoloLabel { Id = 31, Name = "eq" },
            new YoloLabel { Id = 32, Name = "f" },
            new YoloLabel { Id = 33, Name = "g" },
            new YoloLabel { Id = 34, Name = "h" },
            new YoloLabel { Id = 35, Name = "k" },
            new YoloLabel { Id = 36, Name = "m" },
            new YoloLabel { Id = 37, Name = "n" },
            new YoloLabel { Id = 38, Name = "q" },
            new YoloLabel { Id = 39, Name = "r" },
            new YoloLabel { Id = 40, Name = "t" },
            new YoloLabel { Id = 41, Name = "u" }
        };

        public override bool UseDetect { get; set; } = true;

        public CaptchaModel()
        {

        }
    }
}
