using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ZebraWeb.Models
{
    public class ErrorViewModel
    {
      
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}