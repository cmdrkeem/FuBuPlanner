using System;
using System.Collections.Generic;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;
using FubuMVC.Core.View;
using FuBuPlanner.Data;
using FuBuPlanner.Domain;
using System.Linq;
using FuBuPlanner.Web.Controllers.Home;

namespace FuBuPlanner.Web.Controllers.Accounts
{
    public class LogOnController
    {
        private readonly IRepository _repository;
        private readonly IAuthenticationContext _authContext;

        public LogOnController(IRepository repository)
        {
            _repository = repository;
        }

        public LogOnModel LogOn(LogOnModel model)
        {
            return model;
        }

        public FubuContinuation PostLogOn(LogOnModel model)
        {
            if(!Identifier.IsValid(model.LogOnIdentifier))
            {
                model.Errors.Add("LogOnIdentifier","Invalid identifier");
                return FubuContinuation.TransferTo<LogOnController>(c => LogOn(model));
            }
            else
            {
                var openId = new OpenIdRelyingParty();
                var request = openId.CreateRequest(Identifier.Parse(model.LogOnIdentifier),Realm.AutoDetect,new Uri("LogOn/OpenIdReturn",UriKind.Relative));
                request.RedirectingResponse.                
            }
        }
        /*
        public FubuContinuation LogOn(LogOnModel model)
        {
            var openId = new OpenIdRelyingParty();
            openId.CreateRequest()
            var response = openId.GetResponse();

            if(response != null)
            {
                model.LogOnIdentifier = response.ClaimedIdentifier;
    
                switch(response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        Person person = _repository.All<Person>().SingleOrDefault(p => p.OpenIdIdentifier == response.FriendlyIdentifierForDisplay);

                        if(person == null)
                        {
                            person = new Person(response.FriendlyIdentifierForDisplay);
                            _repository.Save(person);
                            _repository.Commit();
                        }

                        _authContext.ThisUserHasBeenAuthenticated(person.OpenIdIdentifier,false);
                        return FubuContinuation.RedirectTo(model.ReturnUrl);
                        

                    case AuthenticationStatus.Canceled:
                        model.Errors.Add("logonIdentifier","Login cancelled by provider");
                        return FubuContinuation.TransferTo(model);
                        

                    case AuthenticationStatus.Failed:
                        model.Errors.Add("logonIdentifier","Login failed for identifier");
                        return FubuContinuation.TransferTo(model);
                        break;
                }
            }
            
            return FubuContinuation.TransferTo(model);
        }
        */
    }

    public class LogOnModel
    {
        public LogOnModel()
        {
            Errors = new Dictionary<string, string>();
        }

        public string LogOnIdentifier { get; set; }

        public IDictionary<string, string> Errors { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class LogOnView : FubuPage<LogOnModel> {}
}


