#include "DetectAndCoutnSamePoints.h"
#include <string>
#include <iostream>
// calib
using namespace std;

int main()
{
	String fileName0;
	String fileName1;
	int *keyCount = new int[2];
	int frameCount = 10;
	for (int i = 1; i < frameCount; i++)
	{
		fileName0 += "Out1/img";
		fileName0 += to_string(i);
		fileName0 += ".jpg";

		fileName1 += "Out1/img";
		fileName1 += to_string(i+1);
		fileName1 += ".jpg";

		Mat img1 = imread(fileName0, IMREAD_UNCHANGED);
		Mat img2 = imread(fileName1, IMREAD_UNCHANGED);

		DetectSame(i, img1, img2, "AKAZE-DESCRIPTOR_KAZE_UPRIGHT", "BruteForce", keyCount); //TODO: Find th best algo
		// TODO: Find algo to ignore frames 
		fileName0 = "";
		fileName1 = "";
	}
	cout << keyCount[0] << " " << keyCount[1];
	// TODO: add calibration

	return 0;
}