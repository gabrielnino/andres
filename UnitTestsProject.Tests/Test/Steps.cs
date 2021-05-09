namespace Insttantt.UnitTestsProject.Tests
{
    using DataAccess.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Test.Common;
    using Utilities;

    [TestClass]
    public  class Steps : BaseTest<BusinessRules.Interfaces.ISteps>
    {
        private readonly Mock<IMainContext> adaptadorSteps;
        /// <summary>
        /// Steps
        /// </summary>
        public Steps()
        {
            var lst = new List<Entities.Steps>()
            {
                new Entities.Steps 
                { 
                    Id = 1, 
                    Code = "1", 
                    Name = "1" 
                },
                new Entities.Steps 
                { 
                    Id = 2, 
                    Code = "2", 
                    Name = "2" 
                }
            };

            DbSet<Entities.Steps> myDbSet = GetQueryableMockDbSet(lst);

            adaptadorSteps = new Mock<IMainContext>();
            adaptadorSteps.Setup(item => item.Set<Entities.Steps>()).Returns(myDbSet);

            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var lstReturn = BusinessRulesSteps.ToList();

            
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }




        /// <summary>
        /// Search
        /// </summary>
        [TestMethod]
        public void Search()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(x => x.Id ==1);

            
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(x => x.Id == GetValue<int>("100", nameof(Entities.Steps.Id)));

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(x => x.Id ==1, null);
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(x => x.Id == 100, null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Search(null, null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Count(x => x.Id ==1);

            
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Count(null);

            
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        /// CreateList
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.Steps>()
            {
                new Entities.Steps { Id = 3 },
                new Entities.Steps { Id = 4 }
            };
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Create(lst);

            
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.Steps> lst = null;
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Create(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.Steps 
            { 
                Id = 200, 
                Code = "Object", 
                Name = "Object" 
            };
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Create(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Create(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.Steps 
            {
                Id =1,
                Code = "Object",
                Name = "Object" 
            };
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Edit(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Edit(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.Steps>()
            {
                new Entities.Steps { Id = 3 },
                new Entities.Steps { Id = 4 }
            };

            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Edit(lst);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.Steps> lst = null;
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Edit(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.Steps { Id = 1 };
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Delete(obj);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Delete(x => x.Id ==1);
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
                BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
                var objReturn = BusinessRulesSteps.Delete(x => x.Id == 200);
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
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.Delete(obj);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRange(x => x.Id ==1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRange(x => x.Id == GetValue<int>("100", nameof(Entities.Steps.Id)));
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorSteps.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRange(null);
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListAsync
        /// </summary>
        [TestMethod]
        public void CreateListAsync()
        {
            var lst = new List<Entities.Steps>()
            {
                new Entities.Steps { Id = 3 },
                new Entities.Steps { Id = 4 }
            };
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.Steps> lst = null;
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.CreateAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.Steps 
            {
                Id = 200, 
                Code = "Object", 
                Name = "Object" 
            };
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.CreateAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.CreateAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.Steps 
            {
                Id =1,
                Code = "Object", 
                Name = "Object"
            };
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditNullAsync
        /// </summary>
        [TestMethod]
        public void EditNullAsync()
        {
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.EditAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.Steps>()
            {
                new Entities.Steps { Id = 3 },
                new Entities.Steps { Id = 4 }
            };

            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.EditAsync(lst);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.Steps> lst = null;
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.EditAsync(lst);
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.Steps { Id =1 };
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteAsync(x => x.Id ==1);
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
                BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
                var objReturn = BusinessRulesSteps.DeleteAsync(x => x.Id == 200);
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
            Entities.Steps obj = null;
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteAsync(obj);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRangeAsync(x => x.Id ==1);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRangeAsync(x => x.Id == 100);
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorSteps.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.DeleteRangeAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.SearchAsync(null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.ISteps BusinessRulesSteps = new BusinessRules.BusinessRules.Steps(adaptadorSteps.Object);
            var objReturn = BusinessRulesSteps.SearchAsync(null, null);
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }

       
    }
}