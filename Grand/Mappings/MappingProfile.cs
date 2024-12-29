using AutoMapper;
using Grand.Views.ViewModels;
using ModelsLayer.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<SignUpViewModel, User>();
    }
}
