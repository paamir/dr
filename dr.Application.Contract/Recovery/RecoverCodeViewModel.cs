using System;
using System.Security.AccessControl;

namespace dr.Application
{
    public class RecoverCodeViewModel
    {
        public string Code { get; set; }
        public int UserId { get; set; }
        public DateTime ExpireDate {get; set; }

    }
}