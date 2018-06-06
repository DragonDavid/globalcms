using Framework.Component;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Global.Data;
using Global.DataConverter;
using SubjectEngine.Data;
using System.Collections.Generic;
using SubjectEngine.Core;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class ReferenceFacadeFixture : FixtureBase
    {
        public const int IngredientGridId = 7;
        public const int InstructionGridId = 8;

        [TestMethod]
        public void TestAll()
        {
            ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
            List<ReferenceDto> result = facade.RetrieveAllReference<ReferenceDto>(new ReferenceConverter());
            if (result != null)
            {
            }
        }

        [TestMethod]
        public void SaveReferenceInWhole()
        {
            ReferenceData reference = GetReference();

            // Save Reference
            ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
            IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceInWhole(reference);
            if (result.IsSuccessful)
            {
            }
        }

        [TestMethod]
        public void SaveReferenceKeywords()
        {
            int referenceId = 4;
            ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
            IList<ReferenceKeywordData> referenceKeywords = new List<ReferenceKeywordData>();

            ReferenceKeywordData item1 = new ReferenceKeywordData();
            referenceKeywords.Add(item1);
            item1.KeywordId = 1;
            item1.Sort = 1;
            ReferenceKeywordData item2 = new ReferenceKeywordData();
            referenceKeywords.Add(item2);
            item2.KeywordId = 2;
            item2.Sort = 2;

            IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceKeywords(referenceId, referenceKeywords);
            if (result.IsSuccessful)
            {
            }
        }

        [TestMethod]
        public void GetReferenceInfoWithLanguage()
        {
            ReferenceInfoFacade facade = new ReferenceInfoFacade(UnitOfWork);
            ReferenceInfoDto item = facade.GetReferenceInfo<ReferenceInfoDto>(4, new ReferenceInfoConverter(2));
            if (item != null)
            {
            }
        }

        [TestMethod]
        public void SaveReferenceLanguageBasic()
        {
            ReferenceInfoFacade facade1 = new ReferenceInfoFacade(UnitOfWork);
            ReferenceInfoDto item = facade1.GetReferenceInfo<ReferenceInfoDto>(4, new ReferenceInfoConverter());

            ReferenceData data = new ReferenceData();
            data.Id = 5;
            data.Title = item.Title;
            data.Description = "chinese of UofT";
            data.Keywords = "university, UofT";

            ReferenceFacade facade = new ReferenceFacade(UnitOfWork);
            IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceLanguageBasic(data, 2);
            if (result.IsSuccessful)
            {
            }
        }

        private ReferenceData GetReference()
        {
            ReferenceData reference = new ReferenceData();

            reference.Name = "RecipeInstance.Name";
            reference.Slug = "RecipeNameSlug";
            reference.Title = "RecipeInstance.Name";
            reference.TemplateId = 9;
            reference.FolderId = 12;
            reference.IsPublished = true;
            reference.CreatedById = 100;

            reference.Values = GetSubitemValues();
            reference.GridRows = GetGridRows();

            return reference;
        }

        private IList<SubitemValueData> GetSubitemValues()
        {
            // Subitem values
            IList<SubitemValueData> values = new List<SubitemValueData>();
            // name
            SubitemValueData name = new SubitemValueData();
            values.Add(name);
            name.SubitemId = BlockRegister.RecipeBlock.Name;
            name.ValueText = "RecipeInstance.Name";
            // prepare time
            SubitemValueData prepareTime = new SubitemValueData();
            values.Add(prepareTime);
            prepareTime.SubitemId = BlockRegister.RecipeBlock.PrepareTime;
            prepareTime.ValueInt = 15;
            // cook time
            SubitemValueData cookTime = new SubitemValueData();
            values.Add(cookTime);
            cookTime.SubitemId = BlockRegister.RecipeBlock.CookTime;
            cookTime.ValueInt = 15;
            // servings
            SubitemValueData servings = new SubitemValueData();
            values.Add(servings);
            servings.SubitemId = BlockRegister.RecipeBlock.Servings;
            servings.ValueInt = 2;
            // description
            SubitemValueData description = new SubitemValueData();
            values.Add(description);
            description.SubitemId = BlockRegister.RecipeBlock.Abstract;
            description.ValueHtml = "RecipeInstance.Abstract";
            // image
            SubitemValueData image = new SubitemValueData();
            values.Add(image);
            image.SubitemId = BlockRegister.RecipeBlock.Image;
            image.ValueUrl = "/test/test.jpg";

            return values;
        }

        private IList<GridRowData> GetGridRows()
        {
            IList<GridRowData> rows = new List<GridRowData>();

            // IngredientGrid
            {
                GridRowData row = new GridRowData();
                rows.Add(row);
                row.GridId = IngredientGridId;
                row.Sort = 1;

                GridCellData cell1 = new GridCellData();
                row.Cells.Add(cell1);
                cell1.GridColumnId = BlockRegister.RecipeIngredientGrid.Col_Sortorder;
                cell1.ValueText = "1";

                GridCellData cell2 = new GridCellData();
                row.Cells.Add(cell2);
                cell2.GridColumnId = BlockRegister.RecipeIngredientGrid.Col_IngredientName;
                cell2.ValueText = "ingredient.Label";

                GridCellData cell3 = new GridCellData();
                row.Cells.Add(cell3);
                cell3.GridColumnId = BlockRegister.RecipeIngredientGrid.Col_Quantity;
                cell3.ValueText = "2";

                GridCellData cell4 = new GridCellData();
                row.Cells.Add(cell4);
                cell4.GridColumnId = BlockRegister.RecipeIngredientGrid.Col_UnitOfMeasure;
                cell4.ValueText = "ingredient.UnitOfMeasureName";
            }

            // InstructionGrid
            {
                GridRowData row = new GridRowData();
                rows.Add(row);
                row.GridId = InstructionGridId;
                row.Sort = 1;

                GridCellData cell1 = new GridCellData();
                row.Cells.Add(cell1);
                cell1.GridColumnId = BlockRegister.RecipeInstructionGrid.Col_Sortorder;
                cell1.ValueText = "1";

                GridCellData cell2 = new GridCellData();
                row.Cells.Add(cell2);
                cell2.GridColumnId = BlockRegister.RecipeInstructionGrid.Col_Description;
                cell2.ValueText = "step.Description";
            }

            return rows;
        }
    }
}
