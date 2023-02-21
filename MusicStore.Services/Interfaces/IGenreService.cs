using MusciStore.Dto.Request;
using MusciStore.Dto.Response;

namespace MusicStore.Services.Interfaces{
    public interface IGenreService{
        Task<BaseResponseGeneric<IEnumerable<GenreDtoResponse>>> ListAsync(); //IEnumerable se usa solo para leer datos de la lista.. para modificar se usa List

        Task<BaseResponseGeneric<GenreDtoResponse>> FindByIdAsync(int id);

        Task<BaseResponseGeneric<int>> AddAsync(GenreDtoRequest request);

        Task<BaseResponse> UpdateAsync(int id, GenreDtoRequest request);

        Task<BaseResponse> DeleteAsync(int id);
    }
}
