/*
Modified opencv sample matchmethod_orb_akaze_brisks
*/

#include <opencv2/opencv.hpp>
#include <vector>
#include <iostream>

using namespace std;
using namespace cv;

void DetectSame(int imgCounter, Mat img1, Mat img2, String descType, String AlgoMatch, int *keyCount)
{
	if (img1.rows*img1.cols <= 0)
	{
		cout << "First image is empty or cannot be found\n";
		return;
	}
	if (img2.rows*img2.cols <= 0)
	{
		cout << "Second image is empty or cannot be found\n";
		return;
	}

	vector<double> desMethCmp;
	Ptr<Feature2D> b;
	
	// Match between img1 and img2
	vector<DMatch> matches;
	Ptr<DescriptorMatcher> descriptorMatcher;
	// keypoint  for img1 and img2
	vector<KeyPoint> keyImg1, keyImg2;
	int keyCount2, keyCount1;

	// Descriptor for img1 and img2
	Mat descImg1, descImg2;
	//vector<String>::iterator itMatcher = typeAlgoMatch.end();
	if (descType == "AKAZE-DESCRIPTOR_KAZE_UPRIGHT"){
		b = AKAZE::create(AKAZE::DESCRIPTOR_KAZE_UPRIGHT);
	}
	if (descType == "AKAZE"){
		b = AKAZE::create();
	}
	if (descType == "ORB"){
		b = ORB::create();
	}
	else if (descType == "BRISK"){
		b = BRISK::create();
	}
	try
	{
		// We can detect keypoint with detect method
		b->detect(img1, keyImg1, Mat());
		// and compute their descriptors with method  compute
		b->compute(img1, keyImg1, descImg1);
		// or detect and compute descriptors in one step
		b->detectAndCompute(img2, Mat(), keyImg2, descImg2, false);
	
		descriptorMatcher = DescriptorMatcher::create(AlgoMatch);
		if ((AlgoMatch == "BruteForce-Hamming" || AlgoMatch == "BruteForce-Hamming(2)") && (b->descriptorType() == CV_32F || b->defaultNorm() <= NORM_L2SQR))
			{
				cout << "**************************************************************************\n";
				cout << "It's strange. You should use Hamming distance only for a binary descriptor\n";
				cout << "**************************************************************************\n";
			}
		if ((AlgoMatch == "BruteForce" || AlgoMatch == "BruteForce-L1") && (b->defaultNorm() >= NORM_HAMMING))
			{
				cout << "**************************************************************************\n";
				cout << "It's strange. You shouldn't use L1 or L2 distance for a binary descriptor\n";
				cout << "**************************************************************************\n";
			}
			try
			{
				
				descriptorMatcher->match(descImg1, descImg2, matches, Mat());
				// Keep best matches only to have a nice drawing.
				// We sort distance between descriptor matches
				Mat index;
				int nbMatch = int(matches.size());
				Mat tab(nbMatch, 1, CV_32F);
				for (int i = 0; i < nbMatch; i++)
				{
					tab.at<float>(i, 0) = matches[i].distance;
				}
				sortIdx(tab, index, SORT_EVERY_COLUMN + SORT_ASCENDING);
				vector<DMatch> bestMatches;
				for (int i = 0; i < 30; i++)
				{
					bestMatches.push_back(matches[index.at<int>(i, 0)]);
				}

				Mat result;
				drawMatches(img1, keyImg1, img2, keyImg2, bestMatches, result);
				//namedWindow(descType + ": " + AlgoMatch, WINDOW_AUTOSIZE);
				//imshow(descType + ": " + AlgoMatch, result);
				string str = "img";
				str += to_string(imgCounter);
				str += ".jpg";
				imwrite(str, result);
				//cvSaveImage("img.jpg", result);
				// Saved result could be wrong due to bug 4308
				FileStorage fs(descType + "_" + AlgoMatch + ".yml", FileStorage::WRITE);
				fs << "Matches" << matches;
				vector<DMatch>::iterator it;
				cout << "**********Match results**********\n";
				cout << "Index \tIndex \tdistance\n";
				cout << "in img1\tin img2\n";

				// Use to compute distance between keyPoint matches and to evaluate match algorithm
				double cumSumDist2 = 0;
				for (it = bestMatches.begin(); it != bestMatches.end(); it++)
				{
					cout << it->queryIdx << "\t" << it->trainIdx << "\t" << it->distance << "\n";
					Point2d p = keyImg1[it->queryIdx].pt - keyImg2[it->trainIdx].pt;
					cumSumDist2 = p.x*p.x + p.y*p.y;
				}
				keyCount2 = keyImg2.size();
				keyCount1 = keyImg1.size();
				keyCount[0] = keyCount1;
				keyCount[1] = keyCount2;
				desMethCmp.push_back(cumSumDist2);
				waitKey();
			}
			catch (Exception& e)
			{
				cout << e.msg << endl;
				cout << "Cumulative distance cannot be computed." << endl;
				desMethCmp.push_back(-1);
			}
	}
	catch (Exception& e)
	{
		cout << "Feature : " << descType << "\n";
		cout << e.msg << endl;
	}

}

