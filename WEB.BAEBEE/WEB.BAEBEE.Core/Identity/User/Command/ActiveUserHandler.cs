using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEB.BAEBEE.Data;
using WEB.BAEBEE.Shared.Attributes;

namespace WEB.BAEBEE.Core.User.Command
{

    #region Request
    public class ActiveUserRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    #endregion

    internal class ActiveUserHandler : IRequestHandler<ActiveUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ActiveUserHandler(
            ILogger<ActiveUserHandler> logger,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ActiveUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    item.Active = request.Active;
                    item.UpdateBy = request.Inputer;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id User {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Active User", request);
                result.Error("Failed Active User", ex.Message);
            }
            return result;
        }
    }
}

