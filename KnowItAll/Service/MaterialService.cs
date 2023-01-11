using KnowItAll.Data;
using KnowItAll.Interface;
using KnowItAll.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KnowItAll.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly DataContext _context;

        public MaterialService(DataContext context)
        {
            _context = context;
        }


        public async Task<Material> CreateMaterial(MaterialDto Material)
        {
            Material materials = new Material();

            materials.Name = Material.Name;
            materials.Price = Material.Price;

            await _context.AddAsync(materials);
            await _context.SaveChangesAsync();
            return materials;
        }

        public async Task<bool> DeleteMaterial(int Id)
        {
            Material material = await _context.Materials.Where(x => x.MaterialId == Id).FirstOrDefaultAsync();
            _context.Materials.Remove(material);
            return true;
        }

        public async Task<List<Material>> GetMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> GetById(int Id)
        {
            return await _context.Materials.Where(x => x.MaterialId == Id).FirstOrDefaultAsync();
        }

        public async Task<Material> UpdateMaterial(int Id, MaterialDto Material)
        {
            Material material = await _context.Materials.Where(x => x.MaterialId == Id).FirstOrDefaultAsync();

            material.Name = Material.Name;
            material.Price = Material.Price;

            _context.Update(material);
            await _context.SaveChangesAsync();

            return material;
        }
    }
}
