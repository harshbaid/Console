﻿using System.Linq;
using System.Management.Automation;
using Cognifide.PowerShell.Core.Utility;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Cognifide.PowerShell.Commandlets.Data
{
    [Cmdlet(VerbsCommon.Remove, "BaseTemplate", SupportsShouldProcess = true)]
    public class RemoveBaseTemplateCommand : BaseTemplateItemCommand
    {
        protected override void ProcessTemplateItem(TemplateItem templateItem)
        {
            var innerItem = templateItem.InnerItem;

            if (ShouldProcess(innerItem.GetProviderPath(), $"Remove base template(s) '{TemplateItem.Select(t => t.InnerItem).GetProviderPaths()}'"))
            {
                MultilistField baseTemplateField = innerItem.Fields[Sitecore.FieldIDs.BaseTemplate];

                innerItem.Editing.BeginEdit();

                foreach (var template in TemplateItem)
                {
                    // Check if base template already exists, if it does than there's nothing to do.
                    if (baseTemplateField.Contains(template.ID.ToString()))
                    {
                        baseTemplateField.Remove(template.ID.ToString());
                    }
                }

                innerItem.Editing.EndEdit();
            }
        }
    }
}