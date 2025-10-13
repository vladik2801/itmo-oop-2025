using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models;
using Test.Models.ValueObjects;
public sealed class MagneticPath : IRoute
{
    public Power power { get; private set; }
    private Length totalLength;
    public MagneticPath(double Length, double powerInp)
    {
        this.power = new(powerInp);
        this.totalLength = new Length(Length);
    }
    public void MinusLength(double Length) => totalLength = new(totalLength.length -  Length);
        

    public bool IsZeroMore() => totalLength.length > 0;

    public void Simulate(Train train, Result result)
    {       
        if (train.maxPower.power < this.power.power + train.power.power)
        {
            result.MakeFalse();
            return;
        }

        if (!train.TryCalculationBoost(this.power.power))
        {
            result.MakeFalse();
            return;
        }

        while (this.IsZeroMore())
        {
            result.AddTimeValue(train.accuracy.Time);
            
            try { 
                train.MakeSpeed(); 
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result.MakeFalse();
                break;
            }
            MinusLength(train.GetDistance());
        }
            
            
        }
    }

