#include "opencv2\opencv.hpp"
#include "opencv2\imgproc\imgproc.hpp"
#include <stdio.h>
#include "VideoParser.h"

int main(int argc, char* argv[]) {
	VideoParser::VideoParser::videoParser("C:\\videoplayback.mp4", "Out1");
	VideoParser::VideoParser::videoParser("C:\\videoplayback.mp4", "Out2");
	return 0;
}

