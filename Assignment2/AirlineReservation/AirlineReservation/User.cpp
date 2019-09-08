#include"User.h"
#include<string>
#include<vector>
#include"pch.h"
#include<stdio.h>
using namespace std;

namespace AirlineRSystem
{
	User::User(const std::string& firstName, const std::string& lastName, int idno)
		: mFirstName(firstName), mLastName(lastName), midno(idno)

	{
		/*mFirstName = firstName;
		mLastName = lastName;*/
	}


	void User::setFirstName(const string& firstName)
	{
		mFirstName = firstName;
	}

	void User::setLastName(const string& lastName)
	{
		mLastName = lastName;
	}
	const string& User::getFirstName() const
	{
		return mFirstName;
	}
	const string& User::getLastName() const
	{
		return mLastName;
	}

	int User::getidno() const
	{
		return midno;
	}

	void User::setseatno(int seatNumber) {
		mseatno = seatNumber;
	}

	int User::getseatno() const {
		return mseatno;
	}
}