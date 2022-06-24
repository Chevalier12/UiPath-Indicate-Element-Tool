using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using UiPath.Core;
using UiPath.Core.Activities;

namespace WorkflowConsoleApplication1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("inMSG", "www.youtube.com");

            IDictionary<string, object> output = new Dictionary<string, object>();

            WorkflowApplication myWorkflowApplication= new WorkflowApplication(new MyCodeWorkflow(),input);
            myWorkflowApplication.Run();
            //MyCodeWorkflow activity = new MyCodeWorkflow();
            //output = WorkflowInvoker.Invoke(activity, input);
            //wtf
        }

        public class MyCodeWorkflow : Activity
        {
            public InArgument<String> inMSG { get; set; }
            public OutArgument<String> outMSG { get; set; }

            public MyCodeWorkflow()
            {
                this.Implementation = () => new Sequence
                {
                    Activities =
                    {
                        new OpenBrowser()
                        {
                            BrowserType = BrowserType.Chrome,
                            NewSession = true,
                            Url = inMSG
                            //Text=new InArgument<string>((activityContext)=>this.inMSG.Get(activityContext))
                        },

                        new Assign<String>
                        {
                            To=new ArgumentReference<String>("outMSG"),
                            Value=new InArgument<String>((activityContext)=>this.inMSG.Get(activityContext))
                        }
                    }
                };
            }
        }
    }

}
