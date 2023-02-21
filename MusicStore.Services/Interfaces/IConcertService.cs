﻿using MusciStore.Dto.Request;
using MusciStore.Dto.Response;

namespace MusicStore.Services.Interfaces{
    public interface IConcertService {
        Task<BaseResponseGeneric<ICollection<ConcertDtoResponse>>> ListAsync(string? filter, int page, int rows);

        Task<BaseResponseGeneric<ConcertSingleDtoResponse>> FindByIdAsync(int id);

        Task<BaseResponseGeneric<int>> AddAsync(ConcertDtoRequest request);

        Task<BaseResponse> UpdateAsync(int id, ConcertDtoRequest request);

        Task<BaseResponse> DeleteAsync(int id);

        Task<BaseResponse> FinalizeAsync(int id);
    }
}
