using Microsoft.AspNetCore.Components;

namespace WEB.BAEBEE.Web.Shared.Components
{
    public partial class Loader : ComponentBase
    {
        #region Inject, Cascading, Parameter
        [Parameter]
        public bool IsLoading { get; set; }
        #endregion
    }
}
