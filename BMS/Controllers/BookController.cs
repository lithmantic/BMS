using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using BMS.Db;

namespace BMS.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private BookContext bookContext;

        public BookController(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

        [HttpGet]
        public List<BookDto> Get()
        {
            return bookContext.GetAllBook();
        } 
    }

}
