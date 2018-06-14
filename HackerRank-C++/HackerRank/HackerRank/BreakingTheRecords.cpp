#include "BreakingTheRecords.h"

using namespace HackerRank;

int BreakingTheRecords::CountMaxBreakRecord(vector<int> scores)
{
	int size = scores.size();

	if(size == 0 || size == 1)
		return 0;

	int max = scores[0];
	int count = 0;

	for (int i = 1; i < size; i++)
		if (scores[i] > max) {
			max = scores[i];
			count++;
		}

	return count;
}

int BreakingTheRecords::CountMinBreakRecord(vector<int> scores)
{
	int size = scores.size();

	if (size == 0 || size == 1)
		return 0;

	int min = scores[0];
	int count = 0;

	for (int i = 1; i < size; i++)
		if (scores[i] < min) {
			min = scores[i];
			count++;
		}

	return count;
}
