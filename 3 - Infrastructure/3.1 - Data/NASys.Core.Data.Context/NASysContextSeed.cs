using Microsoft.Extensions.Logging;
using NASys.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASys.Core.Data.Context
{
    public class NASysContextSeed
    {
        public static async Task SeedAsync(NASysContext catalogContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {

                if (!catalogContext.users.Any())
                {
                    catalogContext.users.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        static IEnumerable<Users> GetPreconfiguredItems()
        {
            return new List<Users>()
            {
                 new Users(){ Mobile = "13512341234" , Balance = 1000, CreateTime = DateTime.Now, Pwd = "123456", Status = 1, UseBalance = 800, Encrypt = "123"}
            };
        }
    }
}
