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
    public  class FieldsByUser : BaseTest<BusinessRules.Interfaces.IFieldsByUser>
    {
        private readonly Mock<IMainContext> adaptadorFieldsByUser;
        /// <summary>
        /// FieldsByUser
        /// </summary>
        public FieldsByUser()
        {
            var lst = new List<Entities.FieldsByUser>()
            {
                    new Entities.FieldsByUser {
                       IdUser = 1,
                       IdField = 1 
                       
                    },
                    new Entities.FieldsByUser {
                        IdUser = 1,
                        IdField = 1
                    }
            };

            DbSet<Entities.FieldsByUser> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorFieldsByUser = new Mock<IMainContext>();
            adaptadorFieldsByUser.Setup(item => item.Set<Entities.FieldsByUser>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var lstReturn = BusinessRulesFieldsByUser.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(x => x.IdField == 1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(x => x.IdField == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(x => x.IdField == 1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(x => x.IdField == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Count(x => x.IdField == 1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.FieldsByUser>()
            {
                new Entities.FieldsByUser { IdUser = 3, Value ="3" },
                new Entities.FieldsByUser { IdUser = 4, Value ="3" }
            };
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Create(lst);
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.FieldsByUser> lst = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Create(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.FieldsByUser
            {
                IdField = 200,
 
                IdUser = 10
            };
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.FieldsByUser obj = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.FieldsByUser
            {
                IdField = 1,
                IdUser = 2
            };
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.FieldsByUser obj = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.FieldsByUser>()
            {
                new Entities.FieldsByUser { IdField = 3, IdUser = 3 },
                new Entities.FieldsByUser { IdField = 4, IdUser = 3 }
            };

            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.FieldsByUser> lst = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.FieldsByUser { IdField = 1, IdUser = 2 };
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Delete(x => x.IdField == 1);
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
                BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
                var objReturn = BusinessRulesFieldsByUser.Delete(x => x.IdField == 200);
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
            Entities.FieldsByUser obj = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRange(x => x.IdField == 1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRange(x => x.IdField == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.FieldsByUser> lst = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.FieldsByUser
            {
                IdField = 200,
                IdUser = 200
            };
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.FieldsByUser obj = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.FieldsByUser
            {
                IdField = 1,
                IdUser = 1
            };
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.FieldsByUser>()
            {
                new Entities.FieldsByUser { IdField = 3 , IdUser=1},
                new Entities.FieldsByUser { IdField = 4 , IdUser=1}
            };

            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.FieldsByUser> lst = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.FieldsByUser { IdField = 1 };
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteAsync(x => x.IdField == 1);
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
                BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
                var objReturn = BusinessRulesFieldsByUser.DeleteAsync(x => x.IdField == 200);
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
            Entities.FieldsByUser obj = null;
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRangeAsync(x => x.IdField == 1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRangeAsync(x => x.IdField == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorFieldsByUser.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IFieldsByUser BusinessRulesFieldsByUser = new BusinessRules.BusinessRules.FieldsByUser(adaptadorFieldsByUser.Object);
            var objReturn = BusinessRulesFieldsByUser.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}