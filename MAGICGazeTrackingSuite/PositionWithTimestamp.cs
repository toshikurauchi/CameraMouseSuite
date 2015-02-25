using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MAGICGazeTrackingSuite
{
    public class PositionWithTimestamp
    {
        public PointF Pos { get; set; }
        public long TStamp { get; set; }

        public PositionWithTimestamp(PointF pos, long tStamp)
        {
            Pos = pos;
            TStamp = tStamp;
        }
    }
}
