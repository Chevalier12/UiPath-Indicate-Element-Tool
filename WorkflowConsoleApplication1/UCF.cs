using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using UiPath.Core;
using UiPath.Core.Activities;

namespace UiPathCodingFramework
{
    public class UCFIndicateOnScreen : Activity
    {
        public InArgument<bool> ContinueOnErrorArgument { get; set; }
        public OutArgument<UiElement> OutputArgument { get; set; }

        public IDictionary<string, object> input = new Dictionary<string, object>();

        public IDictionary<string, object> Run(
            bool ContinueOnError = false
        )
        {
            Implementation = () => new Sequence
            {
                Activities =
                {
                    new IndicateOnScreen()
                    {
                        SelectedUiElement = new OutArgument<UiElement>((activityContext) =>
                            OutputArgument.Get(activityContext)),
                        ContinueOnError = new InArgument<bool>((activityContext) => ContinueOnErrorArgument.Get(activityContext))
                    }
                }
            };

            input.Add(nameof(ContinueOnErrorArgument), ContinueOnError);

            var output = WorkflowInvoker.Invoke(this, input);
            return output;
        }
    }
}