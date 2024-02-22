using WEB.BAEBEE.Core.Helper;
using WEB.BAEBEE.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WEB.BAEBEE.Core.Request
{
    public partial class RepositoryRequest
    {
        [Required]
        public ModulType Modul { get; set; }
        [Required]
        public FileObject File { get; set; }
        [Required]
		public string Code{ get; set; }
		public string Description{ get; set; }
		[Required]
		public bool IsPublic{ get; set; }

    }
}

