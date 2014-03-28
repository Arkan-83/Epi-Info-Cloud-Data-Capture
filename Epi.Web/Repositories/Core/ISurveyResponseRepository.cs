﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epi.Web.Common.Message;

namespace Epi.Web.MVC.Repositories.Core
{
    /// <summary>
    /// SurveyResponse Repository interface.
    /// Derives from standard IRepository of SurveyResponseResponse. Adds a method GetSurveyResponse .
    /// </summary>
    public interface ISurveyAnswerRepository: IRepository<Epi.Web.Common.Message.SurveyAnswerResponse>
    {
        SurveyAnswerResponse GetSurveyAnswer(SurveyAnswerRequest pRequest);
        SurveyAnswerResponse SaveSurveyAnswer(SurveyAnswerRequest pRequest);
        UserAuthenticationResponse ValidateUser(UserAuthenticationRequest pRequest);
        UserAuthenticationResponse UpdatePassCode(UserAuthenticationRequest PassCodeDTO);
        UserAuthenticationResponse GetAuthenticationResponse(UserAuthenticationRequest pRequest);
        SurveyAnswerResponse GetFormResponseList(SurveyAnswerRequest pRequest);
        FormSettingResponse GetFormSettings(FormSettingRequest pRequest);

        SurveyAnswerResponse SetChildRecord(SurveyAnswerRequest SurveyAnswerRequest);

        UserAuthenticationResponse GetUserInfo(UserAuthenticationRequest _surveyAuthenticationRequest);

        bool UpdateUser(UserAuthenticationRequest _request);

        FormSettingResponse SaveSettings(FormSettingRequest FormSettingReq);

        SurveyAnswerResponse GetSurveyAnswerHierarchy(SurveyAnswerRequest pRequest);
        SurveyAnswerResponse GetSurveyAnswerAncestor(SurveyAnswerRequest pRequest);

        SurveyAnswerResponse GetResponsesByRelatedFormId(SurveyAnswerRequest FormResponseReq);

        SurveyAnswerResponse DeleteResponseXml(SurveyAnswerRequest FormResponseReq);
    }
}
