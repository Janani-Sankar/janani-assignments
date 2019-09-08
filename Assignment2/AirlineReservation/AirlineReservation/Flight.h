#pragma once
#include<string>
#include<vector>
#include"User.h"
#include<stdio.h>
#include"pch.h"

namespace AirlineRSystem
{
	class Flight
	{
	public:
		Flight() = default;
		Flight(const std::string& departurecity, const std::string& destinationcity, int flightno, int totalseats);

		const std::string& Getdeparturecity() const;
		const std::string& Getdestinationcity() const;

		int Getflightno() const;

		std::vector<int>& getfreeseats();
		void reserveseat(User& user);

		std::vector<User>& gettravellers();
		void display() const;


	private:
		std::string mdeparturecity;
		std::string mdestinationcity;
		std::vector<int> mfreeseats;
		std::vector<User> mtravellers;
		int mflightno = -1;

	};
}