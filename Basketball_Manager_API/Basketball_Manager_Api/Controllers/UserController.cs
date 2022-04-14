using Basketball_Manager_Api.Helpers;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.PutModels;
using Basketball_Manager_Db.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors()]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;
        private readonly JwtService_Api _jwtService;

        public UserController(IUserRepository userRepository, ApplicationDbContext context, JwtService_Api jwtService)
        {
            _userRepository = userRepository;
            _context = context;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUser(string id)
        {
            return Ok(await _userRepository.GetUser(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostRegister(RegisterPostModel registerPostModel)
        {
            return Ok(await _userRepository.PostAccountCreate(registerPostModel));
        }
        [HttpPost("login")]
        public ActionResult PostLogin(LoginPostModel loginPostModel)
        {
            var jwt = _userRepository.GetJwt(loginPostModel);
            if( jwt != "failed")
            {
                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    //HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                });

                return Ok("success");
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpGet("authuser")]
        public ActionResult UserAuthorize()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                var userId = token.Issuer;

                var user = _userRepository.GetUserById(userId);

                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
            
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                //HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
            });

            return Ok("success");
        }

        [HttpPost("uploadImage")]
        public ActionResult UploadImage(IFormFile image)
        {
            var path = "C:\\Basketball_Manager\\Basketball_Manager_API\\Basketball_Manager_Api\\images\\profilePics";
            var fileName = image.FileName;

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return Ok();
        }

        [HttpPut("edit")]
        public async Task<ActionResult> PutEditUser(UserPutModel userPutModel)
        {
            return Ok(await _userRepository.PutEditUser(userPutModel));
        }

        [HttpGet("ranktable")]
        public async Task<ActionResult> GetRankTable()
        {
            return Ok(await _userRepository.GetRankTable());
        }
    }
}
