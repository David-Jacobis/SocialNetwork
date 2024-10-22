using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    public class CommonResource
    {
        protected readonly IStringLocalizer<CommonResource> _localizer;

        public CommonResource(IStringLocalizer<CommonResource> commonResource)
        {
            _localizer = commonResource;
        }
        
        public string Informed { get { return GetString(nameof(Informed)); } }

        public string sucessSearchUser { get { return GetString(nameof(sucessSearchUser)); } }

        public string errorFetchingSearchUser { get { return GetString(nameof(errorFetchingSearchUser)); } }

        public string loginSucesso { get { return GetString(nameof(loginSucesso)); } }

        public string loginError { get { return GetString(nameof(loginError)); } }
        public string SignInSucess { get { return GetString(nameof(SignInSucess)); } }
        public string SignInError { get { return GetString(nameof(SignInError)); } }
        public string DefaultSuccess { get { return GetString(nameof(DefaultSuccess)); } }
        public string DefaultError { get { return GetString(nameof(DefaultError)); } }

        //profile
        public string successFetchingProfile { get { return GetString(nameof(successFetchingProfile)); } }
        public string errorFetchingProfile { get { return GetString(nameof(errorFetchingProfile)); } }
        public string successCreateProfile { get { return GetString(nameof(successCreateProfile)); } }
        public string successUpdateProfile { get { return GetString(nameof(successUpdateProfile)); } }
        public string errorUpdateProfile { get { return GetString(nameof(errorUpdateProfile)); } }
        public string errorUpdateProfileFetch { get { return GetString(nameof(errorUpdateProfileFetch)); } }
        public string successDeleteProfile { get { return GetString(nameof(successDeleteProfile)); } }
        public string errorDeleteProfile { get { return GetString(nameof(errorDeleteProfile)); } }
        public string errorDeleteProfilFetch { get { return GetString(nameof(errorDeleteProfilFetch)); } }



        //task hold message jira
        public string JiraConfigisNull { get { return GetString(nameof(JiraConfigisNull)); } }
        public string ServiceIdIsNull { get { return GetString(nameof(ServiceIdIsNull)); } }

        public string JiraDescriptionError { get { return GetString(nameof(JiraDescriptionError)); } }

        public string UserUpdated { get { return GetString(nameof(UserUpdated)); } }
        public string UserNotUpdated { get { return GetString(nameof(UserNotUpdated)); } }

        public string NickNameNull { get { return GetString(nameof(NickNameNull)); } }
        public string FormNull { get { return GetString(nameof(FormNull)); } }

        public string NoActiveConfiguration { get { return GetString(nameof(NoActiveConfiguration)); } }

        public string SystemDefaultInstrunctionPrompt { get { return GetString(nameof(SystemDefaultInstrunctionPrompt)); } }
        public string MessageTwilioIaPedingResponse { get { return GetString(nameof(MessageTwilioIaPedingResponse)); } }
        public string MessageTwilioErrorResponse{ get { return GetString(nameof(MessageTwilioErrorResponse)); } }
        public string MessageTwilioKnowledgeBaseSearch { get { return GetString(nameof(MessageTwilioKnowledgeBaseSearch)); } }


        protected string GetString(string name) =>
            _localizer.GetString(name);
    }
}
