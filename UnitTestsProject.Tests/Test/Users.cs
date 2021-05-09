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
    /// <summary>
    /// 
    /// </summary>
   [TestClass]
    public  class Users : BaseTest<BusinessRules.Interfaces.IUsers>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Mock<IMainContext> adaptadorUsers;
        /// <summary>
        /// 
        /// </summary>
        public Users()
        {
            var lst = new List<Entities.Users>()
            {
                    new Entities.Users {
                        Id =  1,
                        UserName = "1"
                    },
                    new Entities.Users {
                        Id =  2,
                        UserName = "2"
                    }
            };

            DbSet<Entities.Users> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorUsers = new Mock<IMainContext>();
            adaptadorUsers.Setup(item => item.Set<Entities.Users>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var lstReturn = BusinessRulesUsers.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(x => x.Id == 1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(x => x.Id == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull 
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(x => x.Id == 1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(x => x.Id == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Count(x => x.Id == 1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.Users>()
            {
                new Entities.Users { Id = 3 },
                new Entities.Users { Id = 4 }
            };
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Create(lst);
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.Users> lst = null;
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Create(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.Users
            {
                Id = 200,
 
                UserName = "Object"
            };
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.Users obj = null;
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.Users
            {
                Id = 1,
                UserName = "Object"
            };
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.Users obj = null;
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.Users>()
            {
                new Entities.Users { Id = 3 },
                new Entities.Users { Id = 4 }
            };

            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.Users> lst = null;
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.Users { Id = 1 };
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Delete(x => x.Id == 1);
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
                BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
                var objReturn = BusinessRulesUsers.Delete(x => x.Id == 200);
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
            Entities.Users obj = null;
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRange(x => x.Id == 1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRange(x => x.Id == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorUsers.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.Users> lst = null;
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.Users
            {
                Id = 200,
                UserName = "Object"
            };
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.Users obj = null;
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.Users
            {
                Id = 1,
                UserName = "Object"
            };
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.Users>()
            {
                new Entities.Users { Id = 3 },
                new Entities.Users { Id = 4 }
            };

            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.Users> lst = null;
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.Users { Id = 1 };
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteAsync(x => x.Id == 1);
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
                BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
                var objReturn = BusinessRulesUsers.DeleteAsync(x => x.Id == 200);
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
            Entities.Users obj = null;
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRangeAsync(x => x.Id == 1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRangeAsync(x => x.Id == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorUsers.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IUsers BusinessRulesUsers = new BusinessRules.BusinessRules.Users(adaptadorUsers.Object);
            var objReturn = BusinessRulesUsers.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}