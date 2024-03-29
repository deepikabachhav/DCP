﻿using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using PromoServiceCosmos.DataAccess.Utility;
using PromoServiceCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PromoServiceCosmos.DataAccess
{
    public class CosmosDataAdapter : ICosmosDataAdapter
    {
        private readonly DocumentClient _client;
        private readonly string _accountUrl;
        private readonly string _primarykey;

        ResponseCode resposecode;

        public CosmosDataAdapter(
         ICosmosConnection connection,
         IConfiguration config)
        {

            _accountUrl = config.GetValue<string>("Cosmos:AccountURL");
            _primarykey = config.GetValue<string>("Cosmos:AuthKey");
            _client = new DocumentClient(new Uri(_accountUrl), _primarykey);
        }

        public async Task<bool> CreateDocument(string dbName, string name, ProductPromo productpromo)
        {
            try
            {
                
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromo);
               // resposecode.statusReason = HttpStatusCode.OK();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductPromo> DeleteUserAsync(string dbName, string name, string id)
        {
            try
            {
                var collectionUri = UriFactory.CreateDocumentUri(dbName, name, id);

                var result = await _client.DeleteDocumentAsync(collectionUri);

                return (dynamic)result.Resource;
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
         public async Task<dynamic> GetData(string dbName, string name)
        {
            try
            {

                var result = await _client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), 
                    new FeedOptions { MaxItemCount = 10 });

                return result;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<dynamic> GetDataById(string dbName, string name,string id)
        {

            try
            {
                //ResourceResponse<Document> result = await _client.ReadDocumentAsync));
                // new FeedOptions { MaxItemCount = 10 });
                ResourceResponse<Document> response = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(dbName, name, id));
                ProductPromo productpro = (ProductPromo)(dynamic)response.Resource;
                return productpro;
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }


       
        public async Task<bool> updateDocumentAsync(string dbName, string name, ProductPromo productpromo)
        {
            try { 
           
                await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(dbName, name, productpromo.Id), productpromo);

               // await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productpromo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateDocumentCondition(string dbName, string name, ProductPromoCondition productPromoCondition)
        {
            try
            {
                
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productPromoCondition);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> UpdateDocumentAsyncCon(string dbName, string name, ProductPromo productPromoCondition)
        {
            try
            {

              //  await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(dbName, name,productPromoCondition.Id), productPromoCondition);

                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productPromoCondition);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<ProductPromoCondition> DeleteUserAsyncon(string dbName, string name, string id)
        {
            try
            {
                var collectionUri = UriFactory.CreateDocumentUri(dbName, name, id);

                var result = await _client.DeleteDocumentAsync(collectionUri);

                return (dynamic)result.Resource;
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public Task<bool> CreateDocument(string dbName, string name, Promotion proms)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateDocumentCondition(string dbName, string name, ProductPromo productPromoCondition1)
        {
            try
            {
     
                await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(dbName, name), productPromoCondition1);
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
