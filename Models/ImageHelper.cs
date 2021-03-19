using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse.Models
{
    /// <summary>
    /// This class holds methods to help save images to the system storage.
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// If ModelState  is valid when creating a product, SaveImage will instantiate the product's image
        /// and generates a unique file name to retrieve later. The product's ImageUrl is a path to the product's image
        /// on the system. 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="_env"></param>
        public static void SaveImage(Product product, IWebHostEnvironment _env)
        {
            //instantiate photo
            IFormFile image = product.Image;

            // check file extention (ensure it is a image)
            string extension =
                Path.GetExtension(image.FileName);

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
            {
                //generate unique name to retrieve later
                string newFileName = Guid.NewGuid().ToString();

                //store photo on file system and reference in DB
                if (image.Length > 0) //ensure the file is not empty
                {
                    string filePath = Path.Combine(_env.WebRootPath, "images"
                                                , newFileName + extension);
                    //save location to database (in URL format) with ImageUrl property
                    product.ImageUrl = "images/" + newFileName + extension;
                    //write file to file system
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyToAsync(fs);
                    }
                }

            }

        }

    }
}
