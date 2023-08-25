﻿using AutoMapper;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.Dtos.Response;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Providers.Profiles;

public class CardProfile: Profile
{
    public CardProfile()
    {
        CreateMap<CreateCardDto,  Card>();
        CreateMap<Card, ReadCardDto>();
    }
}
