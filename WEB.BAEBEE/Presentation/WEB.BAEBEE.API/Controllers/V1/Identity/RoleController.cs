//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using WEB.BAEBEE.Shared.Attributes;
using WEB.BAEBEE.Core.Role.Query;
using WEB.BAEBEE.Core.Request;
using WEB.BAEBEE.Core.Role.Command;

namespace WEB.BAEBEE.API.Controllers
{
    public partial class RoleController : BaseController<RoleController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Wrapper(await _mediator.Send(new GetRoleByIdRequest() { Id = id }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetRoleListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] RoleRequest request)
        {
            var add_request = _mapper.Map<AddRoleRequest>(request);
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] RoleRequest request)
        {
            var edit_request = _mapper.Map<EditRoleRequest>(request);
            edit_request.Id = id;
            edit_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(edit_request));
        }
                
        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(string id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActiveRoleRequest() { Id = id, Active = value, Inputer = Inputer }));
        }
        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Wrapper(await _mediator.Send(new DeleteRoleRequest() { Id = id, Inputer = Inputer }));
        }

    }
}

