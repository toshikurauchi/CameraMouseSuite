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
using System.Linq;
using System.Text;
using CameraMouseSuite;
using System.Drawing;
using System.Diagnostics;

namespace MAGICGazeTrackingSuite
{
    public class MAGICGazeMouseControlModule : CMSMouseControlModule
    {
        private bool firstFrameInControl = false;
        private int waitTime = 70;
        private long lastTickCount = 0;
        private double imageWidth = 0;
        private double imageHeight = 0;
        private double screenWidth = 0;
        private double screenHeight = 0;

        private PointF imageOriginPoint;
        private PointF screenOriginPoint;
        private PointF prevCursorPos;

        private bool   reverseHorizontal = false;
        private bool   moveMouse = true;
        private bool   useGrid = true;
        private double userHorizontalGain = 6.0;
        private double userVerticalGain = 6.0;
        private double damping = 0.65;
        private double eastLimit = 0.0;
        private double southLimit = 0.0;
        private double westLimit = 0.0;
        private double northLimit = 0.0;
        private bool showPanel = true;

        private MAGICGazeTracker gazeTracker;
        private Point currentCell;
        private static int hCell = 9;
        private static int vCell = 5;

        public MAGICGazeMouseControlModule()
        {
            this.gazeTracker = new MAGICGazeTracker();
            currentCell = new Point(-1, -1);
        }

        public bool ShowPanel
        {
            get
            {
                return showPanel;
            }
            set
            {
                showPanel = value;
            }
        }
        public bool MoveMouse
        {
            get
            {
                return moveMouse;
            }
            set
            {
                moveMouse = value;
            }
        }
        public bool UseGrid
        {
            get
            {
                return useGrid;
            }
            set
            {
                useGrid = value;
            }
        }
        public bool ReverseHorizontal
        {
            get
            {
                return reverseHorizontal;
            }
            set
            {
                reverseHorizontal = value;
            }
        }
        public double UserHorizontalGain
        {
            get
            {
                return userHorizontalGain;
            }
            set
            {
                userHorizontalGain = value;
            }
        }
        public double UserVerticalGain
        {
            get
            {
                return userVerticalGain;
            }
            set
            {
                userVerticalGain = value;
            }
        }
        public double Damping
        {
            get
            {
                return damping;
            }
            set
            {
                damping = value;
            }
        }
        public double EastLimit
        {
            get
            {
                return eastLimit;
            }
            set
            {
                eastLimit = value;
                UpdateForms();
            }
        }
        public double SouthLimit
        {
            get
            {
                return southLimit;
            }
            set
            {
                southLimit = value;
                UpdateForms();
            }
        }
        public double WestLimit
        {
            get
            {
                return westLimit;
            }
            set
            {
                westLimit = value;
                UpdateForms();
            }
        }
        public double NorthLimit
        {
            get
            {
                return northLimit;
            }
            set
            {
                northLimit = value;
                UpdateForms();
            }
        }

        private ExcludeForm eastExcludeForm = null;
        private ExcludeForm westExcludeForm = null;
        private ExcludeForm southExcludeForm = null;
        private ExcludeForm northExcludeForm = null;


        private void UpdateForms()
        {
            double screenWidth = CMSConstants.SCREEN_WIDTH;
            double screenHeight = CMSConstants.SCREEN_HEIGHT;
            if( eastExcludeForm != null )
            {
                int x = (int)((1.0 - eastLimit) * screenWidth);
                eastExcludeForm.SetVertical(x, (int)(northLimit * screenHeight) - 4,
                                           (int)((1.0 - southLimit) * screenHeight) + 4, 6);
            }

            if( westExcludeForm != null )
            {
                int x = (int)(westLimit * screenWidth) - 6;
                westExcludeForm.SetVertical(x, (int)(northLimit * screenHeight) - 4,
                                           (int)((1.0 - southLimit) * screenHeight) + 4, 6);
            }

            if( southExcludeForm != null )
            {
                int y = (int)((1.0 - southLimit) * screenHeight);
                southExcludeForm.SetHorizontal(y, (int)(westLimit * screenWidth) - 4,
                                           (int)((1.0 - eastLimit) * screenWidth) + 4, 6);
            }

            if( northExcludeForm != null )
            {
                int y = (int)(northLimit * screenHeight) - 6;
                northExcludeForm.SetHorizontal(y, (int)(westLimit * screenWidth) - 4,
                                           (int)((1.0 - eastLimit) * screenWidth) + 4, 6);
            }
        }

        private void ShowExcludeForms()
        {
            if( eastLimit > 0.0 )
            {
                if( eastExcludeForm.Created )
                    eastExcludeForm.Visible = true;
                else
                {
                    Size size = eastExcludeForm.Size;
                    Point pt = eastExcludeForm.Location;
                    eastExcludeForm.Show();
                    eastExcludeForm.Size = size;
                    eastExcludeForm.Location = pt;
                }
            }

            if( westLimit > 0.0 )
            {
                if( westExcludeForm.Created )
                    westExcludeForm.Visible = true;
                else
                {
                    Size size = westExcludeForm.Size;
                    Point pt = westExcludeForm.Location;
                    westExcludeForm.Show();
                    westExcludeForm.Size = size;
                    westExcludeForm.Location = pt;

                }
            }

            if( southLimit > 0.0 )
            {
                if( southExcludeForm.Created )
                    southExcludeForm.Visible = true;
                else
                {
                    Size size = southExcludeForm.Size;
                    Point pt = southExcludeForm.Location;
                    southExcludeForm.Show();
                    southExcludeForm.Size = size;
                    southExcludeForm.Location = pt;
                }
            }

            if( northLimit > 0.0 )
            {
                if( northExcludeForm.Created )
                    northExcludeForm.Visible = true;
                else
                {
                    Size size = northExcludeForm.Size;
                    Point pt = northExcludeForm.Location;
                    northExcludeForm.Show();
                    northExcludeForm.Size = size;
                    northExcludeForm.Location = pt;
                }
            }
        }

        private void HideExcludeForms()
        {
            if( eastExcludeForm != null )
                eastExcludeForm.Visible = false;
            if( westExcludeForm != null )
                westExcludeForm.Visible = false;
            if( northExcludeForm != null )
                northExcludeForm.Visible = false;
            if( southExcludeForm != null )
                southExcludeForm.Visible = false;
        }

        private PointF AdjustCursor(PointF cur, PointF prev)
        {
            PointF newCursor = new PointF();
            newCursor.X = (float)((cur.X * damping) + (prev.X * (1.0 - damping)));
            newCursor.Y = (float)((cur.Y * damping) + (prev.Y * (1.0 - damping)));

            return ApplyCursorBoundaries(newCursor);
        }

        private PointF ApplyCursorBoundaries(PointF cur)
        {
            double east = (1.0 - eastLimit) * screenWidth;
            double west = (westLimit) * screenWidth;
            double north = northLimit * screenHeight;
            double south = (1.0 - southLimit) * screenHeight;

            if (cur.X > east)
            {
                imageOriginPoint.X += 1F;
                cur.X = (float)east;
            }
            else if (cur.X < west)
            {
                imageOriginPoint.X += -1F;
                cur.X = (float)west;
            }
            if (cur.Y > south)
            {
                imageOriginPoint.Y += 1F;
                cur.Y = (float)south;
            }
            else if (cur.Y < north)
            {
                imageOriginPoint.Y += -1F;
                cur.Y = (float)north;
            }

            if (cur.X >= screenWidth)
                cur.X -= 8;
            if (cur.Y >= screenHeight)
                cur.Y -= 15;
            return cur;
        }

        public PointF ComputeCursor(PointF imagePoint)
        {
            double difx = imagePoint.X - imageOriginPoint.X;
            double dify = imagePoint.Y - imageOriginPoint.Y;

            difx *= this.userHorizontalGain * screenWidth / imageWidth;
            dify *= this.userVerticalGain * screenHeight / imageHeight;

            if( this.reverseHorizontal )
                difx *= -1.0;

            PointF screenPoint = new PointF();
            screenPoint.X = (float)(this.screenOriginPoint.X + difx);
            screenPoint.Y = (float)(this.screenOriginPoint.Y + dify);
            return screenPoint;
        }

        public override void Init(Size[] imageSizes)
        {
            int imageWidth = imageSizes[0].Width;
            int imageHeight = imageSizes[0].Height;

            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.screenWidth = CMSConstants.SCREEN_WIDTH;
            this.screenHeight = CMSConstants.SCREEN_HEIGHT;

            eastExcludeForm = new ExcludeForm();
            westExcludeForm = new ExcludeForm();
            southExcludeForm = new ExcludeForm();
            northExcludeForm = new ExcludeForm();

            UpdateForms();
        }

        public override void ProcessMouse(System.Drawing.PointF imagePoint, CMSExtraTrackingInfo extraInfo,
                                          System.Drawing.Bitmap[] frames)
        {

            if (!state.Equals(CMSState.ControlTracking))
                return;

            Bitmap frame = frames[0];
            if( firstFrameInControl )
            {
                imageOriginPoint = new PointF(imagePoint.X, imagePoint.Y);
                screenOriginPoint = new PointF((float)screenWidth / 2, (float)screenHeight / 2);
            }

            PointF tempCursor = ComputeCursor(new PointF(imagePoint.X, imagePoint.Y));

            if( firstFrameInControl )
            {
                prevCursorPos.X = tempCursor.X;
                prevCursorPos.Y = tempCursor.Y;
                firstFrameInControl = false;
            }
            PointF newCursor = AdjustCursor(tempCursor, prevCursorPos);

            PointF cursorDirection = new PointF(newCursor.X - prevCursorPos.X, newCursor.Y - prevCursorPos.Y);
            PointF newGazeCursor = newCursor;
            if (PointFHelper.NormSqr(cursorDirection) >= 25) // 5 pixels TODO: this shouldn't be fixed like this
            {
                newGazeCursor = ProcessGaze(newCursor);
                gazeTracker.Active = false;
            }
            else
            {
                gazeTracker.Active = true;
            }
            newGazeCursor = ApplyCursorBoundaries(newGazeCursor);
            if (!newGazeCursor.Equals(newCursor))
            {
                this.screenOriginPoint = newGazeCursor;
                tempCursor = ComputeCursor(new PointF(imagePoint.X, imagePoint.Y));
                newCursor = AdjustCursor(tempCursor, prevCursorPos);
            }
            //newCursor = newGazeCursor;
            prevCursorPos = newCursor;

            long newTickCount = Environment.TickCount;
            if( newTickCount - this.lastTickCount > this.waitTime )
            {
                int nx = (int)newCursor.X;
                int ny = (int)newCursor.Y;
                SetCursorPosition(nx, ny);
                lastTickCount = newTickCount;
            }
        }

        private PointF ProcessGazedCell(PointF gaze, PointF cursor)
        {
            int cellWidth = (int)screenWidth / hCell;
            int cellHeight = (int)screenHeight / vCell;
            int xBorder = cellWidth / 2;
            int yBorder = cellHeight / 2;

            // Min is used for the case in which gaze has maximum coordinates 
            // (normalized gaze x or y equal to 1)
            int gazeXCell = Math.Min((int)gaze.X / cellWidth, hCell - 1);
            int gazeYCell = Math.Min((int)gaze.Y / cellHeight, vCell - 1);
            
            if (currentCell.X >= 0 && currentCell.Y >= 0)
            {
                int lLimit = currentCell.X * cellWidth - xBorder;
                int rLimit = (currentCell.X + 1) * cellWidth + xBorder;
                int bLimit = currentCell.Y * cellHeight - yBorder;
                int tLimit = (currentCell.Y + 1) * cellHeight + yBorder;
                if (gaze.X >= lLimit && gaze.X <= rLimit && gaze.Y >= bLimit && gaze.Y <= tLimit)
                {
                    return cursor;
                }
            }
            currentCell = new Point(gazeXCell, gazeYCell);
            return new PointF((gazeXCell + 0.5f) * cellWidth, (gazeYCell + 0.5f) * cellHeight);
        }

        private PointF ProcessGazedRegion(PointF gaze, PointF cursor)
        {
            float maxDist = (float)screenWidth / 6; // TODO this should be configurable
            float sqrDist = PointFHelper.NormSqr(PointFHelper.Subtract(cursor, gaze));
            if (sqrDist > maxDist * maxDist)
            {
                return gaze;
                //return PointFHelper.ClosestPointToRayInCircle(gaze, maxDist * 0.5f, prevCursorPos, cursor); // TODO distance should be configurable
            }
            else
            {
                return cursor;
            }
        }

        private PointF ProcessGaze(PointF cursor)
        {
            PointF gaze = gazeTracker.GazeOnScreen((float)screenWidth, (float)screenHeight);
            if (gaze.X < 0 || gaze.Y < 0)
            {
                return cursor;
            }
            if (useGrid)
            {
                return ProcessGazedCell(gaze, cursor);
            }
            else
            {
                return ProcessGazedRegion(gaze, cursor);
            }
        }

        public override void Clean()
        {
            gazeTracker.stop();
            firstFrameInControl = true;

            if( eastExcludeForm != null )
                eastExcludeForm.Close();
            if( westExcludeForm != null )
                westExcludeForm.Close();
            if( southExcludeForm != null )
                southExcludeForm.Close();
            if( northExcludeForm != null )
                northExcludeForm.Close();
        }

        public override void ProcessKeys(System.Windows.Forms.Keys keys)
        {

        }

        public override void Update(CMSModule module)
        {
            MAGICGazeMouseControlModule newConfig = module as MAGICGazeMouseControlModule;

            if( newConfig == null )
                throw new System.Exception("Invalid Config");

            this.reverseHorizontal = newConfig.ReverseHorizontal;
            this.userHorizontalGain = newConfig.UserHorizontalGain;
            this.userVerticalGain = newConfig.UserVerticalGain;
            this.Damping = newConfig.Damping;
            this.EastLimit = newConfig.EastLimit;
            this.SouthLimit = newConfig.SouthLimit;
            this.WestLimit = newConfig.WestLimit;
            this.NorthLimit = newConfig.NorthLimit;
        }

        public override CMSConfigPanel getPanel()
        {
            MAGICGazeMouseControlPanel panel = new MAGICGazeMouseControlPanel();
            panel.SetMouseControl(this);
            return panel;
        }

        public override void StateChange(CMSState state)
        {
            if( state.Equals(CMSState.ControlTracking) )
            {
                firstFrameInControl = true;
                ShowExcludeForms();
            }
            else
                HideExcludeForms();
        }

        public override void DrawOnFrame(Bitmap[] frames)
        {
        }
    }
}
