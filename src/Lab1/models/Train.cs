using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Test.Models;

using test.models.ValueObjects;
using Test.Models.ValueObjects;

public sealed class Train
    {
        private readonly Weight weight;
        private readonly Speed limitSpeed;
        public readonly Accuracy accuracy;
        public readonly Power maxPower;
        public Speed speed { get; private set; }
        public Power power { get; private set; }
        
  
        public Boost Boost { get; set; }


        public Train(double weightInp, double maxpower, int time, double limit_route)
        {
            weight = new Weight(weightInp);
            maxPower = new Power(maxpower);
            accuracy = new Accuracy(time);
            limitSpeed = new Speed(limit_route);
            power = new Power(0);
            speed = new Speed(0);

            Boost = new Boost(0);

        }

        public bool TryCalculationBoost(double powerInp)
        {   
            if (maxPower.power >= powerInp + this.power.power)
            {
                power = new(power.power + powerInp);
               
                Boost =  new((powerInp + this.power.power) / weight.Kilograms);
                return true;
            }
            return false;
        }

        public bool IsNormalSpeed(double Speed) => Speed <= limitSpeed.speed;


    public void MakeSpeed() {
        speed = new(speed.speed + accuracy.Time * Boost.boost);
     }
        

        public double GetDistance() => speed.speed * accuracy.Time;


        

        

    }
