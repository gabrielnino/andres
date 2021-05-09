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


    [TestClass]
    public  class Flows : BaseTest<BusinessRules.Interfaces.IFlows>
    {
        private readonly Mock<IMainContext> adaptadorFlows;
        /// <summary>
        /// Flows
        /// </summary>
        public Flows()
        {
            var lst = new List<Entities.Flows>()
            {
                new Entities.Flows 
                { 
                    Id =  1,
                    Name = "2" 
                },
                new Entities.Flows 
                { 
                    Id = 2,
                    Name = "2" 
                }
            };

            DbSet<Entities.Flows> myDbSet = GetQueryableMockDbSet(lst);

            adaptadorFlows = new Mock<IMainContext>();
            adaptadorFlows.Setup(item => item.Set<Entities.Flows>()).Returns(myDbSet);

            AddAdaptadorMock();
        }
        /// <summary>
        /// ToList
        /// </summary>
        [TestMethod]
        public void ToList()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var lstReturn = BusinessRulesFlows.ToList();

            
            Assert.IsTrue(lstReturn != null && lstReturn.Count > 0);
        }


        /// <summary>
        /// SearchNotFind
        /// </summary>
        [TestMethod]
        public void SearchNotFind()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Search(x => x.Id == 100);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchNull
        /// </summary>
        [TestMethod]
        public void SearchNull()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Search(null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchInclude
        /// </summary>
        [TestMethod]
        public void SearchInclude()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Search(x => x.Id == 1, null);

            
            Assert.IsTrue(objReturn != null);
        }
        /// <summary>
        /// SearchIncludeNotFind
        /// </summary>
        [TestMethod]
        public void SearchIncludeNotFind()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Search(x => x.Id == 100, null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// SearchIncludeNull
        /// </summary>
        [TestMethod]
        public void SearchIncludeNull()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Search(null, null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Count
        /// </summary>
        [TestMethod]
        public void Count()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Count(x => x.Id == 1);

            
            Assert.IsTrue(objReturn > 0);
        }
        /// <summary>
        /// CountDefault
        /// </summary>
        [TestMethod]
        public void CountDefault()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Count(null);

            
            Assert.IsTrue(objReturn == 0);
        }
        /// <summary>
        ///  CreateList(
        /// </summary>
        [TestMethod]
        public void CreateList()
        {
            var lst = new List<Entities.Flows>()
            {
                new Entities.Flows { Id = 3 },
                new Entities.Flows { Id = 4 }
            };
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Create(lst);

            
            Assert.IsTrue(objReturn != null && objReturn > 0);
        }
        /// <summary>
        /// CreateListNull
        /// </summary>
        [TestMethod]
        public void CreateListNull()
        {
            List<Entities.Flows> lst = null;
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Create(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Create
        /// </summary>
        [TestMethod]
        public void Create()
        {
            var obj = new Entities.Flows
            {
                Id = 200,
                Name = "Object"
            };
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Create(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value > 0);
        }
        /// <summary>
        /// CreateNull
        /// </summary>
        [TestMethod]
        public void CreateNull()
        {
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Create(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Edit
        /// </summary>
        [TestMethod]
        public void Edit()
        {
            var obj = new Entities.Flows
            {
                Id = 1,
                Name = "Object"
            };
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Edit(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditNull
        /// </summary>
        [TestMethod]
        public void EditNull()
        {
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Edit(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// EditList
        /// </summary>
        [TestMethod]
        public void EditList()
        {
            var lst = new List<Entities.Flows>()
            {
                new Entities.Flows { Id = 3 },
                new Entities.Flows { Id = 4 }
            };

            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(lst.Count);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Edit(lst);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// EditListNull
        /// </summary>
        [TestMethod]
        public void EditListNull()
        {
            List<Entities.Flows> lst = null;
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Edit(lst);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// Delete
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var obj = new Entities.Flows { Id = 1 };
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Delete(obj);

            
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteExpression
        /// </summary>
        [TestMethod]
        public void DeleteExpression()
        {
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Delete(x => x.Id == 1);

            
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
                BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
                var objReturn = BusinessRulesFlows.Delete(x => x.Id == 200);
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
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(null);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.Delete(obj);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        [TestMethod]
        public void DeleteRange()
        {
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRange(x => x.Id == 1);
            Assert.IsTrue(objReturn != null && objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeFalse
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalse()
        {
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRange(x => x.Id == 100);
            Assert.IsTrue(objReturn != null && !objReturn.Value);
        }
        /// <summary>
        /// DeleteRangeNull
        /// </summary>
        [TestMethod]
        public void DeleteRangeNull()
        {
            adaptadorFlows.Setup(item => item.SaveChanges()).Returns(1);
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRange(null);

            
            Assert.IsTrue(objReturn == null);
        }
        /// <summary>
        /// CreateListAsync
        /// </summary>
        [TestMethod]
        public void CreateListAsync()
        {
            var lst = new List<Entities.Flows>()
            {
                new Entities.Flows { Id = 3 },
                new Entities.Flows { Id = 4 }
            };
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.CreateAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateListNullAsync
        /// </summary>
        [TestMethod]
        public void CreateListNullAsync()
        {
            List<Entities.Flows> lst = null;
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.CreateAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        [TestMethod]
        public void CreateAsync()
        {
            var obj = new Entities.Flows
            {
                Id = 200,
                Name = "Object"
            };
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.CreateAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value > 0);
        }
        /// <summary>
        /// CreateNullAsync
        /// </summary>
        [TestMethod]
        public void CreateNullAsync()
        {
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.CreateAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        [TestMethod]
        public void EditAsync()
        {
            var obj = new Entities.Flows
            {
                Id = 1,
                Name = "Object"
            };
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.EditAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditNullAsync
        /// </summary>
        [TestMethod]
        public void EditNullAsync()
        {
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.EditAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// EditListAsync
        /// </summary>
        [TestMethod]
        public void EditListAsync()
        {
            var lst = new List<Entities.Flows>()
            {
                new Entities.Flows { Id = 3 },
                new Entities.Flows { Id = 4 }
            };

            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(lst.Count));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.EditAsync(lst);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// EditListNullAsync
        /// </summary>
        [TestMethod]
        public void EditListNullAsync()
        {
            List<Entities.Flows> lst = null;
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.EditAsync(lst);

            
            Assert.IsTrue(objReturn != null && objReturn.Result == null);
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        [TestMethod]
        public void DeleteAsync()
        {
            var obj = new Entities.Flows { Id = 1 };
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteExpressionAsync
        /// </summary>
        [TestMethod]
        public void DeleteExpressionAsync()
        {
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteAsync(x => x.Id == 1);

            
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
                BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
                var objReturn = BusinessRulesFlows.DeleteAsync(x => x.Id == 200);
            }
            catch (Exception ex)
            {
                
                Assert.IsTrue(ex.Message == String.Empty);
            }
        }
        /// <summary>
        /// DeleteNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteNullAsync()
        {
            Entities.Flows obj = null;
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteAsync(obj);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeAsync()
        {
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRangeAsync(x => x.Id == 1);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeFalseAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeFalseAsync()
        {
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRangeAsync(x => x.Id == 100);

            
            Assert.IsTrue((objReturn != null && objReturn.Result != null) && !objReturn.Result.Value);
        }
        /// <summary>
        /// DeleteRangeNullAsync
        /// </summary>
        [TestMethod]
        public void DeleteRangeNullAsync()
        {
            adaptadorFlows.Setup(item => item.SaveChangesAsync(default)).Returns(Task.FromResult(0));
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.DeleteRangeAsync(null);
            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchNullAsync
        /// </summary>
        [TestMethod]
        public void SearchNullAsync()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.SearchAsync(null);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
        /// <summary>
        /// SearchIncludeNullAsync
        /// </summary>
        [TestMethod]
        public void SearchIncludeNullAsync()
        {
            BusinessRules.Interfaces.IFlows BusinessRulesFlows = new BusinessRules.BusinessRules.Flows(adaptadorFlows.Object);
            var objReturn = BusinessRulesFlows.SearchAsync(null, null);

            
            Assert.IsTrue((objReturn != null && objReturn.Result == null));
        }
    }
}