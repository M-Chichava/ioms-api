using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Errors;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _autoMapper;

        public GetUserByIdHandler(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IUserAccessor userAccessor, IMapper autoMapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;
            _autoMapper = autoMapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .Where(x => x.Email == _userAccessor.GetCurrentUserEmail())
                .Include(x => x.ApplicationRole)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (user is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "User not found");
            }
            return _autoMapper.Map<AppUser, UserDto>(user);
        }
    }
}