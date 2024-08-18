using AutoMapper;
using QGenieBackend.Handlers.Candidates.DTOs;
using QGenieBackend.Handlers.Interviews.DTOs;
using QGenieBackend.Handlers.Messages.DTOs;
using QGenieBackend.POCOs;
using QGenieBackend.Types;

namespace QGenieBackend.Handlers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, JobTitleQueryPart>().ConvertUsing<QueryPartConverter<JobTitleQueryPart>>();
            CreateMap<string, JobDescriptionQueryPart>().ConvertUsing<QueryPartConverter<JobDescriptionQueryPart>>();
            CreateMap<string, JobSeniorityQueryPart>().ConvertUsing<QueryPartConverter<JobSeniorityQueryPart>>();
            CreateMap<string, InterviewCharacterQueryPart>().ConvertUsing<QueryPartConverter<InterviewCharacterQueryPart>>();
            CreateMap<string, NotesQueryPart>().ConvertUsing<QueryPartConverter<NotesQueryPart>>();
            CreateMap<string, CredentialsQueryPart>().ConvertUsing<QueryPartConverter<CredentialsQueryPart>>();

            CreateMap<Candidate, CandidateDTO>();
            CreateMap<CandidateCreationDTO, Candidate>()
                .ForMember(dest => dest.Credentials, opt => opt.MapFrom(src => src.Credentials));

            CreateMap<Interview, InterviewDTO>();
            CreateMap<InterviewCreationDTO, Interview>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobDescription));

            CreateMap<Message, MessageDTO>();
            CreateMap<MessageCreationDTO, Message>()
                .ForMember(dest => dest.InterviewCharacter, opt => opt.MapFrom(src => src.InterviewCharacter))
                .ForMember(dest => dest.JobSeniority, opt => opt.MapFrom(src => src.JobSeniority))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
        }
    }
}
