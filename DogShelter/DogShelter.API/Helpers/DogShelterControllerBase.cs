using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DogShelter.API.Helpers
{
    public class DogShelterControllerBase<T>(ILogger<T> logger, IMapper mapper, IMediator mediator) : ControllerBase
    {
        protected readonly ILogger<T> logger = logger;
        protected readonly IMapper mapper = mapper;
        protected readonly IMediator mediator = mediator;
    }
}
