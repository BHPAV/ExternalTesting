namespace Bespoke.Items.Hull
{
    public class VehicleController : HullController
    {
        public EngineController engineController; // The EngineController for this vehicle
        public WheelController wheelController; // The WheelController for this vehicle

        protected override void InitializeHull()
        {
            base.InitializeHull();

            // Initialize the engine and wheels
            engineController.InitializeEngine();
            wheelController.InitializeWheels();
        }

        protected override void UpdateHull()
        {
            base.UpdateHull();

            // Update the engine and wheels
            engineController.UpdateEngine();
            wheelController.UpdateWheels();
        }
    }
}
