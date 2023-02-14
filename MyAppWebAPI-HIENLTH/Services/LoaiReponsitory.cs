using MyAppWebAPI_HIENLTH.Data;
using MyAppWebAPI_HIENLTH.Models;

namespace MyAppWebAPI_HIENLTH.Services
{
    public class LoaiReponsitory : ILoaiReponsitory
    {
        private readonly MyDbContext _context;
        public LoaiReponsitory(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(la => new LoaiVM
            {
                MaLoai = la.MaLoai,
                TenLoai = la.TenLoai

            }); 
            return loais.ToList();

        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            loai.TenLoai = _loai.TenLoai;
            _context.SaveChanges();
        }
    }
}
