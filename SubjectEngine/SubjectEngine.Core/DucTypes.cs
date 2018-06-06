using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectEngine.Core
{
    public enum DucTypes
    {
        // These values must exactly match tblDataType->DucType
        Text = 1,
        Lookup = 2,
        Pickup = 3,
        Number = 4,
        Currency = 5,
        Date = 6,
        Datetime = 7,
        Email = 8,
        ReferenceList = 9,
        Checkbox = 10,
        TextArea = 11,
        HtmlArea = 12,
        Html = 13,
        CommentList = 14,
        Grid = 15,
        SubTitle = 16,
        Hyperlink = 17,
        Integer = 18,
        Image = 19,
        Attachment = 20,
        Time = 21,
        ReferenceCollection = 22,
    }
}
