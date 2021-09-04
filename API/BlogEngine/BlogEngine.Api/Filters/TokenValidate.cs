using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BlogEngine.Entities.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BlogEngine.Api.Filters
{
    /// <summary>
    /// Filter to Get the User Authenticated from B2C token.  
    /// </summary> 
    public class TokenValidate : IActionFilter
    {
        /// <summary>
        /// Method not implemented  
        /// </summary> 
        public void OnActionExecuted(ActionExecutedContext context)
        {            
        }

        /// <summary>
        /// Method to get User Authenticated object 
        /// </summary> 
        public void OnActionExecuting(ActionExecutingContext context)
        {         
            ClaimsPrincipal principal = context.HttpContext.User;
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated();       
      
            IEnumerator<Claim> tokenClaims = principal.Claims.GetEnumerator();            
          
            Dictionary<string, string> UserData = new Dictionary<string, string>();

            while (tokenClaims.MoveNext())
            {
                string claim = Convert.ToString(tokenClaims.Current);
                string Key = claim.Substring(0, claim.IndexOf(": ") + 1);
                claim = claim.Substring(claim.IndexOf(": ") + 1);
                UserData.Add(Key, claim);
            }         
           
            usersAuthenticated.email = UserData["emails:"];
            usersAuthenticated.Name = UserData["name:"];

            context.HttpContext.Items["usersAuthenticated"] = usersAuthenticated;
        }

       
    }
}
