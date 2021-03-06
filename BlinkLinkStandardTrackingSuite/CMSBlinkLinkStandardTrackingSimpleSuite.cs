﻿/*                         Camera Mouse Suite
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

namespace BlinkLinkStandardTrackingSuite
{
    //[CMSIgnoreSuiteAtt()]
    public class CMSBlinkLinkStandardTrackingSimpleSuite : CMSTrackingSuite
    {
        private const string SuiteName         = "CMSBlinkLinkStandardTrackingSimpleSuite";
        private const string SuiteInformalName = "Blink Detection";
        private const string SuiteDescription  = "Uses the traditional Camera Mouse tracker and uses blinks to control clicks.";

        public BlinkLinkClickControlSimpleModule BlinkLinkClickControlModule
        {
            get
            {
                return this.clickControlModule as BlinkLinkClickControlSimpleModule;
            }
            set
            {
                this.clickControlModule = value;
                if( this.mouseControlModule != null )
                {
                    ((BlinkLinkMouseControlModule)this.mouseControlModule).ClickControlModule = BlinkLinkClickControlModule;
                }
            }
        }

        public BlinkLinkMouseControlModule BlinkLinkMouseControlModule
        {
            get
            {
                return this.mouseControlModule as BlinkLinkMouseControlModule;
            }
            set
            {
                this.mouseControlModule = value;
                if( this.mouseControlModule != null )
                {
                    //((BlinkLinkMouseControlModule)this.mouseControlModule).MoveMouse = false;
                    ((BlinkLinkMouseControlModule)this.mouseControlModule).ClickControlModule = BlinkLinkClickControlModule;
                }
            }
        }

        public BlinkLinkAHMTrackingModule BlinkLinkAHMTrackingModule
        {
            get
            {
                return this.trackingModule as BlinkLinkAHMTrackingModule;
            }
            set
            {
                trackingModule = value;
            }
        }

        public CMSBlinkLinkStandardTrackingSimpleSuite()
            : base()
        {

            BlinkLinkAHMTrackingModule = new BlinkLinkAHMTrackingModule();
            BlinkLinkMouseControlModule = new BlinkLinkMouseControlModule();
            BlinkLinkClickControlModule = new BlinkLinkClickControlSimpleModule();
            this.name = SuiteName;
            this.informalName = SuiteInformalName;
            this.description = SuiteDescription;
        }

        public override void SendSuiteLogEvent()
        {
            if (CMSLogger.CanCreateLogEvent(false, false, false, "CMSLogBlinkLinkSimpleTrackingEvent"))
            {
                CMSLogBlinkLinkSimpleTrackingEvent logEvent = new CMSLogBlinkLinkSimpleTrackingEvent();
                logEvent.Suite = this;
                CMSLogger.SendLogEvent(logEvent);
            }
        }
    }
}
