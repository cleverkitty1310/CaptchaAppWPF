using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Yolov5Net.Scorer;

namespace CaptchaAppWPF
{
    public class PredictionComparer : IComparer<YoloPrediction>
    {
        public int Compare(YoloPrediction x, YoloPrediction y)
        {

            if (x == null || y == null)
            {
                return 0;
            }

            if (x.Rectangle.X > y.Rectangle.X)
            {
                return 1;
            }

            return -1;

        }
    }
}
