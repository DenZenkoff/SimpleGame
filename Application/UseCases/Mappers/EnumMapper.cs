using Application.Enums;
using AutoMapper;

namespace Application.UseCases.Mappers;

public class EnumMapper : Profile
{
    public EnumMapper()
    {
        CreateMap<ActionType, byte>().ConvertUsing(e => (byte)e);
        CreateMap<byte, ActionType>().ConvertUsing(b => (ActionType)b);
        
        CreateMap<Race, byte>().ConvertUsing(e => (byte)e);
        CreateMap<byte, Race>().ConvertUsing(b => (Race)b);
        CreateMap<Gender, byte>().ConvertUsing(e => (byte)e);
        CreateMap<byte, Gender>().ConvertUsing(b => (Gender)b);
        CreateMap<Class, byte>().ConvertUsing(e => (byte)e);
        CreateMap<byte, Class>().ConvertUsing(b => (Class)b);
    }
}