using AutoMapper;
using Business.Coomon;
using Business.Interfaces.Product_Business;
using DTOs.Common_DTOs;
using DTOs.Product_DTOs;
using Entities.Models.Common;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;
using System.Linq.Expressions;
using static DTOs.Common_DTOs.CommonEnums;

namespace Business.Implementation.Product_Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<SubCategory> subCategoryRepo;
        private IGenericRepository<ProductInventory> productInventoryReop;
        private readonly IGenericRepository<DocumentItem> documentItemRepo;
        private IGenericRepository<ProductCategory> productCategoryRepo;
        private IGenericRepository<SubOfSubCategory> subOfSubCategoryRepo;
        private IGenericRepository<ProductSpecification> productSpecificationRepo;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IGenericRepository<User> usersRepo;
        private IMapper _mapper;

        public ProductBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<SubCategory> _subCategoryRepo,
            IGenericRepository<ProductCategory> _productCategoryRepo,
            IGenericRepository<SubOfSubCategory> _subOfSubCategoryRepo,
            IGenericRepository<DocumentItem> _documentItemRepo,
            IGenericRepository<ProductInventory> _productInventoryReop,
            IGenericRepository<Product> _productRepo,
            IGenericRepository<ProductSpecification> _productSpecificationRepo,
             IGenericRepository<UsersComment> _usersCommentrRepo,
             IGenericRepository<User> _usersRepo,
             IMapper mapper)
        {

            unitOfWork = _unitOfWork;
            subCategoryRepo = _subCategoryRepo;
            productCategoryRepo = _productCategoryRepo;
            subOfSubCategoryRepo = _subOfSubCategoryRepo;
            productInventoryReop = _productInventoryReop;
            documentItemRepo = _documentItemRepo;
            productRepo = _productRepo;
            this.productSpecificationRepo = _productSpecificationRepo;
            this.usersCommentrRepo = _usersCommentrRepo;
            this.usersRepo = _usersRepo;
            _mapper = mapper;

        }

        public void Delete(object id)
        {



            var productspecifications = productSpecificationRepo.GetAll().Where(x => x.ProductNo == (int)id);
            foreach (var specification in productspecifications)
            {
                productSpecificationRepo.Delete(specification.Id);
            }

            var productImages = documentItemRepo.GetAll().Where(x => x.RefereneceNumber == (int)id && (int)x.DocumentType == (int)DocumentItemType.ProductImage);
            foreach (var image in productImages)
            {
                documentItemRepo.Delete(image.Id);
            }


            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Func<Product, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<ProductListDTO> GetAllProducts(Descriptor descriptor)
        {
            var query = productRepo.GetAll().AsQueryable();

            var Products = DescriptorProccer.QuryExcuter(descriptor, query);

            List<ProductListDTO> productVms = new List<ProductListDTO>();
            foreach (var Product in Products)
            {


                ProductListDTO pvm = new ProductListDTO
                {
                    Id = Product.Id,
                    ProductName = Product.ProductName,
                    ProductDescritpion = Product.ProductDescritpion,
                    ProductPrice = Product.ProductPrice,
                    UserNo = Product.UserNo,
                    UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == Product.UserNo)?.UserName,
                    UserLogUrl = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == Product.UserNo && (int)q.DocumentType == (int)DocumentItemType.UserProfileImage).FirstOrDefault().DocumentUrl,
                    ProductUnit = Product.ProductUnit,
                    ProductImageUrl = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == Product.Id && (int)q.DocumentType == (int)DocumentItemType.ProductImage).FirstOrDefault().DocumentUrl,

                };
                productVms.Add(pvm);
            }

            return productVms;
        }

        public ProductDetailsDTO GetProductDetails(int id)
        {

            var product = productRepo.GetAllWithChildren(
                p => p.SubCategory,
                p => p.ProductCategory,
                p => p.ProductInventory,
                p => p.ProductDiscount
                ).FirstOrDefault(p => p.Id == id);


            var productImages = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == product.Id && (int)q.DocumentType == (int)DocumentItemType.ProductImage).ToList();
            var productComment = usersCommentrRepo.GetAll()?.Where(q => q.RefranceNumber == product.Id && (int)q.CommentType == (int)CommentType.ProductComment)?.ToList();
            var ProductSpecification = productSpecificationRepo.GetAll()?.Where(q => q.ProductNo == product.Id)?.ToList();


            var productDetails = new ProductDetailsDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescritpion = product.ProductDescritpion,
                ProductPrice = product.ProductPrice,
                ProductCategoryNo = product.ProductCategoryNo,
                ProductCategory = product.ProductCategory,
                SubCategoryNo = product.SubCategoryNo,
                SubCategory = product.SubCategory,
                SubOfSubCategoryNo = product.SubOfSubCategoryNo,
                SubOfSubCategory = product.SubOfSubCategory,
                ProductInventory = product.ProductInventory,
                ProductInventoryNo = product.ProductInventoryNo,
                ProductDiscountNo = product.ProductDiscountNo,
                ProductDiscount = product.ProductDiscount,
                UserNo = product.UserNo,
                ProductUnit = product.ProductUnit,
                ProductComments = productComment,
                ProductSpecifications = _mapper.Map<List<ProductSpecificationDTO>>(ProductSpecification) ,
                ProductImages = productImages,
                ProductCreatedDate = product.ProductCreatedDate,
                ProductModifiedDate = product.ProductModifiedDate,


            };




            return productDetails;
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }


        public void InsertProduct(ProductPayloadDTO entity)
        {
            Product product = _mapper.Map<Product>(entity);
            productRepo.Insert(product);
            unitOfWork.Commit();
            foreach (var item in entity.Images)
            {
                var documrntGuid = Guid.NewGuid(); ;
                if (SaveImage(item, documrntGuid.ToString()))
                {
                    var doc = new DocumentItem
                    {
                        DocuemntName = documrntGuid.ToString(),
                        DocumentType = DocumentItem.DocumentItemType.ProductImage,
                        RefereneceNumber = product.Id,
                        DocumentUrl = @"Document/" + documrntGuid.ToString() + ".jpg",
                    };
                    documentItemRepo.Insert(doc);
                }
            }


            foreach (var NewProdectspecification in entity.ProductSpecifications)
            {
                var NewProdectspecificationItem = new ProductSpecification
                {

                    ProductNo = product.Id,
                    SpecificationName = NewProdectspecification.SpecificationName,
                    SpecificationDescritpion = NewProdectspecification.SpecificationDescritpion

                };
                productSpecificationRepo.Insert(NewProdectspecificationItem);

            }


            unitOfWork.Commit();
        }


        public void UpdateProduct(ProductPayloadDTO entity)
        {

            Product product = _mapper.Map<Product>(entity);
            productRepo.Update(product);
            var oldImages = documentItemRepo.GetAll().Where(x => x.RefereneceNumber == entity.Id && (int)x.DocumentType == (int)DocumentItemType.ProductImage);
            foreach (var image in oldImages)
            {
                documentItemRepo.Delete(image.Id);
            }

            foreach (var item in entity.Images)
            {
                var documrntGuid = Guid.NewGuid(); ;
                if (SaveImage(item, documrntGuid.ToString()))
                {
                    var doc = new DocumentItem
                    {
                        DocuemntName = documrntGuid.ToString(),
                        DocumentType = DocumentItem.DocumentItemType.ProductImage,
                        RefereneceNumber = entity.Id,
                        DocumentUrl = @"Document/" + documrntGuid.ToString() + ".jpg",
                    };
                    documentItemRepo.Insert(doc);
                }
            }

            var oldspecifications = productSpecificationRepo.GetAll().Where(x => x.ProductNo == entity.Id);
            foreach (var oldspecification in oldspecifications)
            {
                productSpecificationRepo.Delete(oldspecification.Id);
            }

            foreach (var NewProdectspecification in entity.ProductSpecifications)
            {
                var NewProdectspecificationItem = new ProductSpecification
                {

                    ProductNo = entity.Id,
                    SpecificationName = NewProdectspecification.SpecificationName,
                    SpecificationDescritpion = NewProdectspecification.SpecificationDescritpion

                };
                productSpecificationRepo.Insert(NewProdectspecificationItem);

            }


            unitOfWork.Commit();
        }

        Product IGenericRepository<Product>.GetById(object id)
        {


            return productRepo.GetById(id);
        }

        public IEnumerable<Product> GetAllWithChildren(params Expression<Func<Product, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
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

        public void DeleteRange(object id)
        {
            throw new NotImplementedException();
        }
    }
}
