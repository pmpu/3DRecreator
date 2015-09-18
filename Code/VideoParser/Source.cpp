#include "opencv2\opencv.hpp"
#include "opencv2\imgproc\imgproc.hpp"
#include <stdio.h>

int main(int argc, char* argv[]) {

	cv::VideoCapture cap(argv[1]);

	int count = 0;
	if (cap.isOpened()) {
		cv::Mat frame;
		while (cap.read(frame)) {
			count++;
			char* tmp = new char[];
			sprintf(tmp, "Out/img%d.jpg", count);
			cv::imwrite(tmp, frame);
		}
	}

	return 0;
}