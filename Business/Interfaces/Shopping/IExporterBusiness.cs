using Business.Coomon;
using DTOs.Shopping_DTOs;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface IExporterBusiness : IGenericRepository<ExporterInformation>
    {
        void AddExporter(ExporterInformation exporter);
        List<ExporterInformation> GetAllExporters(Descriptor descriptor);
        ExporterInformation GetExporterDetails(int id);
        void UpdateExporter(ExporterInformation exporter);
    }
}
