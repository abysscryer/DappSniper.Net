using AutoMapper;
using DappSniper.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Record, RecordViewModel>();
            CreateMap<RecordCreateModel, Record>();
            CreateMap<RecordUpdateModel, Record>();

            CreateMap<Rank, RankViewModel>()
                .ForMember(des => des.Balance,
                    opt => opt.MapFrom(src => (src.Balance / 100000000).ToString()))
                .ForMember(des => des.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name,
                    opt => opt.MapFrom(src => src.Dapp.Name))
                .ForMember(des => des.LogoPath,
                    opt => opt.MapFrom(src => src.Dapp.LogoPath))
                .ForMember(des => des.Category,
                    opt => opt.MapFrom(src => src.Dapp.Category.Name))
                .ForMember(des => des.Protocol,
                    opt => opt.MapFrom(src => src.Dapp.Protocol.Name));
            
            CreateMap<RankCreateModel, Rank>()
                .ForMember(des => des.Balance,
                    opt => opt.MapFrom(src => src.Balance * 100000000))
                .ForMember(des => des.DappId,
                    opt => opt.MapFrom(src => src.DappId));

            CreateMap<RankUpdateModel, Rank>()
                .ForMember(des => des.Balance,
                    opt => opt.MapFrom(src => src.Balance * 100000000))
                .ForMember(des => des.Record,
                    opt => opt.UseDestinationValue())
                .ForMember(des => des.DappId,
                    opt => opt.UseDestinationValue());

            CreateMap<Dapp, DappViewModel>()
                .ForMember(des => des.Category,
                    opt => opt.MapFrom(src => src.Category.Value))
                .ForMember(des => des.Protocol,
                    opt => opt.MapFrom(src => src.Protocol.Value))
                .ForMember(des => des.Addresses,
                    opt => opt.MapFrom(src => src.Contracts.Select(x => x.Address).ToArray()));

            CreateMap<Dapp, DappUpdateModel>()
                .ForMember(des => des.Category,
                    opt => opt.MapFrom(src => src.Category.Value))
                .ForMember(des => des.Protocol,
                    opt => opt.MapFrom(src => src.Protocol.Value));

            CreateMap<DappUpdateModel, Dapp>()
                .ForMember(des => des.Category,
                    opt => opt.MapFrom(src => Category.FromValue(src.Category)))
                .ForMember(des => des.Protocol,
                    opt => opt.MapFrom(src => Protocol.FromValue(src.Protocol)));

            CreateMap<DappCreateModel, Dapp>()
                .ForMember(des => des.Category,
                    opt => opt.MapFrom(src => Category.FromValue(src.Category)))
                .ForMember(des => des.Protocol,
                    opt => opt.MapFrom(src => Protocol.FromValue(src.Protocol)));

        }
    }
}
