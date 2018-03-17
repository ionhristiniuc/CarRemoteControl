using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace CarService.Services
{
    public class CarControlService : IDisposable
    {
        private GpioPin pinLeftForward;
        private GpioPin pinLeftReverse;
        private GpioPin pinRightForward;
        private GpioPin pinRightReverse;

        public CarControlService()
        {
            Setup();
            Cleanup();  // ensure car is not moving
        }        

        public void MoveForward(int millisec)
        {
            Move(true, false, true, false, millisec);            
        }

        public void MoveReverse(int millisec)
        {
            Move(false, true, false, true, millisec);              
        }

        public void TurnLeft(int millisec)
        {
            Move(true, false, false, false, millisec);              
        }

        public void TurnRight(int millisec)
        {
            Move(false, false, true, false, millisec);              
        }

        public void StopMoving()
        {
            pinLeftForward.Write(false);
            pinLeftReverse.Write(false);
            pinRightForward.Write(false);
            pinRightReverse.Write(false);
        }

        private void Move(bool lf, bool lr, bool rf, bool rr, int millisec)
        {
            pinLeftForward.Write(lf);
            pinLeftReverse.Write(lr);
            pinRightForward.Write(rf);
            pinRightReverse.Write(rr);

            // Thread.Sleep(millisec);                  
            // Cleanup();   // let the pins be unchanged until 
        }

        private void Setup()
        {
            pinLeftForward = Pi.Gpio.Pin07;
            pinLeftForward.PinMode = GpioPinDriveMode.Output;

            pinLeftReverse = Pi.Gpio.Pin00;
            pinLeftReverse.PinMode = GpioPinDriveMode.Output;

            pinRightForward = Pi.Gpio.Pin02;
            pinRightForward.PinMode = GpioPinDriveMode.Output;

            pinRightReverse = Pi.Gpio.Pin03;
            pinRightReverse.PinMode = GpioPinDriveMode.Output;
        }

        private void Cleanup()
        {
            StopMoving();
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}