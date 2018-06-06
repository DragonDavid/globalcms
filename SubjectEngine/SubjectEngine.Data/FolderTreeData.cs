using Framework.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace SubjectEngine.Data
{
    public class FolderTreeData : DataObject
    {
        public FolderTreeData()
        {
            Folder = new FolderData();
            SubFolders = new List<FolderTreeData>();
            References = new List<ReferenceData>();
        }

        public FolderData Folder { get; set; }
        public IList<FolderTreeData> SubFolders { get; set; }
        public IList<ReferenceData> References { get; set; }
    }
}
