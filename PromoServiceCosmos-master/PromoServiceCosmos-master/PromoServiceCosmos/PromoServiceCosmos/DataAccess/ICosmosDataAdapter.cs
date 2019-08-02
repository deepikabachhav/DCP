using System.Collections.Generic;
using System.Threading.Tasks;

using PromoServiceCosmos.Models;

namespace PromoServiceCosmos.DataAccess
{
    public interface ICosmosDataAdapter
    {
        Task<bool> CreateDocument(string dbName, string name, Promotion proms);
        Task<ProductPromo> DeleteUserAsync(string dbName, string name, string id);

        Task<dynamic> GetData(string dbName, string name);
        //Task<dynamic> GetData(string dbName, string name, ProductPromo productpromo);
        Task<bool> updateDocumentAsync(string dbName, string name, ProductPromo productpromo);
        Task<dynamic> GetDataById(string dbName, string name, string id);
        //Task<dynamic> GetConditions(string dbName, string name, string id);
        Task<bool> CreateDocumentCondition(string dbName, string name, ProductPromo productPromoCondition);
        Task<bool> UpdateDocumentAsyncCon(string dbName, string name,ProductPromo productPromoCondition);
        Task<ProductPromoCondition> DeleteUserAsyncon(string dbName, string name, string id);
        
    }
}
