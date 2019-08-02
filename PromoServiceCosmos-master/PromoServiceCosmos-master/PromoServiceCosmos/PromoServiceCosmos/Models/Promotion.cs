using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoServiceCosmos.Models
{
    public class Promotion : ResponseCode
    {
        public List<ProductPromo> promotion;
    }
}
