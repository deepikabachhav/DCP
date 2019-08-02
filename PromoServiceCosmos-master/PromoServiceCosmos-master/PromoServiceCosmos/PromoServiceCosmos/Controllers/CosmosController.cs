using Microsoft.AspNetCore.Mvc;
using PromoServiceCosmos.DataAccess;
using PromoServiceCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoServiceCosmos.Controllers
{
    [Route("/v1/promotions")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        ICosmosDataAdapter _adapter;
        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }

       List< ProductPromoCondition >productPromoCondition = new List<ProductPromoCondition>();

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] Promotion proms)
        {
            var result = await _adapter.CreateDocument("PromoDatabase", "PromoCollection", proms);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _adapter.DeleteUserAsync("PromoDatabase", "PromoCollection", id);
            return Ok("deleted");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _adapter.GetData("PromoDatabase", "PromoCollection");
            return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            return Ok(result);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductPromo productpromo)
        {
            var result = await _adapter.updateDocumentAsync("PromoDatabase", "PromoCollection", productpromo);
            return Ok(result);
        }

        /* [HttpPost("{id}/conditions")]
         public async Task<IActionResult> CreateDocumentCondition(string id, [FromBody] List<ProductPromoCondition> productPromoCondition)
         {
             ProductPromo productPromo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
             //ProductPromo productPromo = new ProductPromo();
             productPromo.conditions = productPromoCondition;
             var result = await _adapter.CreateDocumentCondition("PromoDatabase", "PromoCollection", productPromo);
             return Ok(result);
         }*/

        [HttpPost("{id}/conditions")]
        public async Task<IActionResult> CreateDocumentCondition(string id, [FromBody] ProductPromoCondition productPromoCondition)
        {
            ProductPromo productPromo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            productPromo.conditions.Add(productPromoCondition);
            var result = await _adapter.CreateDocumentCondition("PromoDatabase", "PromoCollection", productPromo);
            return Ok(result);
        }


        [HttpPut("{id}/conditions/{index}")]
        public async Task<IActionResult> UpdateConditions(int index, string id, [FromBody] ProductPromoCondition productPromoCondition)
        {
            ProductPromo promo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            var productPromoConditionInstance = promo.conditions.ElementAt(index);

             if (productPromoConditionInstance != null)
             {
           // productPromoConditionInstance.index = productPromoCondition.index;
            productPromoConditionInstance.parameter = productPromoCondition.parameter;
            productPromoConditionInstance.promoOperator = productPromoCondition.promoOperator;
            productPromoConditionInstance.conditionValue = productPromoCondition.conditionValue;
            productPromoConditionInstance.otherValue = productPromoCondition.otherValue;
            }
           else
           {
               return NotFound();
            }
                var result = await _adapter.UpdateDocumentAsyncCon("PromoDatabase", "PromoCollection", promo);
                return Ok(result);
        }

        [HttpGet("{id}/conditions/{index}")]
        public async Task<IActionResult> GetConditionByIndex(string id, int index)
        {
            ProductPromo promo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            var result = promo.conditions.ElementAt(index); 
            return Ok(result);
        }


        [HttpDelete("{id}/conditions/{index}")]
        public async Task<IActionResult> DeleteConditionByIndex(string id, int index)
        {
            ProductPromo promo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            promo.conditions.RemoveAt(index);
            var result = await _adapter.UpdateDocumentAsyncCon("PromoDatabase", "PromoCollection", promo);
            return Ok(result);
        }


        [HttpGet("{id}/conditions")]
        public async Task<IActionResult> GetCondition(string id)
        {
            ProductPromo promo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            var result = promo.conditions;
            return Ok(result);
        }

        [HttpDelete("{id}/conditions")]
        public async Task<IActionResult> DeleteConditions(string id)
        {
            ProductPromo promo = await _adapter.GetDataById("PromoDatabase", "PromoCollection", id);
            promo.conditions.Clear();
            var result = await _adapter.UpdateDocumentAsyncCon("PromoDatabase", "PromoCollection", promo);
            return Ok(result);
        }



    }
}
