﻿using Com.Bateeq.Service.Pos.Lib.Interfaces;
using Com.Bateeq.Service.Pos.Lib.Services.BateeqshopService;
using Com.Bateeq.Service.Pos.Test.DataUtil.SalesDocDataUtils;
using Com.Danliris.Service.Inventory.Lib;
using Com.Danliris.Service.Inventory.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Com.Bateeq.Service.Pos.Test.Service.BateeqshopServiceTests
{
    public class CustomerServiceTest
    {
        private const string ENTITY = "SalesDocs";
        //private PurchasingDocumentAcceptanceDataUtil pdaDataUtil;
        //private readonly IIdentityService identityService;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

        private PosDbContext _dbContext(string testName)
        {
            var serviceProvider = new ServiceCollection()
              .AddEntityFrameworkInMemoryDatabase()
              .BuildServiceProvider();

            DbContextOptionsBuilder<PosDbContext> optionsBuilder = new DbContextOptionsBuilder<PosDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInternalServiceProvider(serviceProvider);

            PosDbContext dbContext = new PosDbContext(optionsBuilder.Options);

            return dbContext;
        }

       

        private Mock<IServiceProvider> GetServiceProvider()
        {
            HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            message.Content = new StringContent("{\"apiVersion\":\"1.0\",\"statusCode\":200,\"message\":\"Ok\",\"data\":[{\"Id\":7,\"code\":\"USD\",\"rate\":13700.0,\"date\":\"2018/10/20\"}],\"info\":{\"count\":1,\"page\":1,\"size\":1,\"total\":2,\"order\":{\"date\":\"desc\"},\"select\":[\"Id\",\"code\",\"rate\",\"date\"]}}");
            var HttpClientService = new Mock<IHttpClientService>();
            HttpClientService
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(message);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IdentityService)))
                .Returns(new IdentityService() { Token = "Token", Username = "Test" });

            serviceProvider
              .Setup(s => s.GetService(typeof(IIdentityService)))
              .Returns(new IdentityService() { TimezoneOffset = 1, Token = "token", Username = "username" });

            serviceProvider
                .Setup(x => x.GetService(typeof(IHttpClientService)))
                .Returns(new SalesDocIHttpService());


            return serviceProvider;
        }

        [Fact]
        public async void Should_Success_Read()
        {
            var service = new CustomerService(GetServiceProvider().Object, _dbContext(GetCurrentMethod()));
      
            var Response = service.Read("", "Brando","","","","");
            Assert.NotEmpty(Response);
 
        }
        [Fact]
        public async void Should_Success_ReadAddressById()
        {
            var service = new CustomerService(GetServiceProvider().Object, _dbContext(GetCurrentMethod()));

            var Response = service.ReadAddressById(1);
            Assert.NotEmpty(Response);

        }
        [Fact]
        public async void Should_Success_ReadOrderByUserId()
        {
            var service = new CustomerService(GetServiceProvider().Object, _dbContext(GetCurrentMethod()));

            var Response = service.ReadOrderByUserId(345);
            Assert.NotNull(Response);

        }
        [Fact]
        public async void Should_Success_GenerateExcel()
        {
            var service = new CustomerService(GetServiceProvider().Object, _dbContext(GetCurrentMethod()));

            var Response = service.GenerateExcel("", "Brando", "", "", "", "");
            Assert.NotNull(Response);

        }
    }
}
