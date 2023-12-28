using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlysProject.Models;
using System.Data.Entity;
using System.Web.Routing;
using System.Web.Mvc;
using VidlysProject.Dtos;
using AutoMapper;

namespace VidlysProject.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicatoinDbContext _context;
        public CustomersController()
        {
            _context = new ApplicatoinDbContext();

        }
        //Get /api/Customers
        public  IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>);

        }
        //Get/api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {

                return NotFound();
            }
                return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //Post /api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id= customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+ customer.Id),customerDto);

        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/customers/{id}")]
        public void UpdteCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id== id);

            if(customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name= customerDto.Name;
            //customerInDb.BirthDate= customerDto.BirthDate;
            //customerInDb.IsSuscribedToNewsletter= customerDto.IsSuscribedToNewsletter;
            //customerInDb.MembershipTypeId= customerDto.MembershipTypeId;
            _context.SaveChanges();

        }
        //Delete/api/customerDto/1
        //[System.Web.Http.HttpDelete]
        //public IHttpActionResult DeleteCustomer(int id)
        //{
        //    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Customers.Remove(customerInDb);
        //     _context.SaveChanges();
        //    return Ok();
        [System.Web.Http.Route("api/customers/{id}")]
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}

