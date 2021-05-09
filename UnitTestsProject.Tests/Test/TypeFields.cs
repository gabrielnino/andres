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
    /// TypeFields
    /// </summary>
    [TestClass]
    public  class TypeFields : BaseTest<BusinessRules.Interfaces.ITypeFields>
    {
        private readonly Mock<IMainContext> adaptadorTypeFields;
        /// <summary>
        /// TypeFields
        /// </summary>
        public TypeFields()
        {
            var lst = new List<Entities.TypeFields>()
            {
                    new Entities.TypeFields {
                        Id =  1,
                        Name = "1"
                    },
                    new Entities.TypeFields {
                        Id =  2,
                        Name = "2"
                    }
            };

            DbSet<Entities.TypeFields> myDbSet = GetQueryableMockDbSet(lst);
            adaptadorTypeFields = new Mock<IMainContext>();
            adaptadorTypeFields.Setup(item => item.Set<Entities.TypeFields>()).Returns(myDbSet);
            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var lstReturn = BusinessRulesTypeFields.ToList();
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }
        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(x => x.Id == 1);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(x => x.Id == 100);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(x => x.Id == 1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        ///  SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(x => x.Id == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Search(null, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Count(x => x.Id == 1);
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Count(null);
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.TypeFields>()
            {
                new Entities.TypeFields { Id = 3 },
                new Entities.TypeFields { Id = 4 }
            };
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Create(lst);
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.TypeFields> lst = null;
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Create(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.TypeFields
            {
                Id = 200,
 
                Name = "Object"
            };
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Create(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.TypeFields obj = null;
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.TypeFields
            {
                Id = 1,
                Name = "Object"
            };
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.TypeFields obj = null;
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.TypeFields>()
            {
                new Entities.TypeFields { Id = 3 },
                new Entities.TypeFields { Id = 4 }
            };

            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Edit(lst);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.TypeFields> lst = null;
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Edit(lst);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.TypeFields { Id = 1 };
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Delete(x => x.Id == 1);
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
                BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
                var objReturn = BusinessRulesTypeFields.Delete(x => x.Id == 200);
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
            Entities.TypeFields obj = null;
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRange(x => x.Id == 1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRange(x => x.Id == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorTypeFields.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        ///  CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.TypeFields> lst = null;
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.TypeFields
            {
                Id = 200,
                Name = "Object"
            };
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.TypeFields obj = null;
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.TypeFields
            {
                Id = 1,
                Name = "Object"
            };
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        ///EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.TypeFields>()
            {
                new Entities.TypeFields { Id = 3 },
                new Entities.TypeFields { Id = 4 }
            };

            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.TypeFields> lst = null;
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.TypeFields { Id = 1 };
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteAsync(x => x.Id == 1);
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
                BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
                var objReturn = BusinessRulesTypeFields.DeleteAsync(x => x.Id == 200);
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
            Entities.TypeFields obj = null;
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        ///  DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRangeAsync(x => x.Id == 1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRangeAsync(x => x.Id == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorTypeFields.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.ITypeFields BusinessRulesTypeFields = new BusinessRules.BusinessRules.TypeFields(adaptadorTypeFields.Object);
            var objReturn = BusinessRulesTypeFields.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}