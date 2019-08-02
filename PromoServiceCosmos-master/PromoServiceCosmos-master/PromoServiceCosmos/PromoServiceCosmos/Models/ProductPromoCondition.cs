﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Runtime.InteropServices;


namespace PromoServiceCosmos.Models
{
    public class ProductPromoCondition
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // [JsonProperty(PropertyName = "uuid")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int index { get;  set; }
          /*static int generateId()
            {
                 return Interlocked.Increment(ref index);
            }*/
        public ProductPromoParameter parameter { get; set; }

        public ProductPromoOperator promoOperator {  get; set; }

        public float conditionValue { get; set; }

        public float otherValue { get; set; }

        public override string ToString()
        {
            // return JsonConvert.DeserializeObject(this);
            return JsonConvert.SerializeObject(this);
        }

    }
}
