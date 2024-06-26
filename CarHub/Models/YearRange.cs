using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Identity.Client;

namespace Carhub.Models
{
    public class YearRangeAttribute : ValidationAttribute
    {
        private readonly int _minRange;
        private readonly int _maxRange;
        public YearRangeAttribute(int minRange)
        {
            _minRange = minRange;
            _maxRange = DateTime.Now.Year;
        }

        public override bool IsValid(object value)
        {

            if (value == null)
            {
                return true;
            }
            else
            {
                var intValue = (int)value;

                if (intValue < _minRange)
                {
                    return false;
                }

                if (intValue > _maxRange)
                {
                    return false;
                }
            }

            return true;
        }
    }
}