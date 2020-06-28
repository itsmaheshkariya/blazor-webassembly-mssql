using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorSql.Shared;
using BlazorSql.Server.Models;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET api/user
        [HttpGet("")]
        public ActionResult<List<User>> Getstrings()
        {
            return _userContext.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> GetstringById(int id)
        {
            return _userContext.Users.FirstOrDefault(user => user.Id == id);
        }

        // POST api/user
        [HttpPost("")]
        public User Poststring(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return user;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public User Putstring(int id, User newUser)
        {
         User oldUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
         oldUser.Name = newUser.Name;
         oldUser.Email = newUser.Email;
         oldUser.Password = newUser.Password;
         _userContext.SaveChanges();
         return oldUser;
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public int DeletestringById(int id)
        {
            User oldUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
            _userContext.Users.Remove(oldUser);
            _userContext.SaveChanges();
            return id;
        }
    }
}
