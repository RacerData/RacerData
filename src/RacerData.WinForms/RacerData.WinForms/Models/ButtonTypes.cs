using System;

namespace RacerData.WinForms.Models
{
    [Flags()]
    public enum ButtonTypes
    {
        Ok = (1 << 0),
        Cancel = (1 << 1),
        Apply = (1 << 2),
        Yes = (1 << 3),
        No = (1 << 4),
        Save = (1 << 5),
        Open = (1 << 6),
        Edit_Save = (1 << 7),
        Delete = (1 << 8),
        Copy = (1 << 9),
        Close = (1 << 10),
        New = (1 << 11),
        Close_Cancel = (1 << 12),
        SaveAndClose = (1 << 13),
        Blank = (1 << 14), // Cuttoff point for single button
        YesNo = Yes | No,
        YesNoCancel = Yes | No | Cancel,
        OkCancel = Ok | Cancel,
        OpenCancel = Open | Cancel,
        SaveCancel = Save | Cancel,
        EditForm = New | Edit_Save | Copy | Delete | Save | Close_Cancel
    }
}
