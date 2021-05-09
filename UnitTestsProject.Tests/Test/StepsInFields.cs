namespace Insttantt.UnitTestsProject.Tests
{
    using DataAccess.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Test.Common;
    /// <summary>
    /// StepsInFields
    /// </summary>
    [TestClass]
    public  class StepsInFields : BaseTest<BusinessRules.Interfaces.IStepsInFields>
    {
        private readonly Mock<IMainContext> adaptadorStepsInFields;
        /// <summary>
        /// StepsInFields
        /// </summary>
        public StepsInFields()
        {
            var lst = new List<Entities.StepsInFields>()
            {
                new Entities.StepsInFields 
                {
                    IdStep = 1
					,IdStepsNavigation = new Entities.Steps { Id =1 }
					,IdFieldNavigation = new Entities.Fields { Id = 1 }
                },
                new Entities.StepsInFields
                {
                    IdStep = 2
					,IdStepsNavigation = new Entities.Steps { Id =1 }
					,IdFieldNavigation = new Entities.Fields { Id = 1 }
                }
            };

            DbSet<Entities.StepsInFields> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorStepsInFields = new Mock<IMainContext>();
            adaptadorStepsInFields.Setup(item => item.Set<Entities.StepsInFields>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var lstReturn = BusinessRulesStepsInFields.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(x => x.IdStep ==1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(x => x.IdStep == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(x => x.IdStep ==1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(x => x.IdStep == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Count(x => x.IdStep ==1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.StepsInFields>()
            {
                new Entities.StepsInFields { IdStep = 3 },
                new Entities.StepsInFields { IdStep = 4 }
            };
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Create(lst);

            
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.StepsInFields> lst = null;
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Create(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.StepsInFields { IdStep = 200 };
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.StepsInFields { IdStep =1 };
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        ///  EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.StepsInFields>()
            {
                new Entities.StepsInFields { IdStep = 3 },
                new Entities.StepsInFields { IdStep = 4 }
            };

            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.StepsInFields> lst = null;
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.StepsInFields { IdStep =1 };
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Delete(x => x.IdStep ==1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpressionNotFind
        /// </summary>
        [TestMethod]
        public void DeleteExpressionNotFind()
        {
            try
            {
                BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
                var objReturn = BusinessRulesStepsInFields.Delete(x => x.IdStep == 200);
            }
            catch (Exception ex)
            {
                
                Assert.IsTrue(ex.Message == string.Empty);
            }
        }
        /// <summary>
        /// DeleteNull
        /// </summary>
        [TestMethod]
        public void DeleteNull()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRange(x => x.IdStep ==1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRange(x => x.IdStep == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListAsync
        /// </summary>
        [TestMethod]
        public void CreateListAsync()
        {
            var lst = new List<Entities.StepsInFields>()
            {
                new Entities.StepsInFields { IdStep = 3 },
                new Entities.StepsInFields { IdStep = 4 }
            };
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.StepsInFields> lst = null;
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        ///  CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.StepsInFields { IdStep = 200 };
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.StepsInFields { IdStep =1 };
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditNullAsync
        /// </summary>
        [TestMethod]
        public void EditNullAsync()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.StepsInFields>()
            {
                new Entities.StepsInFields { IdStep = 3 },
                new Entities.StepsInFields { IdStep = 4 }
            };

            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.StepsInFields> lst = null;
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.StepsInFields { IdStep =1 };
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteAsync(x => x.IdStep ==1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionNotFindAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionNotFindAsync()
        {
            try
            {
                BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
                var objReturn = BusinessRulesStepsInFields.DeleteAsync(x => x.IdStep == 200);
            }
            catch (Exception ex)
            {
                
                Assert.IsTrue(ex.Message == string.Empty);
            }
        }
        /// <summary>
        /// DeleteNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteNullAsync()
        {
            Entities.StepsInFields obj = null;
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRangeAsync(x => x.IdStep ==1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRangeAsync(x => x.IdStep == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorStepsInFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IStepsInFields BusinessRulesStepsInFields = new BusinessRules.BusinessRules.StepsInFields(adaptadorStepsInFields.Object);
            var objReturn = BusinessRulesStepsInFields.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}