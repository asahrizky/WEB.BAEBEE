using Microsoft.AspNetCore.Mvc;
using WEB.BAEBEE.Shared.Attributes;
using WEB.BAEBEE.Core.Repository.Query;
using WEB.BAEBEE.Core.Request;
using WEB.BAEBEE.Core.Repository.Command;

namespace WEB.BAEBEE.API.Controllers
{
    public partial class RepositoryController : BaseController<RepositoryController>
    {
        [HttpPost(template: "upload")]
        public async Task<IActionResult> Upload([FromBody] RepositoryRequest request)
        {
            var upload_request = _mapper.Map<UploadRepositoryRequest>(request);
            upload_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(upload_request));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteRepositoryRequest() { Id = id, Inputer = Inputer }));
        }

        [HttpGet(template: "download/{id}")]
        public async Task<IActionResult> Download(Guid id)
        {
            return Wrapper(await _mediator.Send(new DownloadRepositoryRequest() { Id = id, Inputer = Inputer }));
        }
        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetRepositoryListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }
    }
}
