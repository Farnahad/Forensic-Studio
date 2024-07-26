﻿using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.Ntfs;

public class BitmapViewModel : GeneralViewModel
{
    protected BitmapViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}