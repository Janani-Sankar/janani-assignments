#pragma once
#include<string>

#pragma once
namespace AirlineRSystem
{
	class User
	{
	public:

		User(const std::string& firstName,
			const std::string& lastName, int idno);

		//Getters and setters
		void setFirstName(const std::string& firstName);
		const std::string& getFirstName() const;

		void setLastName(const std::string& lastName);
		const std::string& getLastName() const;

		void setseatno(int seatno);
		int getseatno() const;
		int getidno() const;



	private:
		std::string mFirstName;
		std::string mLastName;
		int midno = -1;
		int mseatno = -1;


	};
}

