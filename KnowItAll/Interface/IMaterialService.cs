using KnowItAll.Data;
using KnowItAll.Models;

namespace KnowItAll.Interface
{
    public interface IMaterialService
    {
        Task<List<Material>> GetMaterials();
        Task<Material> GetById(int Id);
        Task<Material> CreateMaterial(MaterialDto Material);
        Task<Material> UpdateMaterial(int Id, MaterialDto Material);
        Task<bool> DeleteMaterial(int Id);
    }
}
