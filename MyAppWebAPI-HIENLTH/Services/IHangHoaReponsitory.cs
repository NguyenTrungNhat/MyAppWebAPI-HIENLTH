namespace MyAppWebAPI_HIENLTH.Services
{
    public interface IHangHoaReponsitory
    {
        List<Models.HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
