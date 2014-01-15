﻿using System;
using System.Web.Mvc;
using Epi.Web.MVC.Facade;
using Epi.Web.MVC.Models;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Epi.Core.EnterInterpreter;
using System.Web.Security;
using System.Reflection;
using System.Diagnostics;
using Epi.Web.Common.Constants;

namespace Epi.Web.MVC.Controllers
{
    public class LoginController : Controller
    {
        //declare SurveyTransactionObject object
        private Epi.Web.MVC.Facade.ISurveyFacade _isurveyFacade;
        /// <summary>
        /// Injectinting SurveyTransactionObject through Constructor
        /// </summary>
        /// <param name="iSurveyInfoRepository"></param>

        public LoginController(Epi.Web.MVC.Facade.ISurveyFacade isurveyFacade)
        {
            _isurveyFacade = isurveyFacade;
        }

        // GET: /Login/
        [HttpGet]
        public ActionResult Index(string responseId, string ReturnUrl)
        {
            //string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //ViewBag.Version = version;

            //   //get the responseId
            //    responseId = GetResponseId(ReturnUrl);
            //    //get the surveyId
            //     string SurveyId = _isurveyFacade.GetSurveyAnswerResponse(responseId).SurveyResponseList[0].SurveyId;
            //     //put surveyId in viewbag so can be retrieved in Login/Index.cshtml
            //     ViewBag.SurveyId = SurveyId;
            if (responseId.ToUpper() == "RESETPASSWORD") //TBD
            {
                return View("ResetPassword");
            }
            return View("Index");
        }
        [HttpPost]

        public ActionResult Index(UserLoginModel Model, string Action, string ReturnUrl)
        {
            switch (Action.ToUpper())
            {
                case "FORGOTPASSWORD":
                    //Code to update the password.
                    _isurveyFacade.UpdateUser(new Common.DTO.UserDTO() { UserName = Model.UserName, Operation = Constant.OperationMode.UpdatePassword });
                    return RedirectToAction(Epi.Web.MVC.Constants.Constant.INDEX, "Login");
                //break;
                case "CANCEL":
                    return RedirectToAction(Epi.Web.MVC.Constants.Constant.INDEX, "Login");
                default:
                    break;
            }


            //parse and get the responseId
            //responseId = GetResponseId(ReturnUrl);

            //Common.DTO.SurveyAnswerDTO  R = _isurveyFacade.GetSurveyAnswerResponse(responseId).SurveyResponseList[0];

            //// Get Last Page visited else send to page 1 - Begin

            //XDocument Xdoc = XDocument.Parse(R.XML);
            //int PageNumber = 0;
            //if (Xdoc.Root.Attribute("LastPageVisited") != null)
            //{
            //    if (!int.TryParse(Xdoc.Root.Attribute("LastPageVisited").Value, out PageNumber))
            //    {
            //        PageNumber = 1;
            //    }
            //}
            //else
            //{
            //    PageNumber = 1;
            //}

            if (ReturnUrl == null || !ReturnUrl.Contains("/"))
            {
                ReturnUrl = "/Home/Index";
            }


            //// Get Last Page visited else send to page 1 - End



            ////get the surveyId
            //string SurveyId = R.SurveyId;
            ////put surveyId in viewbag so can be retrieved in Login/Index.cshtml
            //ViewBag.SurveyId = SurveyId;


            Epi.Web.Common.Message.UserAuthenticationResponse result = _isurveyFacade.ValidateUser(Model.UserName, Model.Password);

            if (result.UserIsValid)
            {
                FormsAuthentication.SetAuthCookie(Model.UserName, false);

                //return RedirectToRoute(new { Controller = "Home", Action = "Index"});
                string UserId = Epi.Web.Common.Security.Cryptography.Encrypt(result.User.UserId.ToString());
                Session["UserId"] = UserId;
                return RedirectToAction(Epi.Web.MVC.Constants.Constant.INDEX, "Home", new { surveyid = "" });
                //return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("", "The email or password you entered is incorrect.");
                return View();
            }
        }


        /// <summary>
        /// parse and return the responseId from response Url 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private string GetResponseId(string returnUrl)
        {
            string responseId = string.Empty;
            string[] expressions = returnUrl.Split('/');

            foreach (var expression in expressions)
            {
                if (Epi.Web.MVC.Utility.SurveyHelper.IsGuid(expression))
                {

                    responseId = expression;
                    break;
                }

            }
            return responseId;
        }


        [HttpGet]
        public ActionResult ForgotPassword(UserLoginModel Model)
        {
            return View("ForgotPassword");
        }

        [HttpGet]
        public ActionResult ResetPassword(UserLoginModel Model)
        {
            return View("ResetPassword");
        }

    }
}
