using System.Collections.Generic;
using Framework.Component;
using Framework.Core;
using Framework.UoW;
using SubjectEngine.Data;

namespace SubjectEngine.Component
{
    public class SubsiteBatchFacade : BusinessComponent
    {
        public SubsiteBatchFacade(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            FolderSystem = new FolderSystem(unitOfWork);
            SubsiteSystem = new SubsiteSystem(unitOfWork);
            ReferenceSystem = new ReferenceSystem(unitOfWork);
            SubitemValueSystem = new SubitemValueSystem(UnitOfWork);
        }

        private FolderSystem FolderSystem { get; set; }
        private SubsiteSystem SubsiteSystem { get; set; }
        private ReferenceSystem ReferenceSystem { get; set; }
        private SubitemValueSystem SubitemValueSystem { get; set; }

        public IFacadeUpdateResult<FolderData> SaveSubsiteBatch(FolderTreeData folderTree, SubsiteData subSite)
        {
            UnitOfWork.BeginTransaction();
            // 1. Save parent folder
            folderTree.Folder.IsSubsiteRoot = true;
            FacadeUpdateResult<FolderData> result = SaveFolderTree(folderTree);
            if (result.IsSuccessful)
            {
                // 2. Save SubsiteData
                subSite.SubsiteFolderId = result.Result.Id;
                IFacadeUpdateResult<SubsiteData> subSiteResult = SubsiteSystem.SaveSubsite(subSite);
                result.ValidationResult.Merge(subSiteResult.ValidationResult);
                if (subSiteResult.IsSuccessful)
                {
                    UnitOfWork.CommitTransaction();
                }
                else
                {
                    UnitOfWork.RollbackTransaction();
                }
            }
            else
            {
                UnitOfWork.RollbackTransaction();
            }

            return result;
        }

        public FacadeUpdateResult<FolderData> SaveFolderTree(FolderTreeData folderTree)
        {
            // 1. Save parent folder
            FacadeUpdateResult<FolderData> parentFolderResult = FolderSystem.SaveFolder(folderTree.Folder);
            if (parentFolderResult.IsSuccessful)
            {
                // 2. Save References
                foreach (ReferenceData reference in folderTree.References)
                {
                    // Assign reference's FolderId
                    reference.FolderId = parentFolderResult.Result.Id;
                    FacadeUpdateResult<ReferenceData> referenceResult = ReferenceSystem.SaveReference(reference);
                    parentFolderResult.ValidationResult.Merge(referenceResult.ValidationResult);
                    if (referenceResult.IsSuccessful)
                    {
                        // Save ReferenceCategory
                        if (reference.ReferenceCategorys.Count > 0)
                        {
                            ReferenceSystem.SaveReferenceCategorys(referenceResult.Result.Id, reference.ReferenceCategorys);
                        }
                        // Save SubitemValues
                        IFacadeUpdateResult<ReferenceData> valueResult = SubitemValueSystem.SaveSubitemValues(referenceResult.Result.Id, reference.Values);
                    }
                }
                // 3. Save SubFolders
                foreach (FolderTreeData subFolder in folderTree.SubFolders)
                {
                    // Assign sub folder's ParentId
                    subFolder.Folder.ParentId = parentFolderResult.Result.Id;
                    FacadeUpdateResult<FolderData> subResult = SaveFolderTree(subFolder);
                    parentFolderResult.ValidationResult.Merge(subResult.ValidationResult);
                }
            }

            return parentFolderResult;
        }
    }
}
