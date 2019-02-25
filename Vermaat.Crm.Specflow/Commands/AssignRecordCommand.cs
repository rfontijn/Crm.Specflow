﻿using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace Vermaat.Crm.Specflow.Commands
{
    class AssignRecordCommand : ApiOnlyCommand
    {
        private readonly string _aliasToAssign;
        private readonly string _aliasToAssignTo;

        public AssignRecordCommand(CrmTestingContext crmContext, string aliasToAssign, string aliasToAssignTo) : base(crmContext)
        {
            _aliasToAssign = aliasToAssign;
            _aliasToAssignTo = aliasToAssignTo;
        }

        public override void Execute()
        {
            EntityReference assignTo = _crmContext.RecordCache.Get(_aliasToAssignTo, true);
            EntityReference recordToAssign = _crmContext.RecordCache.Get(_aliasToAssign, true);

            AssignRequest req = new AssignRequest()
            {
                Assignee = assignTo,
                Target = recordToAssign
            };
            _crmContext.Service.Execute<AssignResponse>(req);
        }
    }
}