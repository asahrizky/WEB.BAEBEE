using System.ComponentModel.DataAnnotations;
using WEB.BAEBEE.Shared.Attributes;

namespace WEB.BAEBEE.Core.Request
{
    public class UserInfoRequest
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
