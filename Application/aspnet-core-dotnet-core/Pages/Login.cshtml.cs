using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class LoginModel : PageModel
    {

        public LoginService _LoginService;

        public LoginModel (LoginService loginService)
        {
            _LoginService = loginService;
        }

        [BindProperty]
        public string Name { get; set; } 

        public void OnGet()
        {
          
        }

        public async void OnPostSubmit(Login login)
        {
            
            Name =  _LoginService.SignIn(login.Email, login.Password).Result;
           
                  
        }
         
        public async void OnPostRegister(Login login)
        {
            Name = _LoginService.SignUpAsync(login.Email, login.Password).Result;
        
        }

       
    }
}