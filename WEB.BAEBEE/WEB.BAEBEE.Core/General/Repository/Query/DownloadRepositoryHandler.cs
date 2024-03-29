//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using WEB.BAEBEE.Data;
using WEB.BAEBEE.Data.Model;
using WEB.BAEBEE.Shared.Attributes;
using WEB.BAEBEE.Core.Response;
using WEB.BAEBEE.Core.Helper;
using Microsoft.Extensions.Options;

namespace WEB.BAEBEE.Core.Repository.Query
{

    public class DownloadRepositoryRequest : IRequest<ObjectResponse<FileDetailObject>>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    internal class DownloadRepositoryHandler : IRequestHandler<DownloadRepositoryRequest, ObjectResponse<FileDetailObject>>
    {
        private readonly ILogger _logger;
        private readonly ApplicationConfig _config;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DownloadRepositoryHandler(
            ILogger<DownloadRepositoryHandler> logger,
            IOptions<ApplicationConfig> options,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _config = options.Value;
            _mediator = mediator;
            _context = context;
        }
        public async Task<ObjectResponse<FileDetailObject>> Handle(DownloadRepositoryRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<FileDetailObject> result = new ObjectResponse<FileDetailObject>();
            try
            {
                var item = await _context.Entity<WEB.BAEBEE.Data.Model.Repository>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var path = Path.Combine(_config.MediaPath, request.Id.ToString());
                    if (!File.Exists(path))
                    {
                        result.NotFound("File Not Found!");
                        return result;
                    }
                    var file_bytes = await File.ReadAllBytesAsync(path);

                    result.Data = new FileDetailObject()
                    {
                        Base64 = Convert.ToBase64String(file_bytes),
                        Filename = item.FileName,
                        MimeType = item.MimeType
                    };
                    result.OK();
                }
                else
                    result.NotFound($"Id Repository {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Repository", request.Id);
                result.Error("Failed Get Detail Repository", ex.Message);
            }
            return result;
        }
    }
}

