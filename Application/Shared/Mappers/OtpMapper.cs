using AutoMapper;
using Domain.Entities;
using Application.DTOs.OTP;

namespace Application.Shared.Mappers
{
    public sealed class OtpMapper : Profile
    {
        public OtpMapper()
        {
            CreateMap<OTPResponse, VerifyOTP>();
            CreateMap<VerifyOTP, OTPResponse>();
        }
    }
}
