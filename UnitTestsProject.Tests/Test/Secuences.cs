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
    /// Secuences
    /// </summary>
    [TestClass]
    public  class Secuences : BaseTest<BusinessRules.Interfaces.ISecuences>
    {
        private readonly Mock<IMainContext> adaptadorSecuences;
        /// <summary>
        /// Secuences
        /// </summary>
        public Secuences()
        {
            var lst = new List<Entities.Secuences>()
            {
                new Entities.Secuences 
                { 
                    IdFlow =  1
					,IdFlowNavigation = new Entities.Flows { Id = 1 }

					,IdStepNavigation = new Entities.Steps { Id =1 }

                },
                new Entities.Secuences 
                { 
                    IdFlow = 2
					,IdFlowNavigation = new Entities.Flows { Id = 1 }

					,IdStepNavigation = new Entities.Steps { Id =1 }

                }
            };

            DbSet<Entities.Secuences> myDbSet = GetQueryableMockDbSet(lst);

            adaptadorSecuences = new Mock<IMainContext>();
            adaptadorSecuences.Setup(item => item.Set<Entities.Secuences>()).Returns(myDbSet);

            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var lstReturn = BusinessRulesSecuences.ToList();

            
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(x => x.IdFlow == 1);

            
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(x => x.IdFlow == 100);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(x => x.IdFlow == 1, null);

            
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(x => x.IdFlow == 100, null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Search(null, null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Count(x => x.IdFlow == 1);

            
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Count(null);

            
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.Secuences>()
            {
                new Entities.Secuences { IdFlow = 3 },
                new Entities.Secuences { IdFlow = 4 }
            };
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Create(lst);

            
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.Secuences> lst = null;
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Create(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.Secuences { IdFlow = 200 };
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Create(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Create(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.Secuences { IdFlow = 1 };
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Edit(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Edit(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.Secuences>()
            {
                new Entities.Secuences { IdFlow = 3 },
                new Entities.Secuences { IdFlow = 4 }
            };

            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Edit(lst);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.Secuences> lst = null;
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Edit(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.Secuences { IdFlow = 1 };
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Delete(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Delete(x => x.IdFlow == 1);

            
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
                BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
                var objReturn = BusinessRulesSecuences.Delete(x => x.IdFlow == 200);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == String.Empty);
            }
        }
        /// <summary>
        /// DeleteNull
        /// </summary>
        [TestMethod]
        public void DeleteNull()
        {
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.Delete(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRange(x => x.IdFlow == 1);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRange(x => x.IdFlow == 100);

            
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorSecuences.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRange(null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListAsync
        /// </summary>
        [TestMethod]
        public void CreateListAsync()
        {
            var lst = new List<Entities.Secuences>()
            {
                new Entities.Secuences { IdFlow = 3 },
                new Entities.Secuences { IdFlow = 4 }
            };
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.CreateAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.Secuences> lst = null;
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.CreateAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.Secuences { IdFlow = 200 };
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.CreateAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.CreateAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.Secuences { IdFlow = 1 };
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.EditAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditNullAsync
        /// </summary>
        [TestMethod]
        public void EditNullAsync()
        {
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.EditAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.Secuences>()
            {
                new Entities.Secuences { IdFlow = 3 },
                new Entities.Secuences { IdFlow = 4 }
            };

            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.EditAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.Secuences> lst = null;
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.EditAsync(lst);

            
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.Secuences { IdFlow = 1 };
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteAsync(x => x.IdFlow == 1);

            
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
                BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
                var objReturn = BusinessRulesSecuences.DeleteAsync(x => x.IdFlow == 200);
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
            Entities.Secuences obj = null;
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRangeAsync(x => x.IdFlow == 1);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRangeAsync(x => x.IdFlow == 100);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorSecuences.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.DeleteRangeAsync(null);
            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.SearchAsync(null);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        ///  SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.ISecuences BusinessRulesSecuences = new BusinessRules.BusinessRules.Secuences(adaptadorSecuences.Object);
            var objReturn = BusinessRulesSecuences.SearchAsync(null, null);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}