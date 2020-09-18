using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.RequestTypesModels;

namespace TestApi.Services.RequestTypesRepo
{
    public class RequestTypeService : IRequestTypeService<RequestType>
    {

        private readonly IRequestTypeRepository _requestRepository;

        public RequestTypeService(IRequestTypeRepository userRepository)
        {
            _requestRepository = userRepository;
        }

        public async Task Add(RequestType model)
        {
            try
            {
                await _requestRepository.Collection.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                FilterDefinition<RequestType> filter = Builders<RequestType>.Filter.Eq(m => m._id, id);

                DeleteResult deleteResult = await _requestRepository
                                                    .Collection
                                                    .DeleteOneAsync(filter);

                return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<RequestType>> GetAll()
        {
            try
            {
                return await _requestRepository.Collection.Find(x => x.IsActive == true).ToListAsync();

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(RequestType model)
        {
            try
            {
                ReplaceOneResult updateResult =
             await _requestRepository
                             .Collection
                             .ReplaceOneAsync(
                                     filter: g => g._id == model._id,
                                     replacement: model);

                return updateResult.IsAcknowledged
                                && updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<RequestType> GetByID(string id)
        {
            try
            {
                return await _requestRepository.Collection.Find(x => x._id == id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<RequestType> GetByReqyestType(string type)
        {
            try
            {
                return await _requestRepository.Collection.Find(x => x.type == type).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
