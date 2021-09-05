// ------------------------------------------------------------------
// <copyright file="Languages.cs" company="Zemoga">
// Autor: Cristhian Gomez (cristhian.gomez@softwareone.com)
// Date: 08/24/2021

// All rights reserved
// </copyright>
// ------------------------------------------------------------------

namespace BlogEngine.Api.Controllers
{
    using System;
    using BlogEngine.Entities.Model;
    using BlogEngine.Business.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Identity.Web.Resource;
    using BlogEngine.Api.Filters;

    /// <summary>
    /// Here goes the base controller for GVDP.  
    /// </summary> 

    public class BaseController : Controller
    {
        /// <summary>
        /// Inicialization a new variable of User Authenticated.  
        /// </summary> 
        private UsersAuthenticated _usersAuthenticated;

        /// <summary>
        /// Gets User Authenticated by B2C token.  
        /// </summary> 
        protected UsersAuthenticated UsersAuthenticated
        {
            get
            {
                if (this._usersAuthenticated == null)
                {
                    this._usersAuthenticated = (UsersAuthenticated)HttpContext.Items["usersAuthenticated"];
                }
                return _usersAuthenticated;
            }

        }
    }
}
