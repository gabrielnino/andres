using DataAccess.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Common;

namespace Insttantt.UnitTestsProject.Tests
{

   [TestClass]
    public  class Fields : BaseTest<BusinessRules.Interfaces.IFields>
    {
        private readonly Mock<IMainContext> adaptadorFields;
        /// <summary>
        /// Fields
        /// </summary>
        public Fields()
        {
            var lst = new List<Entities.Fields>()
            {
                    new Entities.Fields {
                        Id =  1,
                        Code = "1",
                        Name = "1"
                    },
                    new Entities.Fields {
                        Id =  2,
                        Code = "2",
                        Name = "2"
                    }
            };

            DbSet<Entities.Fields> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorFields = new Mock<IMainContext>();
            adaptadorFields.Setup(item => item.Set<Entities.Fields>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var lstReturn = BusinessRulesFields.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }

        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(x => x.Id == 1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(x => x.Id == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(x => x.Id == 1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(x => x.Id == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Count(x => x.Id == 1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.Fields>()
            {
                new Entities.Fields { Id = 3 },
                new Entities.Fields { Id = 4 }
            };
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Create(lst);
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.Fields> lst = null;
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Create(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.Fields
            {
                Id = 200,
                Code = "Object",
                Name = "Object"
            };
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.Fields obj = null;
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.Fields
            {
                Id = 1,
                Code = "Object",
                Name = "Object"
            };
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.Fields obj = null;
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.Fields>()
            {
                new Entities.Fields { Id = 3 },
                new Entities.Fields { Id = 4 }
            };

            adaptadorFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.Fields> lst = null;
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.Fields { Id = 1 };
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Delete(x => x.Id == 1);
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
                BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
                var objReturn = BusinessRulesFields.Delete(x => x.Id == 200);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "");
            }
        }
        /// <summary>
        /// DeleteNull
        /// </summary>
        [TestMethod]
        public void DeleteNull()
        {
            Entities.Fields obj = null;
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRange(x => x.Id == 1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRange(x => x.Id == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.Fields> lst = null;
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.Fields
            {
                Id = 200,
                Code = "Object",
                Name = "Object"
            };
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.Fields obj = null;
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.Fields
            {
                Id = 1,
                Code = "Object",
                Name = "Object"
            };
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.Fields>()
            {
                new Entities.Fields { Id = 3 },
                new Entities.Fields { Id = 4 }
            };

            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.Fields> lst = null;
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.Fields { Id = 1 };
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteAsync(x => x.Id == 1);
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
                BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
                var objReturn = BusinessRulesFields.DeleteAsync(x => x.Id == 200);
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
            Entities.Fields obj = null;
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRangeAsync(x => x.Id == 1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRangeAsync(x => x.Id == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IFields BusinessRulesFields = new BusinessRules.BusinessRules.Fields(adaptadorFields.Object);
            var objReturn = BusinessRulesFields.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}