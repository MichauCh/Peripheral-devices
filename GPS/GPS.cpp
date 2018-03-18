#include <iostream>
#include <windows.h>
#include <sstream>
#include "Serial.h" // zew. biblioteka do obs³ugi portow szeregowych
#include "stdafx.h"
#include <tchar.h>

using namespace std;

#define RX_BUFFSIZE 300 // rozmiar bufora przechowujacego dane odebrane od urzadzenia
string doubleToString(double i);
void printChars(char* c, int len, string message);


int _tmain(int argc, _TCHAR* argv[])
{
	try {
		// pobiranie informacji o porcie
		cout << "Enter the COM port of the GPS device [ex. COM7]: ";
		string port;
		cin >> port;
		cout << "Opening the " + port + " port..." << endl;
		port += ":";
		TCHAR *portCom = new TCHAR[port.size() + 1];
		portCom[port.size()] = 0;
		copy(port.begin(), port.end(), portCom);
		// ustawianie portu
		tstring commPortName(portCom);
		// nawiazywanie polaczenia szeregowego na danym porcie z pomoca zew. biblioteki
		Serial serial(commPortName);
		cout << "The port has been opened!" << endl;

		char tablica[RX_BUFFSIZE]; // bufor przechowujacy dane z GPSa
		char time[6], latitude[9], longitude[9], satellites[2]; // zmienne przechowujace wy³uskane dane z sekwencji NMEA

		// odczyt danych z GPSa
		int b = -1;
		int charsRead;
		do {
			b++;
			charsRead = NULL;
			for (int k = 0; k < 100; k++) tablica[k] = NULL;
			charsRead = serial.read(tablica, RX_BUFFSIZE);
			Sleep(1000);
		} while (b < 10);

		cout << endl;

		// szuka sekwencji $GPGGA - Global Positioning System Fix Data i pobiera z niej dane
		for (int i = 0; i < 100; i++) {

			if (tablica[i] == 'G' && tablica[i + 1] == 'G' && tablica[i + 2] == 'A')
			{

				i += 4;
				for (int j = 0; j < sizeof(time); j++) time[j] = tablica[i++];
				printChars(time, sizeof(time), "\nTime");
				i += 1;

				for (int j = 0; j < sizeof(latitude); j++) latitude[j] = tablica[i++];
				latitude[sizeof(latitude) - 1] = tablica[i];
				printChars(latitude, sizeof(latitude), "Latitude");
				i += 3;

				for (int j = 0; j < sizeof(longitude); j++) longitude[j] = tablica[i++];
				longitude[sizeof(longitude) - 1] = tablica[i];
				printChars(longitude, sizeof(longitude), "Longitude");
				i += 4;
				
				for (int j = 0; j < sizeof(satellites); j++) satellites[j] = tablica[i++];
				printChars(satellites, sizeof(satellites), "Number of satellites");

				break;
			}
		}

		// obliczanie wspó³rzêdnych do Google Maps
		double szer = atof(latitude);
		double dlug = atof(longitude);
		int szermin = atoi(latitude);
		int dlugmin = atoi(longitude);
		int szera = szermin;
		int dluga = dlugmin;
		szermin %= 100;
		szera /= 100;
		dlugmin %= 100;
		dluga /= 100;

		string google = "https://www.google.pl/maps/@";					
		double testszer = (((szer - (int)szer) + szermin) / 60) + szera;
		google += doubleToString(testszer);
		google += ",";
		double testdlug = (((dlug - (int)dlug) + dlugmin) / 60) + dluga;
		google += doubleToString(testdlug);
		google += ",16z";

		cout << "\nGoogle Maps: " << google << endl << endl;


	} catch(const char *error) {
		cout << error << endl;
	}

	fseek(stdin, 0, SEEK_END);
	getchar();

	return 0;
}

string doubleToString(double i)
{
	stringstream ss;
	string temp;
	ss << i;
	ss >> temp;
	return temp;
}

void printChars(char* c, int len, string message) {
	cout << message << ": ";
	for (int k = 0; k < len; k++) {
		cout << c[k];
	}
	cout << endl;
}