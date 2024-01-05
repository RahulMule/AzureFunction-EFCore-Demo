using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunction_EFCore_Demo.DataContext;
using Microsoft.EntityFrameworkCore;
using AzureFunction_EFCore_Demo.Models;
using System.Linq;

namespace AzureFunction_EFCore_Demo
{

    public class GetAllPortfolio
    {
        private readonly ShareDataContext _context;

        public GetAllPortfolio(ShareDataContext context)
        {
            _context = context;
        }
        
        [FunctionName("GetAllPortfolio")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                var response = await _context.Stocks
                    .Select(s => new
                    {
                        s.StockID,
                        s.StockName,
                        s.Price,
                        s.StockType,
                        StockTransactions = s.StockTransactions.Select(t => new
                        {
                            t.TransactionTime,
                            t.Quantity,
                            t.StockTransactionID
                        })
                    }).ToListAsync();

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError("Error Occurred: " + ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
            
        }

        [FunctionName("AddShare")]
        public async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Function,"post",Route = null)] HttpRequest request, ILogger log)
        {
            log.LogInformation("function has been triggered");
            try
            {
                string response = await request.ReadAsStringAsync();
                var share = JsonConvert.DeserializeObject<Stock>(response);
                await _context.Stocks.AddAsync(share);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Share Added Successfully");
            }
            catch(Exception ex)
            {
                log.LogError("Error Logged while adding share: "+ ex.Message);
                return new BadRequestResult();
            }

        }

        [FunctionName("Update")]
        public async Task<IActionResult> Update(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger log)
        {
            log.LogInformation("function has been triggered");
            try
            {
                string response = await request.ReadAsStringAsync();
                var share = JsonConvert.DeserializeObject<Stock>(response);
                var existingshare = await _context.Stocks.FindAsync(share.StockID);

                if (existingshare != null)
                {
                    existingshare.StockName = share.StockName;
                    existingshare.Price = share.Price;
                    existingshare.StockName = share.StockName;
                    existingshare.StockType = share.StockType;
                    await _context.SaveChangesAsync();
                    return new OkObjectResult("Share Updated Successfully");
                }
                else {
                    return new OkObjectResult("Share not found");
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error Logged while Updating share { ex.Message}");
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [FunctionName("Delete")]
        public async Task<IActionResult> Delete(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger log)
        {
            log.LogInformation("function has been triggered");
            try
            {
                string response = await request.ReadAsStringAsync();
                var share = JsonConvert.DeserializeObject<Stock>(response);
                var existingshare = await _context.Stocks.FindAsync(share.StockID);

                if (existingshare != null)
                {
                   _context.Stocks.Remove(existingshare);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult("Share Deleted Successfully");
                }
                else
                {
                    return new OkObjectResult("Share not found");
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error Logged while Deleting share { ex.Message}");
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}
