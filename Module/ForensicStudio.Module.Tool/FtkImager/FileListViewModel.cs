﻿using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.FtkImager;

public class FileListViewModel : GeneralViewModel
{
    protected FileListViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}