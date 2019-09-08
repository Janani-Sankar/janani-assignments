#include "stdafx.h"
#include <iostream>
#include <stdexcept>
#include "Database.h"
#include"pch.h"
#include "Flight.h"

using namespace std;

namespace AirlineRSystem
{
	void Database::addFlight(Flight& flight)
	{
		mflights.push_back(flight);
	}

	Flight& Database::getFlight(int flightno)
	{
		for (auto& flight : mflights) {
			if (flight.Getflightno() == flightno) {
				return flight;
			}

		}
		throw logic_error("This flight number doesn't exist, please check your records.");
	}
	vector<Flight>& Database::getallFlights()
	{
		return mflights;
	}
}
