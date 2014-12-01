/*                         Camera Mouse Suite
 *  Copyright (C) 2014, Samual Epstein
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using CameraMouseSuite;
using System.ComponentModel;

namespace MAGICGazeTrackingSuite
{
    public class CMSMAGICGazeTrackingSuite : CMSTrackingSuite
    {
        private const string SuiteName         = "CMSMAGICGazeTrackingSuite";
        private const string SuiteInformalName = "MAGIC Gaze (Advanced)";
        private const string SuiteDescription  = "Uses eye gaze to move cursor to currently gazed region and then cascades to traditional Camera Mouse tracker.";

        public CMSClickControlModuleStandard StandardClickControl
        {
            get
            {
                return this.clickControlModule as CMSClickControlModuleStandard;
            }
            set
            {
                this.clickControlModule = value;
            }
        }

        public MAGICGazeMouseControlModule MAGICGazeMouseControlModule
        {
            get
            {
                return this.mouseControlModule as MAGICGazeMouseControlModule;
            }
            set
            {
                this.mouseControlModule = value;
            }
        }

        public CMSMAGICGazeTrackingSuite()
            : base()
        {

            MAGICGazeMouseControlModule = new MAGICGazeMouseControlModule();
            this.trackingModule = new CMSTrackingModuleStandard();
            this.clickControlModule = new CMSClickControlModuleStandard();
            this.name = SuiteName;
            this.informalName = SuiteInformalName;
            this.description = SuiteDescription;
        }

        public override void SendSuiteLogEvent()
        {
            if(CMSLogger.CanCreateLogEvent(false,false,false,"CMSLogMAGICGazeTrackingEvent"))
            {
                CMSLogMAGICGazeTrackingEvent logEvent = new CMSLogMAGICGazeTrackingEvent();
                logEvent.Suite = this;
                CMSLogger.SendLogEvent(logEvent);
            }
        }
    }

}
