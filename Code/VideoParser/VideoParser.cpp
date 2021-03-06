#include "opencv2\opencv.hpp"
#include "opencv2\imgproc.hpp"
#include "VideoParser.h"

extern "C" {
	namespace VideoParser{
		bool VideoParser::videoParser(char* sourceDirectory, char* outDirectory) {
			cv::VideoCapture cap(sourceDirectory);

			int count = 0;
			if (cap.isOpened()) {
				cv::Mat frame;
				while (cap.read(frame)) {
					count++;
					char* tmp = new char[];
					sprintf(tmp, "%s/img%d.jpg", outDirectory, count);
					cv::imwrite(tmp, frame);
				}
			}
			else {
				std::cout << "File is not opened";
				return false;
			}
			return true;
		}
	}
}


