using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGICGazeTrackingSuite
{
    public interface ICalibrationStatusListener
    {
        void CalibrationStatusChanged(CalibrationStatus newStatus);
    }

    public sealed class CalibrationStatus
    {
        private readonly String name;
        private readonly int value;

        public static readonly CalibrationStatus NotCalibrated = new CalibrationStatus(-1, "Not Calibrated");
        public static readonly CalibrationStatus Poor = new CalibrationStatus(0, "Poor");
        public static readonly CalibrationStatus Fair = new CalibrationStatus(1, "Fair");
        public static readonly CalibrationStatus Average = new CalibrationStatus(2, "Average");
        public static readonly CalibrationStatus Good = new CalibrationStatus(3, "Good");
        public static readonly CalibrationStatus Excellent = new CalibrationStatus(4, "Excellent");
        public static readonly int N_Status = 5;

        private static readonly CalibrationStatus[] statusByValue = { NotCalibrated, Poor, Fair, Average, Good, Excellent };

        private CalibrationStatus(int value, String name){
            this.name = name;
            this.value = value;
        }

        public override String ToString(){
            return name;
        }

        public static implicit operator string(CalibrationStatus s) 
        { 
            return s.ToString(); 
        }

        public static implicit operator CalibrationStatus(int value)
        {
            int idx = value + 1;
            if (idx >= 0 && idx < statusByValue.Length)
            {
                return statusByValue[idx];
            }
            throw new InvalidCastException();
        }
    }
}
