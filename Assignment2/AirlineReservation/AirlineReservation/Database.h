#pragma once
#include"Flight.h"
#include"pch.h"
#include<vector>
#include<iostream>


namespace AirlineRSystem
{
	class Database
	{
	public:

		void addFlight(Flight& flight);
		Flight& getFlight(int flightno);
		std::vector<Flight>& getallFlights();

	private:
		std::vector<Flight>& mflights;


	};
}