using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.ValueObjects;

    public sealed record Weight
    {
        public readonly double Kilograms;

        public Weight(double Kilograms)
        {
            if (Kilograms < 300) throw new ArgumentOutOfRangeException(nameof(Kilograms), "The weight of the train cannot be less than 300 kg.");
            this.Kilograms = Kilograms;
        }

    }

