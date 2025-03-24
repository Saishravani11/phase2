using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.models;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EFCoreDbContext _context;

        public CustomersController(EFCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.custId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754




        /* [HttpGet("/login/{userName}/{password}")]
         public async Task<ActionResult<string>> GetLogin(string userName, string password)
         {
             Customer? customer = _context.Customers.Where(x => x.custUserName == userName && x.custPassword == password).FirstOrDefault();
             if (customer != null)
             {
                 return "1";
             }
             await _context.SaveChangesAsync();

             return "0";


         }*/
        [HttpGet("/login/{userName}/{password}")]
        public async Task<ActionResult<Customer>> Login(string userName, string password)
        {
            Customer? customer = _context.Customers.Where(x => x.custUserName == userName && x.custPassword == password).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest("The information is not correct..");
            }
            return customer;

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.custId }, customer);
        }
        /* [HttpPost("/addMenu/{menuId}")]
         public async Task<ActionResult<Menu>> PostMenu(Menu menu)
         {
             _context.Menus.Add(menu);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetMenu", new {id=menu.menuId }, menu);
         }*/
        [HttpPost("/addMenu")]
        public async Task<ActionResult<Menu>> PostMenu([FromBody] Menu menu)
        {
            // Validate the input
            if (menu == null)
            {
                return BadRequest("Menu cannot be null.");
            }

            // Add the new menu item to the database
            _context.Menus.Add(menu);

            // Save the changes asynchronously to populate the identity column (MenuId)
            await _context.SaveChangesAsync();

            // After the save, MenuId will be populated, and we can use it in CreatedAtAction
            return CreatedAtAction(nameof(GetCustomer), new { id = menu.menuId }, menu);
        }






        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.custId == id);
        }
        // GET: api/Customers/{id}/wallet
        [HttpGet("/showWallet/{custId}")]
        public async Task<ActionResult<List<Wallet>>> ShowWallet(int custId)
        {
            var walletCustomer = await _context.Wallets.Where(x => x.custId == custId).ToListAsync();
            if (walletCustomer == null)
            {
                return NotFound("Wallet not found..");
            }
            return Ok(walletCustomer);

        }
        [HttpGet("/showMenu/{menuId}")]
        public async Task<ActionResult<List<Menu>>> ShowMenu(int menuId)
        {
            var menu = await _context.Menus.Where(x => x.menuId == menuId).ToListAsync();
            if (menu == null)
            {
                return NotFound("Item not found..");
            }
            return Ok(menu);

        }
        [HttpGet("/showMenu")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

    }
}


    


