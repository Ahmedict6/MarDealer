using Business.Coomon;
using Business.Interfaces.Shopping;
using DTOs.Common_DTOs;
using DTOs.Product_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        private readonly IUserBusiness _userBusiness;


        public UsersController(IUserBusiness productBusiness)
        {
            this._userBusiness = productBusiness;
        }

        [HttpGet("GetUserTypes")]
        public async Task<ApiResponse<List<LookupDTO>>> GetUserTypes()
        {
            ApiResponse<List<LookupDTO>> _ApiResponse = new ApiResponse<List<LookupDTO>>();
            var product = await Task.Run<List<LookupDTO>>(() => _userBusiness.GetUserTypes());
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;
            }

            _ApiResponse = new ApiResponse<List<LookupDTO>>();
            _ApiResponse.Data = product;

            return _ApiResponse;

        }
       
        [HttpGet("{id}")]
        public async Task<ApiResponse<UserDetailsDTO>> Get(int id)
        {
            ApiResponse<UserDetailsDTO> _ApiResponse = new ApiResponse<UserDetailsDTO>();
            if (id < 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }
            var product = await Task.Run<UserDetailsDTO>(() => _userBusiness.GetUserDetails(id));
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;
            }

            _ApiResponse = new ApiResponse<UserDetailsDTO>();
            _ApiResponse.Data = product;
            return _ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse<UserDetailsDTO>> Post(UserPayloadDTO User)
        {
            ApiResponse<UserDetailsDTO> _ApiResponse = new ApiResponse<UserDetailsDTO>();
            _userBusiness.AddUser(User);

            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }

        [HttpPut]
        public async Task<ApiResponse<UserDetailsDTO>> Put(UserPayloadDTO userPayload)
        {
            ApiResponse<UserDetailsDTO> _ApiResponse = new ApiResponse<UserDetailsDTO>();
            if (userPayload == null || userPayload.Id == 0)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }
            _userBusiness.UpdateUser(userPayload);
            _ApiResponse.Message = "Updated Successfully ";
            return _ApiResponse;

        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<UserDetailsDTO>> Delete(int id = 0)
        {
            ApiResponse<UserDetailsDTO> _ApiResponse = new ApiResponse<UserDetailsDTO>();
            if (id > 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }

            _userBusiness.Delete(id);

            _ApiResponse.Message = "Deleted Successfully ";
            return _ApiResponse;
        }


        [HttpPost("GetUsers")]
        public Task<ApiResponse<List<UserListDTO>>> GetUsers(Descriptor descriptor)
        {
            ApiResponse<List<UserListDTO>> response = new ApiResponse<List<UserListDTO>>();
            var userList = _userBusiness.GetAllUsers(descriptor);
            response.Data = userList;
            return Task.FromResult(response);
        }

        [HttpPost("Login")]
        public async Task<ApiResponse<LoginSuccessfullyDTO>> Login(LoginDTO User)
        {
            ApiResponse<LoginSuccessfullyDTO> _ApiResponse = new ApiResponse<LoginSuccessfullyDTO>();
          var LoginUser =   _userBusiness.Login(User);

            _ApiResponse.Data = LoginUser;
            _ApiResponse.Message = "login Successfully ";
            return _ApiResponse;
        }

        [HttpPost("ForgetPassword")]
        public async Task<ApiResponse<string>> ForgetPassword(ForgetPasswordDTO User)
        {
            ApiResponse<string> _ApiResponse = new ApiResponse<string>();
            _userBusiness.ForgetPassword(User);

            _ApiResponse.Data = "password resetted Successfully ";
            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }

        [HttpPost("ChangePassword")]
        public async Task<ApiResponse<string>> ChangePassword(ChangePasswordDTO User)
        {
            ApiResponse<string> _ApiResponse = new ApiResponse<string>();
            _userBusiness.ChangePassword(User);

            _ApiResponse.Data = "password changed Successfully ";
            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }


        [HttpPost("AddUsersComment")]
        public async Task<ApiResponse<string>> AddUsersComment(UsersCommentDTO usersComment)
        {
            ApiResponse<string> _ApiResponse = new ApiResponse<string>();
            _userBusiness.AddUsersComment(usersComment);

            _ApiResponse.Data = "comment/Review added Successfully ";
            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }


         [HttpPost("SendOTP")]
        public async Task<ApiResponse<string>> SendUserOTP(LoginDTO login)
        {
            ApiResponse<string> _ApiResponse = new ApiResponse<string>();
            _userBusiness.sendUserOTP(login);

            _ApiResponse.Data = "";
            _ApiResponse.Message = "Send OTP Successfully ";
            return _ApiResponse;
        }



    }
}
