#ifdef VIDEOPARSERDLL_EXPORTS
#define VIDEOPARSERDLL_API __declspec(dllexport) 
#else
#define VIDEOPARSERDLL_API __declspec(dllimport) 
#endif
namespace VideoParser {
	class VideoParser {
	public:static bool videoParser(char* sourceDirectory, char* outDirectory);
	};
}
