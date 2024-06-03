

using Shared.DTO.InnovTouch.DTO.Helper;

namespace DLC_BO.Client.Service
{
    public interface ICRUDService<T>
    {
        public Task<Response<List<T>>> GetAll();
        public Task<Response<T>> GetById(int id);
        public Task<Response<int>> Add(T model);
        public Task<Response<bool>> Edit(T model);
        public Task<Response<bool>> DeleteById(int id);
    }
}
