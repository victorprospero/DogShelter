using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.API.Helpers
{
    public class DogShelterControllerBase(ILogger logger, IMapper mapper, IMediator mediator) : ControllerBase
    {
        protected readonly ILogger logger = logger;
        protected readonly IMapper mapper = mapper;
        protected readonly IMediator mediator = mediator;
    }
}
