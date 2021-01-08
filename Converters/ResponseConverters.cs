using RealEstateData.Models;
using System;
using System.Linq;

namespace RealEstateData.Converters
{
    public class ResponseConverters
    {
        public ResponseConverters()
        {
        }

        public double GetRent(RentalModel rentalModel)
        {
            try
            {
                return rentalModel.price_raw;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0.0;
            }
        }

        public float GetBeds(RentalModel rentalModel)
        {
            try
            {
                var dashIndex = rentalModel.beds.IndexOf('-');
                if (dashIndex >= 0)
                {
                    var stringBeds = rentalModel.beds.Substring(0, dashIndex);

                    return (stringBeds == "S") ? 0.5f : Convert.ToInt32(stringBeds);
                }
                else
                {
                    var stringBeds = rentalModel.beds;
                    return Convert.ToInt32(stringBeds);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }

        public float GetBaths(RentalModel rentalModel)
        {
            try
            {
                var dashIndex = rentalModel.beds.IndexOf('-');
                if (dashIndex >= 0)
                {
                    var stringBaths = rentalModel.baths.Substring(0, dashIndex);
                    return Convert.ToInt32(stringBaths);
                }
                else
                {
                    var stringBaths = rentalModel.baths;
                    return Convert.ToInt32(stringBaths);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0.0f;
            }
        }

        public int GetSqft(RentalModel rentalModel)
        {
            var stringSqft = rentalModel.sqft;
            if (stringSqft.Any(c => char.IsDigit(c)))
            {
                var trimmedSqft = String.Concat(stringSqft.Where(c => !char.IsWhiteSpace(c)));
                var plusIndex = trimmedSqft.IndexOf('+');
                if (plusIndex >= 0)
                {
                    var stringSqftResult = rentalModel.sqft.Substring(0, plusIndex);
                    return Convert.ToInt32(stringSqftResult);
                }
                else
                {
                    var lastDigitIndex = trimmedSqft.IndexOf('s');
                    var stringSqftResult = rentalModel.sqft.Substring(0, lastDigitIndex);
                    return Convert.ToInt32(stringSqftResult.Replace(",", ""));
                }
            }
            else
            {
                return 0;
            }
        }
    }
}