using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using WEB.BAEBEE.Data;
using WEB.BAEBEE.Shared.Attributes;
using WEB.BAEBEE.Core.Helper;
using WEB.BAEBEE.Shared.Interface;
using Microsoft.Extensions.Options;
using WEB.BAEBEE.Core.Request;
using WEB.BAEBEE.Data.Model;

namespace WEB.BAEBEE.Core.User.Command
{
    public class RegisterUserRequest : UserInfoRequest,IRequest<StatusResponse>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    internal class RegisterUserHandler : IRequestHandler<RegisterUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IGeneralHelper _helper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public RegisterUserHandler(
            ILogger<RegisterUserHandler> logger,
            IGeneralHelper helper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _helper = helper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {

                if (_context.Entity<Data.Model.User>().Any(d => d.Username.ToLower() == request.Username.ToLower()))
                {
                    result.NotAcceptable("Username Sudah Terdaftar!");
                    return result;
                }
                if (!_helper.ValidatePassword(request.Password))
                {
                    result.NotAcceptable($"Password Must 8 Character Length and Contains Upper Case, Symbol and Numeric!");
                    return result;
                }

                string _hash_default_password = _helper.PasswordEncrypt(request.Password);
                Data.Model.User user = new Data.Model.User()
                {
                    Fullname = request.Fullname,
                    Id = Guid.NewGuid(),
                    Username = request.Username,
                    Mail = request.Mail,
                    PhoneNumber = request.PhoneNumber,
                    Password = _hash_default_password,
                    IsLockout = false,
                    AccessFailedCount = 0,
                    Active = true,
                    CreateBy = request.Username,
                    CreateDate = DateTime.Now,
                    UpdateBy = request.Username,
                    UpdateDate = DateTime.Now,
                };
                _context.Add(user);

                Data.Model.UserRole user_role = new Data.Model.UserRole()
                {
                    CreateBy = request.Username,
                    CreateDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    IdRole = RoleType.MBR.ToString(),
                    IdUser = user.Id
                };
                _context.Add(user_role);

                var save = await _context.Commit();
                if (save.Success)
                    result.OK();
                else
                    result.BadRequest(save.Message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Register User", request);
                result.Error("Failed Register User", ex.Message);
            }
            return result;
        }
    }
}

