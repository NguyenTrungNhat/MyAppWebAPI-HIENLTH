using MyAppWebAPI_HIENLTH.Models;

namespace MyAppWebAPI_HIENLTH.Services
{
    public interface ILoaiReponsitory
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);
    }
}
