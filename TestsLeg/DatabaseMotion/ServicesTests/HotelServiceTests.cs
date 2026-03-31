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
using DatabaseMotion.Services.IServices;
using FluentAssertions;

namespace TestsLeg.DatabaseMotion.Services
{
    public class HotelServiceTests
    {
        //TODO: test fixture 
        private readonly Mock<IHotelRepository> _mockRepository;
        private readonly HotelService _hotelService;
        private readonly InsertHotelService _insertHotelService;

        // Konstruktøren kører før hver test 
        public HotelServiceTests() {
            // -------------lav en fake database
            // Vi laver af type interface fordi:
            //Moq genrerer en ny klasse som der implemeterer interfacet, det kan den godt finde ud af.
            // Hvis vi brugte HotelRepository direkte ville moq kører den rigtige kode som rammer databasen
            // hvilket vi slet ikke ønsker
            _mockRepository = new Mock<IHotelRepository>();
            //----------hent den faktiske fake instans og giv services den fake database--------------
            // Vi opretter en rigtig HotelService, men giver den vores FAKE repository
            // .Object = den faktiske fake instans som Moq har genereret der implementerer IHotelRepository
            // VI narrer Hotelservice til at tro den får den rigtige IHotelService selvom den er fake
            _hotelService = new HotelService(_mockRepository.Object);
            _insertHotelService = new InsertHotelService(_mockRepository.Object);
        }

        [Fact]
        public void HotelsService_GetHotels_ReturnEmptyList() {
            //Arrange
            List<Hotel> emptyHotelList = new List<Hotel>();

            _mockRepository.Setup(repo => repo.GetAll()).Returns(emptyHotelList);
            //Act
            IEnumerable<Hotel> result = _hotelService.GetHotels();
            //Assert
            result.Should().NotBeNull(); // altid null exceptions først fordi empty skal ikke kalde null exceptions
            result.Should().BeEmpty();

        }

        [Fact]
        //naming is like this CLassName_MethodName_WhatWeWantToHappen
        public void HotelService_GetHotels_ReturnListofHotels() {
            //Arrange

            List<Hotel> forventetListe = new List<Hotel>
            {
                new Hotel {Name = "Grand Hotel"},
                new Hotel {Name = "Seaside inn"}

            };
            // --------fortæl den hvad den skal returnere-------------
            // Vi fortæller mock'en: "Når GetAll() bliver kaldt, returner vores forventetListe"
            // Uden Setup ville mock'en returnere null, fordi den er en tom fake der ikke ved hvad den skal gøre
            _mockRepository.Setup(repo => repo.GetAll()).Returns(forventetListe);

            //Act
            IEnumerable<Hotel> result = _hotelService.GetHotels();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void HotelService_InsertHotel_ReturnHotel() {
            //Arrange

            // lav et nyt hotel
            Hotel newHotel = new Hotel() { Name = "Fake Hostel" };

            // den er dum og skal fortælle hvad den skal retunerer når den bliver kaldt
            _mockRepository.Setup(repo => repo.NewHotel(newHotel)).Returns(newHotel);
            //Act
            Hotel result = _insertHotelService.NewHotel(newHotel);

            //Assert

            //xUnit
            Assert.NotNull(result);
            Assert.Equal("Fake Hostel", result.Name);

            //FluentAssertions
            result.Should().NotBeNull();
            result.Name.Should().Be(newHotel.Name);

        }
    }
}
