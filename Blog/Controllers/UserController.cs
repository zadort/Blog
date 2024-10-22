using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using static Blog.Models.Dto;

namespace Blog.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(201, context.NewUser.ToList());
            }
        }

        [HttpGet("{azon}")]
        public ActionResult<User> GetById(Guid azon)
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(200, context.NewUser.FirstOrDefault(x => x.Id == azon));
            }
        }

        [HttpPost]
        public ActionResult<User> Post(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Title = createUserDto.Title,
                Description = createUserDto.Description,
                CretedTime = createUserDto.CretedTime
                LastUpdated = createUserDto.LastUpdated
            };

            using (var context = new UserDbContext())
            {
                context.NewUser.Add(user);
                context.SaveChanges();

                return StatusCode(201, user);
            }
        }

        [HttpPut("{azon}")]
        public ActionResult<User> Put(Guid azon, UpdateUserDto updateUserDto)
        {
            using (var context = new UserDbContext())
            {
                var existingUser = context.NewUser.FirstOrDefault(x => x.Id == azon);

                existingUser.Name = updateUserDto.Name;
                existingUser.Age = updateUserDto.Age;
                existingUser.License = updateUserDto.License;

                context.NewUser.Update(existingUser);
                context.SaveChanges();

                return StatusCode(200, existingUser);
            }
        }

        [HttpDelete]
        public ActionResult<object> Delete(Guid azon)
        {
            using (var context = new UserDbContext())
            {
                var user = context.NewUser.FirstOrDefault(x => x.Id == azon);

                if (user != null)
                {
                    context.NewUser.Remove(user);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés!" });
                }

            }
            return StatusCode(404, new { message = "Nincs ilyen felhasználó!" });
        }
    }
}