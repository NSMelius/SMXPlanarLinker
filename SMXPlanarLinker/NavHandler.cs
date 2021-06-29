using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TDx.SpaceMouse.Navigation3D;

namespace SMXPlanarLinker.Navigation
{
    public class NavHandler : INavigation3D
    {
        private readonly Navigation3D navigation3D;
        private readonly Dispatcher dispatcher;
        private bool enable = false;
        private string profile;
        private INavlibProperty properties;
        public NavHandler()
        {
            this.navigation3D = new Navigation3D(this);
            this.navigation3D.ExecuteCommand += this.OnExecuteCommand;
            this.navigation3D.SettingsChanged += this.SettingsChangedHandler;
            this.navigation3D.TransactionChanged += this.TransactionChangedHandler;
            this.navigation3D.MotionChanged += this.MotionChangedHandler;
            this.properties = this.navigation3D.Properties;

        }

        public event EventHandler<CommandEventArgs> ExecuteCommand;
        public event PropertyValueChangedEventHandler PropertyValueChanged;
        public event GetPropertyValueEventHandler GetPropertyValue;
        public event SetPropertyValueEventHandler SetPropertyValue;
        public bool Enable
        {
            get { return this.enable; }
            set
            {
                if (value != this.enable)
                {
                    if (value)
                    {
                        this.navigation3D.Open3DMouse(this.profile);
                    }
                    else
                    {
                        this.navigation3D.Close();
                    }
                    this.navigation3D.FrameTiming = Navigation3D.TimingSource.SpaceMouse;
                    this.navigation3D.EnableRaisingEvents = value;
                    this.enable = value;
                }
            }
        }

        public string Profile
        {
            get { return this.profile; }
            set
            {
                if (this.profile != value)
                {
                    this.profile = value;
                }//if profile does not already match value
                if (this.enable)
                {
                    this.navigation3D.Close();
                    this.navigation3D.Open3DMouse(this.profile);
                }//if enabled
            }//set property
        }//Profile property
        public void MotionChangedHandler(object sender, MotionEventArgs eventArgs)
        {
            if (eventArgs.IsNavigating) {
                this.navigation3D.Motion = true;
            }
            else
            {
                this.navigation3D.Motion = false;
            }


        }
        public void TransactionChangedHandler(object sender, TransactionEventArgs eventArgs)
        {
            if (eventArgs.IsBegin)
            {

            }
            if (eventArgs.IsEnd)
            {

            }

        }
        public void OnExecuteCommand(object sender, CommandEventArgs eventArgs) {

        }
        public void SettingsChangedHandler(object sender, System.EventArgs eventArgs)
        {

        }

        //unimplemented interface method calls
        #region
        public Matrix GetCoordinateSystem()
        {
            throw new NotImplementedException();
        }

        public Matrix GetFrontView()
        {
            throw new NotImplementedException();
        }

        public Matrix GetCameraMatrix()
        {
            throw new NotImplementedException();
        }

        public void SetCameraMatrix(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public Box GetViewExtents()
        {
            throw new NotImplementedException();
        }

        public void SetViewExtents(Box extents)
        {
            throw new NotImplementedException();
        }

        public double GetViewFOV()
        {
            throw new NotImplementedException();
        }

        public void SetViewFOV(double fov)
        {
            throw new NotImplementedException();
        }

        public Frustum GetViewFrustum()
        {
            throw new NotImplementedException();
        }

        public void SetViewFrustum(Frustum frustum)
        {
            throw new NotImplementedException();
        }

        public bool IsViewPerspective()
        {
            throw new NotImplementedException();
        }

        public Point GetCameraTarget()
        {
            throw new NotImplementedException();
        }

        public void SetCameraTarget(Point target)
        {
            throw new NotImplementedException();
        }

        public Plane GetViewConstructionPlane()
        {
            throw new NotImplementedException();
        }

        public bool IsViewRotatable()
        {
            throw new NotImplementedException();
        }

        public void SetPointerPosition(Point position)
        {
            throw new NotImplementedException();
        }

        public Point GetPointerPosition()
        {
            throw new NotImplementedException();
        }

        public Box GetModelExtents()
        {
            throw new NotImplementedException();
        }

        public Box GetSelectionExtents()
        {
            throw new NotImplementedException();
        }

        public bool IsSelectionEmpty()
        {
            throw new NotImplementedException();
        }

        public void SetSelectionTransform(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public Matrix GetSelectionTransform()
        {
            throw new NotImplementedException();
        }

        public Point GetPivotPosition()
        {
            throw new NotImplementedException();
        }

        public void SetPivotPosition(Point position)
        {
            throw new NotImplementedException();
        }

        public void SetPivotVisible(bool visible)
        {
            throw new NotImplementedException();
        }

        public bool IsUserPivot()
        {
            throw new NotImplementedException();
        }

        public Point GetLookAt()
        {
            throw new NotImplementedException();
        }

        public void SetLookFrom(Point eye)
        {
            throw new NotImplementedException();
        }

        public void SetLookDirection(Vector direction)
        {
            throw new NotImplementedException();
        }

        public void SetLookAperture(double aperture)
        {
            throw new NotImplementedException();
        }

        public void SetSelectionOnly(bool onlySelection)
        {
            throw new NotImplementedException();
        }
    
    #endregion 

        public void OnPropertyValueChanged()
    {
            PropertyValueChanged?.Invoke(this, new NavLibEventArgs)
    }
}//class
}//namespace
