using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Principal;
using OMS.Exception;
using OMS.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace OMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IConfiguration _configuration;
        //Global Exception Handling
        Response resp;
        private readonly OrdersContext _context;
        public OrdersController(OrdersContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // Get All Orders 
        [HttpGet]
        public Response GetAllOrders()
        {
            try
            {
                resp = new Response(true, string.Empty, 200, _context.OrderItems.FromSql("dbo.proc_GetAllOrders").ToList());

            }
          
              catch (System.Exception ex)
            {

                resp = new Response(false, ex.Message, ControllerContext.HttpContext.Response.StatusCode, null);
            }

            return resp;

        }


        // Get Order Details by ID
        [HttpGet("{id}", Name = "GetOrderById")]
        public Response GetOrderById(int id)
        {
            try
            {
                resp = new Response(true, string.Empty, 200, _context.OrderItems.FromSql("ssm.proc_GetOrderById @p_order_id = {0} ", id).ToList());
            }
            catch (System.Exception ex)
            {
                resp = new Response(false, ex.Message, ControllerContext.HttpContext.Response.StatusCode, null);
            }
            return resp;
        }

       

        // Placing the  new Order 
        [HttpPost]
        public Response Add([FromBody] Orders order)
        {

            try
            {
                resp = new Response(true, string.Empty, 200, _context.BuyerId.FromSql("ssm.proc_OrderPlacing  @p_OrderDate ={0}, @p_ShippingDate ={1}, @p_TransactionStatus={2}, @p_PaymentDate ={3}, @p_id_TotalAmount ={4}, @p_id_BillingAddress ={5},@p_ShippingAddress ={6} , @p_PhoneNumber ={7}, EmailId={8}", order.OrderDate, order.ShippingDate, order.TransactionStatus, order.PaymentDate, order.TotalAmount, order.BillingAddress, order.ShippingAddress).ToList().First().buyerId);
                if (order.saveType == 1) // on success of Order Placement Sending Mail
                    SendMail(Convert.ToInt32(resp.data));
            }

            catch (System.Exception ex)
            {
                resp = new Response(false, ex.Message, ControllerContext.HttpContext.Response.StatusCode, null);
            }

            return resp;
        }

        public void SendMail(int VisitorId)
        {
            try
            {

                //From Address 
                string FromAddress = _configuration.GetValue<string>("FromMailId");
                string FromAdressTitle = "Email from OMS";
                //To Address 
                string ToAddress = _configuration.GetValue<string>("ToMailId"); ;
                string ToAdressTitle = "Approval";
                string Subject = "Confirmation of Order";

                string BodyContent = "Your Order has been Successfully Placed ";

                //Smtp Server 
                string SmtpServer = "smtp.office365.com";
                //Smtp Port Number 
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent

                };

                using (var client = new SmtpClient())
                {

                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    client.Authenticate(_configuration.GetValue<string>("OrderConfirmationMail"), _configuration.GetValue<string>("FromMailPassword"));
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}