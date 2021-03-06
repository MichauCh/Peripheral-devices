#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
#include <Winsock2.h>
#include <Ws2bth.h>
#include <BluetoothAPIs.h>

#pragma comment(lib, "Ws2_32.lib")
#pragma comment(lib, "Bthprops.lib")

// struktura z parametrami wyszukiwania adaptera BT
BLUETOOTH_FIND_RADIO_PARAMS bt_find_radio_params = { sizeof(BLUETOOTH_FIND_RADIO_PARAMS) };
// struktura z parametrami adaptera BT
BLUETOOTH_RADIO_INFO bt_radio_info = { sizeof(BLUETOOTH_RADIO_INFO), 0, };

// struktura z parametrami wyszukiwania urzadzen BT
BLUETOOTH_DEVICE_SEARCH_PARAMS bt_dev_search_params = {
	sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS),
	1,
	0,
	1,
	1,
	1,
	20,
	NULL
};

const int MAX_BT_RADIOS = 10;
// tablica uchwytow przechowujaca znalezione adaptery BT
HANDLE radios[MAX_BT_RADIOS];
// uchwyt przechowujacy pierwszy znaleziony adapter BT
HBLUETOOTH_RADIO_FIND bt_radio_find;
// zmienna przechowujaca ilosc znalezionych adapterów
int bt_radio_id = 0;


const int MAX_BT_DEV = 10;
BLUETOOTH_DEVICE_INFO devices[MAX_BT_DEV];
HBLUETOOTH_DEVICE_FIND bt_dev_find;
int bt_dev_id = 0;

int main()
{
	// wyszukiwanie pierwszego adaptera BT
	bt_radio_find = BluetoothFindFirstRadio(&bt_find_radio_params, &radios[bt_radio_id]);
	bt_radio_id++;
	if (bt_radio_find == NULL) printf("Nie znaleziono zadnego adaptera Bluetooth! Kod bledu: %d\n", GetLastError());
	// wyszukiwanie kolejnych adapterów BT
	else while (BluetoothFindNextRadio(bt_radio_find, &radios[bt_radio_id])) {
		bt_radio_id++;
		if (bt_radio_id == MAX_BT_RADIOS - 1) {
			bt_radio_id--;
			printf("Znaleziono wiecej niz 10 adapterow Bluetooth!");
			break;
		}
	}

	for (int i = 0; i < bt_radio_id; i++) {
		// pobieranie informacji o danym adapterze i umieszczanie ich w strukturze przechowujacej te dane
		BluetoothGetRadioInfo(radios[i], &bt_radio_info);
		// drukowanie informacji o wyrabym adapterze ze struktury
		wprintf(L"\nUrzadzenie: %d", i);
		wprintf(L"\n\t Nazwa: %s", bt_radio_info.szName);
		wprintf(L"\n\t Adres MAC: %02X:%02X:%02X:%02X:%02X:%02X", bt_radio_info.address.rgBytes[0],
			bt_radio_info.address.rgBytes[1], bt_radio_info.address.rgBytes[2], bt_radio_info.address.rgBytes[3],
			bt_radio_info.address.rgBytes[4], bt_radio_info.address.rgBytes[5]);
		wprintf(L"\n\t Klasa: 0x%08x", bt_radio_info.ulClassofDevice);
		wprintf(L"\n\t Producent: 0x%04x\n", bt_radio_info.manufacturer);
	}

	if (!BluetoothFindRadioClose(bt_radio_find)) printf("Blad zamykania wyszukiwania adapterow BT.");

	int choose_radio = 0;
	printf("\nWybierz adapter: ");
	scanf_s("%d", &choose_radio);
	printf("\nWybrano %d adapter.\n", choose_radio);

	printf("\nWyszukiwanie urzadzen...\n");
	// ustawianie adaptera dla danych parametrow wyszukiwania urzadzen BT
	bt_dev_search_params.hRadio = radios[choose_radio];

	devices[0].dwSize = sizeof(BLUETOOTH_DEVICE_INFO);
	bt_dev_find = BluetoothFindFirstDevice(&bt_dev_search_params, &devices[0]);

	if (bt_dev_find == NULL) {
		printf("\nNie znaleziono zadnych urzadzen Bluetooth!");
		BluetoothFindDeviceClose(bt_dev_find);
		return 0;
	}
	else {
		bt_dev_id++;
		devices[bt_dev_id].dwSize = sizeof(BLUETOOTH_DEVICE_INFO);
		while (BluetoothFindNextDevice(bt_dev_find, &devices[bt_dev_id])) {
			bt_dev_id++;
			devices[bt_dev_id].dwSize = sizeof(BLUETOOTH_DEVICE_INFO);
		}
		if (BluetoothFindDeviceClose(bt_dev_find)) printf("\nKoniec wyszukiwania urzadzen.");
		else printf("\nBlad konca wyszukiwania urzadzen.");
	}

	printf("\nZnaleziono %d urzadzen.", bt_dev_id);
	
	for (int i = 0; i < bt_dev_id; i++) {
		wprintf(L"\nUrzadzenie: %d", i);
		wprintf(L"\n\t Nazwa: %s", devices[i].szName);
		wprintf(L"\n\t Adres MAC: %02X:%02X:%02X:%02X:%02X:%02X", devices[i].Address.rgBytes[0],
			devices[i].Address.rgBytes[1], devices[i].Address.rgBytes[2], devices[i].Address.rgBytes[3],
			devices[i].Address.rgBytes[4], devices[i].Address.rgBytes[5]);
		wprintf(L"\n\t Klasa: 0x%08x", devices[i].ulClassofDevice);
		wprintf(L"  \Polaczone: %s\r\n", devices[i].fConnected ? L"true" : L"false");
		wprintf(L"  \tUwierzytelnione: %s\r\n", devices[i].fAuthenticated ? L"true" : L"false");
		wprintf(L"  \tZapamietane: %s\r\n", devices[i].fRemembered ? L"true" : L"false");
	}

	int choose_dev = 0;
	printf("\nWybierz urzadzenie: ");
	scanf_s("%d", &choose_dev);
	printf("\nWybrano %d urzadzenie.\n", choose_dev);

	// autentykacja polaczenia miedzy wybranym adapterem z wybranym urzadzeniem BT
	if (radios[choose_radio] != NULL && !devices[choose_dev].fAuthenticated) 
		BluetoothAuthenticateDeviceEx(NULL, radios[choose_radio], &devices[choose_dev], NULL, MITMProtectionRequired);

	// czesc odpowiedzialna za otwarcie gniazda i nawiazanie polaczenia
	WSADATA wsaData;
	int sck;
	SOCKADDR_BTH sckadr;
	int result = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (result != NO_ERROR) {
		printf("Blad funkcji WSAStartup!");
		return 0;
	}
	// ustawianie gniazda
	sck = socket(AF_BTH, SOCK_STREAM, BTHPROTO_RFCOMM);
	if (sck == INVALID_SOCKET) {
		printf("Blad tworzenia gniazda!");
		return 0;
	}
	else
	{
		sckadr.addressFamily = AF_BTH;
		sckadr.btAddr = devices[choose_dev].Address.ullLong;
		sckadr.port = BT_PORT_ANY;
		sckadr.serviceClassId = OBEXObjectPushServiceClass_UUID;
		// zestawianie polaczenia
		if (connect(sck, (SOCKADDR *) &sckadr, sizeof(sckadr))) {
			printf("Blad polaczenia!");
			closesocket(sck);
			WSACleanup();
			return 0;
		}
		printf("Poprawnie polaczono z urzadzeniem nr: %d", choose_dev);

		closesocket(sck);
		WSACleanup();
	}

	// czyszczenie strummienia stdin
	fseek(stdin, 0, SEEK_END);
	getchar();
	return 0;
}