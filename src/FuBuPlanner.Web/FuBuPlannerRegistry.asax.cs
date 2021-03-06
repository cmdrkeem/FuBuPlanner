﻿using FubuMVC.Core;
using FuBuPlanner.Web.Behaviours;

namespace FuBuPlanner.Web
{
    public class FuBuPlannerRegistry : FubuRegistry
    {
        public FuBuPlannerRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            Actions.IncludeTypesNamed(x => x.EndsWith("Controller"));

            Routes.IgnoreControllerNamespaceEntirely();

            Views.TryToAttach(x =>
                                  {
                                      x.by_ViewModel_and_Namespace_and_MethodName();
                                      x.by_ViewModel_and_Namespace();
                                      x.by_ViewModel();
                                  });

            Policies.ConditionallyWrapBehaviorChainsWith<MustBeAuthenticatedBehaviour>(
                c => !c.HandlerType.Namespace.EndsWith("Accounts")
                );
        }
    }
}