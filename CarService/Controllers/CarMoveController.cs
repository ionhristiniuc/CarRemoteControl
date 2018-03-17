using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarService.Services;
using Microsoft.AspNetCore.Mvc;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    public class CarMoveController : Controller
    {        
        private readonly CarControlService _carControlService;
        public CarMoveController(CarControlService carControlService)
        {
            this._carControlService = carControlService;
        }        

        [HttpGet("forward/{millisec}")]
        public string MoveForward(int millisec)
        {
            _carControlService.MoveForward(millisec);                                                  

            return "success";
        }

        [HttpGet("reverse/{millisec}")]
        public string MoveReverse(int millisec)
        {
            _carControlService.MoveReverse(millisec);                                                  

            return "success";
        }

        [HttpGet("left/{millisec}")]
        public string TurnLeft(int millisec)
        {
            _carControlService.TurnLeft(millisec);                                                  

            return "success";
        }

        [HttpGet("right/{millisec}")]
        public string TurnRight(int millisec)
        {
            _carControlService.TurnRight(millisec);                                                  

            return "success";
        }

        [HttpGet("stop")]
        public string StopMoving()
        {
            _carControlService.StopMoving();                                                  

            return "success";
        }

        [HttpGet("PinsInfo")]        
        public string GetPinsInfo()
        {             
            var info = new StringBuilder();
            foreach (var pin in Pi.Gpio.Pins)
            {                
                info.AppendFormat("Name: {0}; PinNumber: {1}; BcmPinNumber: {2}; HeaderPinNumber: {3}", 
                    pin.Name, pin.PinNumber, pin.BcmPinNumber, pin.HeaderPinNumber);                
            }   

            return info.ToString();
        }
    }
}
