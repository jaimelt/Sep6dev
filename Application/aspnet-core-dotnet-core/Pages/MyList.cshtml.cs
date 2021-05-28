using System;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class MyList : PageModel
    {
        public LoginCredentials loginCredentials;

        public MyList(LoginCredentials loginCredentials)
        {
            this.loginCredentials = loginCredentials; 
        }
        public void OnGet([FromRoute] int id )
        {
            Console.WriteLine(id);
        }
    }
}