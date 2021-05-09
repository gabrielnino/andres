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
    /// StepsNext
    /// </summary>
    [TestClass]
    public  class StepsNext : BaseTest<BusinessRules.Interfaces.IStepsNext>
    {
        private readonly Mock<IMainContext> adaptadorStepsNext;
        /// <summary>
        /// StepsNext
        /// </summary>
        public StepsNext()
        {
            var lst = new List<Entities.StepsNext>()
            {
                new Entities.StepsNext 
                {
                    IdFlow = 1,
                    IdStep = 1,
                    IdStepNext = 1
                },
                new Entities.StepsNext
                {
                    IdFlow = 1,
                    IdStep = 2,
                    IdStepNext = 1
                },
                new Entities.StepsNext
                {
                    IdFlow = 1,
                    IdStep = 2,
                    IdStepNext = 2
                }
            };

            DbSet<Entities.StepsNext> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorStepsNext = new Mock<IMainContext>();
            adaptadorStepsNext.Setup(item => item.Set<Entities.StepsNext>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var lstReturn = BusinessRulesStepsNext.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(x => x.IdFlow == 1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(x => x.IdFlow == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(x => x.IdFlow == 1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(x => x.IdFlow == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Count(x => x.IdFlow == 1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            
            var lst = new List<Entities.StepsNext>()
            {
                new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 2 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 2, IdStepNext = 3 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 3, IdStepNext = 4 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 4, IdStepNext = 5 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 5, IdStepNext = 6 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 7, IdStepNext = 7 }
            };
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Create(lst);
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.StepsNext> lst = null;
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Create(lst);
            Assert.IsTrue(objReturn == null);
        }

        /// <summary>
        ///  CreateSuccessful
        /// </summary>
        [TestMethod]
        public void CreateSuccessful()
        {
            var obj = new Entities.StepsNext { IdFlow = 200 ,IdStep = 1, IdStepNext = 2};
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.StepsNext { IdFlow = 200 };
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Create(obj);
            Assert.IsFalse(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditSuccessful
        /// </summary>
        [TestMethod]
        public void EditSuccessful()
        {
            var obj = new Entities.StepsNext { IdFlow = 1,IdStep=1,IdStepNext=2 };
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditFail
        /// </summary>
        [TestMethod]
        public void EditFail()
        {
            var obj = new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 1 };
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Edit(obj);
            Assert.IsFalse(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        ///  EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.StepsNext>()
            {
                new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 2 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 2, IdStepNext = 3 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 3, IdStepNext = 4 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 4, IdStepNext = 5 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 5, IdStepNext = 6 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 7, IdStepNext = 7 }
            };

            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.StepsNext> lst = null;
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.StepsNext { IdFlow = 1 };
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// /DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Delete(x => x.IdFlow == 1);
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
                BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
                var objReturn = BusinessRulesStepsNext.Delete(x => x.IdFlow == 200);
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
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteRange(x => x.IdFlow == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorStepsNext.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListAsync
        /// </summary>
        [TestMethod]
        public void CreateListAsync()
        {
            var lst = new List<Entities.StepsNext>()
            {
                new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 2 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 2, IdStepNext = 3 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 3, IdStepNext = 4 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 4, IdStepNext = 5 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 5, IdStepNext = 6 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 },
            };
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.StepsNext> lst = null;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// /CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj =  new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 } ;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {

            var obj = new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 };
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditNullAsync
        /// </summary>
        [TestMethod]
        public void EditNullAsync()
        {
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.StepsNext>()
            {
                new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 2 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 2, IdStepNext = 3 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 3, IdStepNext = 4 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 4, IdStepNext = 5 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 5, IdStepNext = 6 },
                new Entities.StepsNext { IdFlow = 1, IdStep = 6, IdStepNext = 7 },
            };

            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.StepsNext> lst = null;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.StepsNext { IdFlow = 1, IdStep = 1, IdStepNext = 2 };
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        ///DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteAsync(x => x.IdFlow == 1);
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
                BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
                var objReturn = BusinessRulesStepsNext.DeleteAsync(x => x.IdFlow == 200);
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
            Entities.StepsNext obj = null;
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteRangeAsync(x => x.IdFlow == 1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteRangeAsync(x => x.IdFlow == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorStepsNext.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IStepsNext BusinessRulesStepsNext = new BusinessRules.BusinessRules.StepsNext(adaptadorStepsNext.Object);
            var objReturn = BusinessRulesStepsNext.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}