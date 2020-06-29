﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using EnvDTE;
using Microsoft.VisualStudio.Shell;
using VSLangProj;

public class RoslynSDKPackageTemplateWizard : RoslynSDKChildTemplateWizard
{
    public override void OnProjectFinishedGenerating(Project project)
    {
        ThreadHelper.ThrowIfNotOnUIThread();

        // There is no good way for the test project to reference the main project, so we will use the wizard.
        if (project.Object is VSProject vsProject)
        {
            _ = vsProject.References.AddProject(RoslynSDKAnalyzerTemplateWizard.Project);
            _ = vsProject.References.AddProject(RoslynSDKCodeFixTemplateWizard.Project);
        }
    }
}
