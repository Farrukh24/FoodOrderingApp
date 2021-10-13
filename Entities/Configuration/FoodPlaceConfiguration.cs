using Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class FoodPlaceConfiguration : IEntityTypeConfiguration<FoodPlace>
    {
        public void Configure(EntityTypeBuilder<FoodPlace> builder)
        {
            builder.HasData(
                new FoodPlace
                {
                    Id = 1,
                    Name = "KFC",
                    SmallDescription = "Fast Food",
                    FoodPictureUrlPath = "https://i.pinimg.com/564x/84/9a/2d/849a2d6561194b8c9675371cac8bac4e.jpg",
                    BrandPictureUrlPath = "https://i.pinimg.com/564x/08/49/bc/0849bc1b9e2ac21acb66ceb9fff27bcd.jpg",
                    CategoryId = 1
                },
                    new FoodPlace
                    {
                        Id = 2,
                        Name = "Max Way",
                        SmallDescription = "Fast Food",
                        FoodPictureUrlPath = "https://www.afisha.uz/ui/materials/2020/04/0577662_b.jpeg",
                        BrandPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-p/1c/bf/3b/28/caption.jpg",
                        CategoryId = 1
                    },
                    new FoodPlace
                    {
                        Id = 3,
                        Name = "Pasternak",
                        SmallDescription = "Restaurant",
                        FoodPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-s/1c/ec/43/86/caption.jpg",
                        BrandPictureUrlPath = "https://www.afisha.uz/ui/catalog/2018/01/0375347.jpeg",
                        CategoryId = 2
                    },
                    new FoodPlace
                    {
                        Id = 4,
                        Name = "Yapona Mama",
                        SmallDescription = "Restaurant",
                        FoodPictureUrlPath = "https://fastly.4sqi.net/img/general/200x200/18754087_77qAsyd3iMp8lH2W_Plb4gBwnNCIeslk9k3dmvM93co.jpg",
                        BrandPictureUrlPath = "https://resto.uz/data/resto/43/4280/yapona-mama-2922.jpg",
                        CategoryId = 2
                    },
                    new FoodPlace
                    {
                        Id = 5,
                        Name = "EVOS",
                        SmallDescription = "Fast Food",
                        FoodPictureUrlPath = "https://scontent.ftas1-1.fna.fbcdn.net/v/t1.6435-9/p640x640/88307190_1962819137184306_5868838897475125248_n.jpg?_nc_cat=108&ccb=1-5&_nc_sid=e3f864&_nc_ohc=WT2jzXgB9pYAX9ACyTG&_nc_ht=scontent.ftas1-1.fna&oh=39380039897666d25950a2170c0e9009&oe=617A2176",
                        BrandPictureUrlPath = "https://dostavkainfo.uz/wp-content/uploads/2020/03/evos-768x768.png",
                        CategoryId = 1
                    },
                    new FoodPlace
                    {
                        Id = 6,
                        Name = "Afsona",
                        SmallDescription = "Restaurant",
                        FoodPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-s/1c/e8/83/90/afsona.jpg",
                        BrandPictureUrlPath = "https://scontent.ftas1-1.fna.fbcdn.net/v/t1.6435-9/93763812_2715252408600163_3272490291839369216_n.jpg?_nc_cat=106&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=-WsWw5H8fdIAX8fDoQ3&tn=ozEfXBCfCcG1aK_R&_nc_ht=scontent.ftas1-1.fna&oh=6d74badca52df34d6d31d265a4f82d1f&oe=6178AA14",
                        CategoryId = 2
                    }
                );
        }
        
    }
}

