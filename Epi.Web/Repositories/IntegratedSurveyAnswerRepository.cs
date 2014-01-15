﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epi.Web.MVC.Repositories.Core;
using Epi.Web.MVC.DataServiceClient;
using Epi.Web.Common.Message;
using Epi.Web.Common.Exception;
using System.ServiceModel;
using Epi.Web.MVC.DataServiceClient;

namespace Epi.Web.MVC.Repositories
{
    public class IntegratedSurveyAnswerRepository : RepositoryBase, ISurveyAnswerRepository
    {



        private Epi.Web.WCF.SurveyService.IEWEDataService _iDataService;

        public IntegratedSurveyAnswerRepository(Epi.Web.WCF.SurveyService.IEWEDataService iDataService)
        {
            _iDataService = iDataService;
        }
        
        /// <summary>
        /// Calling the proxy client to fetch a SurveyResponseResponse object
        /// </summary>
        /// <param name="surveyid"></param>
        /// <returns></returns>
        public SurveyAnswerResponse GetSurveyAnswer(SurveyAnswerRequest pRequest)
        {
            try
            {
                //SurveyResponseResponse result = Client.GetSurveyResponse(pRequest);
                SurveyAnswerResponse result = _iDataService.GetSurveyAnswer(pRequest);
                return result;
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SurveyAnswerResponse GetFormResponseList(SurveyAnswerRequest pRequest)
            {
            try
                {
                //SurveyResponseResponse result = Client.GetSurveyResponse(pRequest);
                SurveyAnswerResponse result = _iDataService.GetFormResponseList(pRequest);
                return result;
                }
            catch (FaultException<CustomFaultException> cfe)
                {
                throw cfe;
                }
            catch (FaultException fe)
                {
                throw fe;
                }
            catch (CommunicationException ce)
                {
                throw ce;
                }
            catch (TimeoutException te)
                {
                throw te;
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }

         
        public FormSettingResponse GetResponseColumnNameList(FormSettingRequest pRequest)
            {
            try
                {

                FormSettingResponse result = _iDataService.GetResponseColumnNames(pRequest);
                return result;
                }
            catch (FaultException<CustomFaultException> cfe)
                {
                throw cfe;
                }
            catch (FaultException fe)
                {
                throw fe;
                }
            catch (CommunicationException ce)
                {
                throw ce;
                }
            catch (TimeoutException te)
                {
                throw te;
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }


        public UserAuthenticationResponse UpdatePassCode(UserAuthenticationRequest AuthenticationRequest)
        {
            try
            {

                UserAuthenticationResponse result  = _iDataService.SetPassCode(AuthenticationRequest);
                return result;
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        public UserAuthenticationResponse ValidateUser(UserAuthenticationRequest pRequest)
        {
            try
            {

                //UserAuthenticationResponse result = _iDataService.PassCodeLogin(pRequest);
                UserAuthenticationResponse result = _iDataService.UserLogin(pRequest);
                return result;
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(UserAuthenticationRequest pRequest)
        {
            try
            {

                //UserAuthenticationResponse result = _iDataService.PassCodeLogin(pRequest);
                return _iDataService.UpdateUser(pRequest);
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserAuthenticationResponse GetAuthenticationResponse(UserAuthenticationRequest pRequest)
        {
            try
            {

                UserAuthenticationResponse result = _iDataService.GetAuthenticationResponse(pRequest);
                return result;
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SurveyAnswerResponse SaveSurveyAnswer(SurveyAnswerRequest pRequest)
        {
            try
            {
                SurveyAnswerResponse result = _iDataService.SetSurveyAnswer(pRequest);
                return result;
            }
            catch (FaultException<CustomFaultException> cfe)
            {
                throw cfe;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            catch (CommunicationException ce)
            {
                throw ce;
            }
            catch (TimeoutException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserAuthenticationResponse GetUserInfo(UserAuthenticationRequest pRequest)
            {

            try
                {

                UserAuthenticationResponse result = _iDataService.GetUser(pRequest);
                return result;
                }
            catch (FaultException<CustomFaultException> cfe)
                {
                throw cfe;
                }
            catch (FaultException fe)
                {
                throw fe;
                }
            catch (CommunicationException ce)
                {
                throw ce;
                }
            catch (TimeoutException te)
                {
                throw te;
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }

        #region stubcode
            public List<Common.DTO.SurveyAnswerDTO> GetList(Criterion criterion = null)
            {
                throw new NotImplementedException();
            }

            public Common.DTO.SurveyAnswerDTO Get(int id)
            {
                throw new NotImplementedException();
            }

            public int GetCount(Criterion criterion = null)
            {
                throw new NotImplementedException();
            }

            public void Insert(Common.DTO.SurveyAnswerDTO t)
            {
                throw new NotImplementedException();
            }

            public void Update(Common.DTO.SurveyAnswerDTO t)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            } 
        #endregion


            List<SurveyAnswerResponse> IRepository<SurveyAnswerResponse>.GetList(Criterion criterion = null)
            {
                throw new NotImplementedException();
            }

            SurveyAnswerResponse IRepository<SurveyAnswerResponse>.Get(int id)
            {
                throw new NotImplementedException();
            }

            public void Insert(SurveyAnswerResponse t)
            {
                throw new NotImplementedException();
            }

            public void Update(SurveyAnswerResponse t)
            {
                throw new NotImplementedException();
            }
           public SurveyAnswerResponse SetChildRecord(SurveyAnswerRequest SurveyAnswerRequest) {

           try
               {
               SurveyAnswerResponse result = _iDataService.SetSurveyAnswer(SurveyAnswerRequest);
               return result;
               }
           catch (FaultException<CustomFaultException> cfe)
               {
               throw cfe;
               }
           catch (FaultException fe)
               {
               throw fe;
               }
           catch (CommunicationException ce)
               {
               throw ce;
               }
           catch (TimeoutException te)
               {
               throw te;
               }
           catch (Exception ex)
               {
               throw ex;
               }
                }
    }
}