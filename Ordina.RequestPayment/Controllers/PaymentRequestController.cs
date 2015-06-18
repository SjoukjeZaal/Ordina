using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Ordina.RequestPayment.Controllers
{
    public class PaymentRequestController : Controller
    {
        // GET: PaymentRequest
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentRequest/Create
        public ActionResult Create()
        {
            return View();
        }
     
        // POST: PaymentRequest/Create
        [HttpPost]
        public ActionResult Create(Ordina.PaymentRequest.Models.PaymentRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://httplistenerba1382aa92944c53b7ed76e782d81722.azurewebsites.net");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.PostAsJsonAsync<Ordina.PaymentRequest.Models.PaymentRequest>("requestpayment", new Ordina.PaymentRequest.Models.PaymentRequest()
                         {
                             Title = request.Title,
                             FullName = request.FullName,
                             Amount = request.Amount,
                             Date = request.Date,
                             Description = request.Description
                         }).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            return View();
                        }
                        else {
                            ModelState.AddModelError("", "Cannot send payment request.");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something is wrong with the Model State.");
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something is wrong.");
                return View();
            }
        }
    }
}
