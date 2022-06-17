using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userGRPC.Entity;
using userGRPC.GRPCDB;
using userGRPC.Repository;

namespace userGRPC
{
    public class GreeterService : userService.userServiceBase
    {
        private readonly ILogger<GreeterService> _logger;
        
        private readonly IGreetRepository greetRepo;
        public GreeterService(ILogger<GreeterService> logger, IGreetRepository _greetRepo)
        {
            _logger = logger;
            greetRepo = _greetRepo;
        }

        public override Task<User> Post(User request, ServerCallContext context)
        {
            var usrAdded = new User()
            {
                Id = request.Id,
                NameWithInitail = request.NameWithInitail,
                Mark1 = request.Mark1,
                Mark2 = request.Mark2,
                Mark3 = request.Mark3,
                Position = request.Position
            };

            var res = greetRepo.PostUser(usrAdded);
            return Task.FromResult<User>(res.Result);
        }


        public override async Task<Users> Get(Empty request, ServerCallContext context)
        {          
           var response = await  greetRepo.getUserList();
            Users users = new Users();
            foreach (var item in response)
            {
                User user = new User();
                user.Id = item.Id;
                user.NameWithInitail = item.NameWithInitail;
                user.Mark1 = item.Mark1;
                user.Mark2 = item.Mark2;
                user.Mark3 = item.Mark3;
                user.Position = item.Position;
                users.Items.Add(user);
            }
            return users;
        }


        public override async  Task<User> GetByID(UserRowIdFilter requestData, ServerCallContext context)
        {
            var res = await greetRepo.getUserById(requestData.Id);
            var us = new User()
            {
                Id = res.Id,
                NameWithInitail = res.NameWithInitail,
                Mark1 = res.Mark1,
                Mark2 = res.Mark2,
                Mark3 = res.Mark3,
                Position = res.Position
            };
            return await Task.FromResult(us);
        }


        public override async  Task<User> Put(User request, ServerCallContext context)
        {
            var res = await greetRepo.updateSingleUser(request);
            var us = new User()
            { 
            Id=res.Id,
            NameWithInitail=res.NameWithInitail,
            Mark1=res.Mark1,
            Mark2=res.Mark2,
            Mark3=res.Mark3,
            Position=res.Position

            };
            return await Task.FromResult<User>(us);
        }

        public override async Task<Empty> Delete(UserRowIdFilter requestData, ServerCallContext context)
        {
            var data = await greetRepo.DeleteUser(requestData.Id);

            if (data != null)
            {
                return  await Task.FromResult(new Empty());
            }
            return await Task.FromResult(new Empty());
        }


        public override async Task<CalculateGrade> Calculate(UserRowIdFilter requestData, ServerCallContext context)
        {
            var data = await greetRepo.CalculateGr(requestData.Id);          
                return await Task.FromResult(new CalculateGrade(data));           
        }



    }
}
