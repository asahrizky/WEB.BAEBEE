using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WEB.BAEBEE.Web.Helpers;

namespace WEB.BAEBEE.Web.Shared
{
    [Authorize]
    public partial class MainLayout : LayoutComponentBase
    {
        #region Override

        #endregion

        #region Inject
        [Inject]
        public NavigationManager _NavManager { get; set; }
        [Inject]
        public IAuthorizeService _AuthorizeService { get; set; }
        #endregion

        #region Field

        #endregion

        #region Method

        #endregion
    }
}
