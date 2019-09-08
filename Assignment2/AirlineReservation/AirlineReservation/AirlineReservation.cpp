// AirlineReservation.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include"Database.h"
#include"Flight.h"
#include"User.h"

using namespace std;
using namespace AirlineRSystem;

int displaymenu();
void reserveseat(Database& db);
void FlightSchedule(Database& db);
void showPassengerInfo(Database& db);
void flightdetails(Database& db);
void Userticketinfo(Database& db);
Flight& selectFlight(Database& db);

int main()

{
	Database mdb;
	
	Flight f1("Seattle", "Boston", 1, 60);
	Flight f2("NewYork", "Miami", 2, 45);
	Flight f3("SFO", "Chicago", 3, 45);



	int selection = displaymenu();
	while (true)
	{
		switch (selection)
		{
		case 0:
			return 0;
		case 1:
			reserveseat();
		case 2:
			FlightSchedule(airlinedb);
		case 3:
			showPassengerInfo(airlinedb);
		case 4:
			flightdetails(airlinedb);
		case 5:
			Userticketinfo(airlinedb);
		default:
			cerr << "unknown command..break" << endl;
		}
	}

	return 0;

}

int displaymenu()
{
	int selection;

	cout << endl;
	cout << "Flight Database" << endl;
	cout << "1) Reserve a seat" << endl;
	cout << "2) Flight schedule" << endl;
	cout << "3) Pasenger info" << endl;
	cout << "4) Flight details" << endl;
	cout << "5) User ticket info" << endl;
	cout << "0) Quit" << endl;
	cout << endl;


	cin >> selection;

	return selection;
}


void FlightSchedule(Database &db)
{
	vector<Flight>& allflights = db.getallFlights();
	for (Flight& f : allflights)
	{
		f.display();
	}

}

Flight& selectFlight(Database& db)
{
	int flightid;
	cout << "Enter flight id" << endl;
	FlightSchedule(db);
	cin >> flightid;
	Flight& flight = db.getFlight(flightid);
	return flight;
}


User& getuserdata() {
	string firstName;
	string lastName;
	int userid;
	cout << "Your First name? ";
	cin >> firstName;
	cout << "Last name? ";
	cin >> lastName;
	cout << "Your Id number? ";
	cin >> userid;

	User* user = new User(firstName, lastName, userid);
	return *user;
}



void reserveseat(Database& db)
{
	int chosenseat;
	Flight& flight = selectFlight(db);
	vector<int>& freeseats = flight.getfreeseats();
	for (int seat : freeseats)
	{
		cout << seat << endl;
	}
	cout << "reserve a seat";
	cin >> chosenseat;

	User& user = getuserdata();
	user.setseatno(chosenseat);
	flight.reserveseat(user);

}

void showPassengerInfo(Database& db)
{
	Flight& flight = selectFlight(db);
	vector<User>& users = flight.gettravellers();
	for (User& user : users)
	{
		cout << "get first name" << user.getFirstName() << endl;
		cout << "get last name" << user.getLastName() << endl;
		cout << "get seat no" << user.getseatno() << endl;
		cout << "get flight no" << user.getidno() << endl;
		cout << "enter departure city" << flight.Getdeparturecity() << endl;
		cout << "enter destination city" << flight.Getdestinationcity() << endl;

		cout << endl;
	}

}

void Userticketinfo(Database &db)
{
	int userid;
	Flight& flight = selectFlight(db);
	vector<User>& users = flight.gettravellers();

	bool userfound = false;
	for (User& user : users)
	{
		if (userid = user.getidno())
		{
			userfound = true;
			cout << "get first name" << user.getFirstName() << endl;
			cout << "get last name" << user.getLastName() << endl;
			cout << "get seat no" << user.getseatno() << endl;
			cout << "get flight no" << user.getidno() << endl;
			cout << "enter departure city" << flight.Getdeparturecity() << endl;
			cout << "enter destination city" << flight.Getdestinationcity() << endl;

			cout << endl;
		}

		else
			cout << "no passenger found" << endl;

	}

}


void flightdetails(Database &db)
{
	Flight& flight = selectFlight(db);
	vector<int>& freeseats = flight.getfreeseats();
	vector<User>& freepassengers = flight.gettravellers();
	cout << "Free seats" << freeseats.size() << endl;
	cout << "Remaining travelers" << freepassengers.size() << endl;


}
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File 


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
