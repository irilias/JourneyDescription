using JourneyDescription.Tests.Integration_Testing.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JourneyDescription.Tests.Integration_Testing
{

    public class BoardingCardsControllerTests
    {
        #region "POST_sorts_boarding_cards_return_OK"
        [Test]
        public async Task POST_sorts_boarding_cards()
        {
            var api= new ApiWebApplicationFactory();

            var content = GetContent();
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await api.CreateClient().PostAsync("/api/BoardingCards", stringContent);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        private static string GetContent()
        {
            var model = new List<BoardingPass>()
            {
                new BoardingPass() {TransporationId= "SK22"
                ,TransporationType="flight"
                ,StartingPoint="Stockholm"
                ,DestinationPoint="New York JFK"
                ,SeatNumber="7B"
                ,BagageInfo="Baggage will we automatically transferred from your last leg"
                ,GateNumber="22"
                },
                  new BoardingPass() {
                TransporationType="bus"
                ,StartingPoint="Barcelona"
                ,DestinationPoint="Gerona"
                },
                    new BoardingPass() {TransporationId= "SK455"
                ,TransporationType="flight"
                ,StartingPoint="Gerona"
                ,DestinationPoint="Stockholm"
                ,SeatNumber="3A"
                ,BagageInfo="Baggage drop at ticket counter 344"
                ,GateNumber="45B"
                },
                      new BoardingPass() {TransporationId= "78A"
                ,TransporationType="train"
                ,StartingPoint="Madrid"
                ,DestinationPoint="Barcelona"
                ,SeatNumber="45B"
                }
            };
            return JsonConvert.SerializeObject(model);
        }

        #endregion "POST_sorts_boarding_cards"

        #region "POST_sorts_boarding_cards_returns_bad_request"
        // TODO 
        #endregion "POST_sorts_boarding_cards"

        #region "POST_sorts_boarding_cards_returns_internal_server_error"
        // TODO 
        #endregion "POST_sorts_boarding_cards_returns_internal_server_error"
    }
}
