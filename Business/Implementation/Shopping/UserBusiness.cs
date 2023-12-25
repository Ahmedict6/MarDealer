using AutoMapper;
using Business.Coomon;
using Business.Interfaces.Shopping;
using DTOs.Common_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Common;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;
using System.Linq.Expressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Business.Implementation.Shopping
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IGenericRepository<Order> orderRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<LookupData> lookupRepo;
        private IGenericRepository<OrderItem> orderItemRepo;
        private IGenericRepository<OrderPayment> paymentRepo;
        private IGenericRepository<ExporterInformation> exporterRepo;
        private IGenericRepository<User> usersRepo;
        private IGenericRepository<UsersComment> UsersCommentRepo;
        private IGenericRepository<Product> ProductRepo;
        private IGenericRepository<DocumentItem> DocumentitemRepo;

        private IMapper _mapper;

        public UserBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<OrderPayment> _paymentRepo,
        IGenericRepository<OrderItem> _orderItemRepo,
            IGenericRepository<Order> _orderRepo,
             IGenericRepository<ExporterInformation> _exporterRepo,
             IGenericRepository<User> _usersRepo,
             IGenericRepository<LookupData> _lookupRepo,
             IMapper mapper,
             IGenericRepository<UsersComment> _usersCommentRepo,
             IGenericRepository<Product> _productRepo,
             IGenericRepository<DocumentItem> _documentitemRepo


             )
        {

            unitOfWork = _unitOfWork;
            orderItemRepo = _orderItemRepo;
            paymentRepo = _paymentRepo;
            orderRepo = _orderRepo;
            this.exporterRepo = _exporterRepo;
            this.usersRepo = _usersRepo;
            this.lookupRepo = _lookupRepo;
            _mapper = mapper;
            UsersCommentRepo = _usersCommentRepo;
            ProductRepo = _productRepo;
            DocumentitemRepo = _documentitemRepo;
        }

        public void Delete(object id)
        {
            usersRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll(Func<User, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<UserListDTO> GetAllUsers(Descriptor descriptor)
        {
            var query = usersRepo.GetAll().AsQueryable();

            var Users = DescriptorProccer.QuryExcuter(descriptor, query);

            List<UserListDTO> orderVms = new List<UserListDTO>();
            foreach (var User in Users)
            {

                // var UserLogUrl = DocumentitemRepo.GetAll().Where(q => q.RefereneceNumber == User.Id && (int)q.DocumentType == (int)CommonEnums.DocumentItemType.UserProfileImage).FirstOrDefault()?.DocumentUrl;

                UserListDTO pvm = new UserListDTO
                {
                    Id = User.Id,
                    UserName = User.UserName,
                    UserCreatedDate = User.UserCreatedDate,
                    UserModifiedDate = User.UserModifiedDate,
                    FullName = User.FullName,
                    Mobile = User.Mobile,
                    UserTypeNo = User.UserTypeNo,
                    //UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == User.UserNo)?.UserName,
                    // = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == User.UserNo && (int)q.DocumentType == (int)DocumentItemType.UserProfileImage).FirstOrDefault().DocumentUrl,

                };
                orderVms.Add(pvm);
            }

            return orderVms;
        }

        public UserDetailsDTO GetUserDetails(int id)
        {

            var user = usersRepo.GetById(id);
            if (user == null)
                return new UserDetailsDTO();

            var UserImage = DocumentitemRepo.GetAll().Where(q => q.RefereneceNumber == id && (int)q.DocumentType == (int)CommonEnums.DocumentItemType.UserProfileImage).FirstOrDefault()?.DocumentUrl;
            var userDetailsDTO = _mapper.Map<UserDetailsDTO>(user);
            userDetailsDTO.UserImage = UserImage;
            return userDetailsDTO;// _mapper.Map<UserDetailsDTO>(user);
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }
        public void AddUser(UserPayloadDTO entity)
        {

            User user = _mapper.Map<User>(entity);
            usersRepo.Insert(user);


            var documrntGuid = Guid.NewGuid();
            foreach (var item in entity.Attachments)
            {
  if (SaveImage(item.AttachmentFile, documrntGuid.ToString()))
            {
                var doc = new DocumentItem
                {
                    DocuemntName = documrntGuid.ToString(),
                    DocumentType = (int)CommonEnums.DocumentItemType.UserProfileImage,
                    RefereneceNumber = entity.Id,
                    DocumentUrl = @"Document/" + documrntGuid.ToString() + ".jpg",
                };
                DocumentitemRepo.Insert(doc);
            }
            }
          

            unitOfWork.Commit();
        }

        public void UpdateUser(UserPayloadDTO entity)
        {

            User user = _mapper.Map<User>(entity);

            usersRepo.Update(user);


            var userImage = DocumentitemRepo.GetAll().Where(q => q.RefereneceNumber == entity.Id && (int)q.DocumentType == (int)CommonEnums.DocumentItemType.UserProfileImage);
            foreach (var item in userImage)
            {
                DocumentitemRepo.Delete(item);
                
            }

            var documrntGuid = Guid.NewGuid();
            foreach (var item in entity.Attachments)
            {
  if (SaveImage(item.AttachmentFile, documrntGuid.ToString()))
            {
                var doc = new DocumentItem
                {
                    DocuemntName = documrntGuid.ToString(),
                    DocumentType = (int)CommonEnums.DocumentItemType.UserProfileImage,
                    RefereneceNumber = entity.Id,
                    DocumentUrl = @"Document/" + documrntGuid.ToString() + ".jpg",
                };
                DocumentitemRepo.Insert(doc);
            }
            }
          


            unitOfWork.Commit();
        }

        User IGenericRepository<User>.GetById(object id)
        {


            return usersRepo.GetById(id);
        }

        public IEnumerable<User> GetAllWithChildren(params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public List<ExporterDTO> GetExporters()
        {
            var exporters = exporterRepo.GetAll();
            var users = usersRepo.GetAll(u => u.UserTypeNo == (int)CommonEnums.UserType.Exporter);
            var query = from user in users
                        join exporter in exporters on user.Id equals exporter.UserNo
                        //  where sa.LocationId == 1
                        select new { user, exporter };
            var result = query.ToList();
            var lookupList = new List<ExporterDTO>();
            foreach (var item in result)
            {
                lookupList.Add(new ExporterDTO() { Id = item.user.Id, ExporterName = item.user.FullName, ExportPercentage = item.exporter.ExportPercentage, FrightPrice = item.exporter.FrightPrice, SocialInsuracePrice = item.exporter.SocialInsuracePrice, Mobile = item.user.Mobile });
            }
            return lookupList;
        }

        public List<LookupDTO> GetUserTypes()
        {
            var lookups = lookupRepo.GetAll(q => q.LookupType == CommonEnums.LookupType.UserType.ToString());
            var lookupList = new List<LookupDTO>();
            foreach (var item in lookups)
            {
                lookupList.Add(new LookupDTO() { Id = item.Id, Value = item.LookupValue, Name = item.LookupName, NameAr = item.LookupName });
            }
            return lookupList;
        }

        public void ChangePassword(ChangePasswordDTO user)
        {
            var loginUser = usersRepo.GetAll().Where(X => X.OTP == user.OTP &&  X.Mobile == user.Mobile)?.FirstOrDefault();
            if (loginUser != null)
            {
                loginUser.Password = user.NewPassword;
                usersRepo.Update(loginUser);
                unitOfWork.Commit();
            }

        }

        public void ForgetPassword(ForgetPasswordDTO user)
        {
            var LoginUser = usersRepo.GetAll().Where(X => X.Mobile == user.Mobile)?.FirstOrDefault();


            if (LoginUser != null)
            {

                String OTP = new Random().Next(9999).ToString("D4");
                
                LoginUser.OTP= OTP;
                usersRepo.Update(LoginUser);



                string accountSid = Environment.GetEnvironmentVariable("TWILIO:TWILIO_ACCOUNT_SID");
                string authToken = Environment.GetEnvironmentVariable("TWILIO:TWILIO_AUTH_TOKEN");
                string From = Environment.GetEnvironmentVariable("TWILIO:TWILIO_From");
                string MassageText  = Environment.GetEnvironmentVariable("TWILIO:changePasswordMassageText");

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: String.Format(MassageText, LoginUser.UserName, OTP),
                    from: new Twilio.Types.PhoneNumber(From),
                    to: new Twilio.Types.PhoneNumber(LoginUser.Mobile)
                );

                unitOfWork.Commit();
            }
        }

        public UserDTO Login(LoginDTO lgoinData)
        {// validation reuired in all functions
            var user = usersRepo.GetAll(q => q.Mobile == lgoinData.Mobile && q.Password == lgoinData.Password).FirstOrDefault();
            if (user != null)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                userDto.FirstName = user.FullName.Split(" ")?[0];
                userDto.UserType = lookupRepo.GetById(user.UserTypeNo)?.LookupValue;
                return userDto;
            }
            else { return null; }
        }

        public void AddUsersComment(UsersCommentDTO CommentDTO)
        {
            var Comment = _mapper.Map<UsersComment>(CommentDTO);

            if (Comment != null)
            {


                if (Comment.CommentType == CommentType.CompanyComment)
                {

                    // check user has order From this Exporter before
                    var orderItem = orderRepo.GetAll().Where(x => x.ExporterNo == Comment.RefranceNumber && x.UserNo == Comment.UserNo).FirstOrDefault();

                    if (orderItem != null)
                    {

                        UsersCommentRepo.Insert(Comment);
                        unitOfWork.Commit();

                    }
                    else
                    {
                        //  Throe new Exption "You cant add Review To This Company"
                    }

                }
                else if (Comment.CommentType == CommentType.ProductComment)
                {
                    // check user has order From this Prudect before
                    var orderItem = orderItemRepo.GetAll().Where(x => x.ProductNo == Comment.RefranceNumber && x.Order.User.Id == Comment.UserNo).FirstOrDefault();

                    if (orderItem != null)
                    {

                        UsersCommentRepo.Insert(Comment);
                        unitOfWork.Commit();

                    }
                    else
                    {
                        //  Throe new Exption "You cant add Review To This Product"
                    }


                }
                else
                {

                    //  Throe new Exption "Invalid Comment Type"

                }



            }

        }

        public void sendUserOTP(LoginDTO login)
        {

            var LoginUser = usersRepo.GetAll().Where(x => x.Mobile == login.Mobile).FirstOrDefault();
            if (LoginUser != null)
            {
                String Password = new Random().Next(9999).ToString("D4");
                LoginUser.Password = Password;
                usersRepo.Update(LoginUser);
                unitOfWork.Commit();

            }
            else
            {

                throw new Exception("Not Registerd");

            }



        }

        public bool SaveImage(string ImgStr, string ImgName)
        {
            String path = Path.GetFullPath("wwwroot/Document");//Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr.Split("base64,")[1]);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }


    }
}
