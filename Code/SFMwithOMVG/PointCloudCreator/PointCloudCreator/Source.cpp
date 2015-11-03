//#include <openMVG/sfm/sfm.hpp>
#include <openMVG/image/image.hpp>

#include <string>
#include <iostream>

using namespace openMVG;
using namespace image;
using namespace std;

int main ()
{
	Image<RGBAColor> img1;
	int k = ReadImage("img1.jpg", Jpg);
	return 0;
}
