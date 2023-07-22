using AutoMapper;
using task_manager.Domain;

namespace task_manager.DTOs.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UserProjects.Select(x => x.User)));

            CreateMap<Domain.Task, TaskDTO>().ReverseMap();

            CreateMap<UserProject, UserProjectDTO>().ReverseMap();
        }
    }
}
