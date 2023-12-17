using Business.Coomon;
using DTOs.Shopping_DTOs;
using Entities.Models.Common;
using Entities.Models.Shopping_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface ILookupDataBusiness : IGenericRepository<LookupData>
    {
        void AddLookupData(LookupData order);
        List<LookupData> GetAllLookupDatas(Descriptor descriptor);
        LookupData GetLookupDataDetails(int id);
        void UpdateLookupData(LookupData productData);
    }
}
