using Business.Coomon;
using DTOs.Common_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface IUserBusiness : IGenericRepository<User>
    {
        void AddUser(UserPayloadDTO User);
        void ChangePassword(ChangePasswordDTO user);
        void ForgetPassword(ForgetPasswordDTO user);
        List<UserListDTO> GetAllUsers(Descriptor descriptor);
        UserDetailsDTO GetUserDetails(int id);
        List<LookupDTO> GetUserTypes();
        LoginSuccessfullyDTO  Login(LoginDTO user);
        void UpdateUser(UserPayloadDTO user);
        void AddUsersComment(UsersCommentDTO Comment);


        void sendUserOTP(LoginDTO login);
    }
}
