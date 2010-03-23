using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Runtime;
using FubuMVC.StructureMap;
using StructureMap;

namespace FuBuPlanner.Web.Behaviours
{
    public class RepositoryBehaviour : IActionBehavior
    {
        private readonly IContainer _container;
        private readonly ServiceArguments _arguments;
        private readonly Guid _behaviorId;

        public RepositoryBehaviour(IContainer container, ServiceArguments arguments, Guid behaviorId)
        {
            _container = container;
            _arguments = arguments;
            _behaviorId = behaviorId;
        }

        public void Invoke()
        {
            using( var nested = _container.GetNestedContainer() )
            {
                InvokeRequestedBehavior(nested);
            }
        }

        private void InvokeRequestedBehavior(IContainer c)
        {
            var behavior = c.GetInstance<IActionBehavior>(_arguments.ToExplicitArgs(), _behaviorId.ToString());
            behavior.Invoke();
        }

        public void InvokePartial()
        {
            InvokeRequestedBehavior(_container);
        }
    }
}
