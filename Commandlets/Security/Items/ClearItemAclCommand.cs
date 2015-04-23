﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Automation;
using Cognifide.PowerShell.Core.Extensions;
using Cognifide.PowerShell.Core.Utility;
using Sitecore.Data.Items;
using Sitecore.Exceptions;
using Sitecore.Security.AccessControl;
using Sitecore.Security.Accounts;

namespace Cognifide.PowerShell.Commandlets.Security.Items
{
    [Cmdlet(VerbsCommon.Clear, "ItemAcl", SupportsShouldProcess = true)]
    [OutputType(typeof (Item))]
    public class ClearItemAclCommand : BaseItemCommand
    {
        protected override void ProcessItem(Item item)
        {
            if (!this.CanAdmin(item)) { return; }

            if (ShouldProcess(item.GetProviderPath(),"Clear access rights"))
            {
                item.Security.SetAccessRules(new AccessRuleCollection());
            }
        }
    }
}