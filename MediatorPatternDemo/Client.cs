using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternDemo
{
    public class Client
    {
        static void Main(string[] args)
        {
            //Creating the List of Participants
            IColleague<string> ColleagueA = new ConcreteColleague<string>("ColleagueA");
            IColleague<string> ColleagueB = new ConcreteColleague<string>("ColleagueB");
            IColleague<string> ColleagueC = new ConcreteColleague<string>("ColleagueC");
            IColleague<string> ColleagueD = new ConcreteColleague<string>("ColleagueD");
            IColleague<string> ColleagueE = new ConcreteColleague<string>("ColleagueE");


            //First Mediator
            IMediator<string> mediatorFirst = new ConcreteMediator<string>();

            //Register the Paticipants to Mediator
            mediatorFirst.Register(ColleagueA);
            mediatorFirst.Register(ColleagueB);
            mediatorFirst.Register(ColleagueC);
            mediatorFirst.Register(ColleagueD);
            mediatorFirst.Register(ColleagueE);


            //Paritipant A sending the message to all registered Participants to the FirstMediator
            ColleagueA.SendMessage(mediatorFirst, "Mesage from Participant A");

            //Paritipant D sending the message to all registered Participants to the FirstMediator
            ColleagueD.SendMessage(mediatorFirst, "Mesage from Participant D");


            IColleague<int> ColleagueintD = new ConcreteColleague<int>("ColleagueintD");
            IColleague<int> ColleagueintE = new ConcreteColleague<int>("ColleagueintE");
            IColleague<int> ColleagueintF = new ConcreteColleague<int>("ColleagueintF");


            //Second Mediator
            IMediator<int> mediatorSecond = new ConcreteMediator<int>();

            //Registering the Participants to the Second Mediator
            mediatorSecond.Register(ColleagueintD);
            mediatorSecond.Register(ColleagueintE);
            mediatorSecond.Register(ColleagueintF);

            ColleagueintD.SendMessage(mediatorSecond, 100);


        }
    }
}
