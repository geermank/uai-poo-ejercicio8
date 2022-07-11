using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train.Utils
{
    public class Percentage
    {
        public static float Calculate(float source, int percentage)
        {
            return (source * percentage) / 100;
        }
    }
}
