#include"User.h"
#include"Flight.h"
#include<iostream>
#include<algorithm>
#include<string>
#include"pch.h"
#include<stdio.h>

using namespace std;

namespace AirlineRSystem
{

	Flight::Flight(const std::string& departurecity, const std::string& destinationcity, int flightno, int totalseats) :
		mdeparturecity(departurecity), mdestinationcity(destinationcity), mflightno(flightno)


	{
		for (int i = 1; i < totalseats; i++)
		{
			mfreeseats.push_back(i);
		}
	}

	const string& Flight::Getdeparturecity() const
	{
		return mdeparturecity;
	}


	const string& Flight::Getdestinationcity() const
	{
		return mdestinationcity;
	}


	int Flight::Getflightno() const
	{
		return mflightno;

	}

	void Flight::reserveseat(User& user)
	{
		mtravellers.push_back(user);
		int seatnumber = user.getseatno;
		mfreeseats.erase(std::remove(mfreeseats.begin(), mfreeseats.end(), seatnumber), mfreeseats.end());
	}

	std::vector<int>& Flight::getfreeseats()
	{
		return mfreeseats;
	}

	std::vector<User>& Flight::gettravellers()
	{
		return mtravellers;
	}

	void Flight::display() const
	{
		cout << Getflightno() << Getdeparturecity() << Getdestinationcity() << endl;

	}
}

