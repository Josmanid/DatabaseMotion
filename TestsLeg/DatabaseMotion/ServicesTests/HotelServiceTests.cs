using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DatabaseMotion.DBContext.Repository;
using DatabaseMotion.Models;
using DatabaseMotion.Services.EFServices;

namespace TestsLeg.DatabaseMotion.Services
{
    public class HotelServiceTests
    {
        [Fact]
        //naming is like this CLassName_MethodName_WhatWeWantToHappen
        public void HotelService_GetHotels_ReturnListofHotels() {
            //Arrange
            // -------------lav en fake database
            // Vi laver af type interface fordi:
            //Moq genrerer en ny klasse som der implemeterer interfacet, det kan den godt finde ud af.
            // Hvis vi brugte HotelRepository direkte ville moq kører den rigtige kode som rammer databasen
            // hvilket vi slet ikke ønsker
            Mock<IHotelRepository> mockRepository = new Mock<IHotelRepository>();

            List<Hotel> forventetListe = new List<Hotel>
            {
                new Hotel {Name = "Grand Hotel"},
                new Hotel {Name = "Seaside inn"}

            };

            // --------fortæl den hvad den skal returnere-------------
            // Vi fortæller mock'en: "Når GetAll() bliver kaldt, returner vores forventetListe"
            // Uden Setup ville mock'en returnere null, fordi den er en tom fake der ikke ved hvad den skal gøre
            mockRepository.Setup(repo => repo.GetAll()).Returns(forventetListe);

            //----------hent den faktiske fake instans og giv services den fake database--------------
            // Vi opretter en rigtig HotelService, men giver den vores FAKE repository
            // .Object = den faktiske fake instans som Moq har genereret der implementerer IHotelRepository
            // VI narrer Hotelservice til at tro den får den rigtige IHotelService selvom den er fake
            HotelService hotelService = new HotelService(mockRepository.Object); 

            //Act
            IEnumerable<Hotel> result = hotelService.GetHotels();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(2,result.Count());


        }
    }
}
