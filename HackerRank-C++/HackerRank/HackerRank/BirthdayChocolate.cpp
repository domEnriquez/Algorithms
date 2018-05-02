#include "BirthdayChocolate.h"

using namespace HackerRank;

int BirthdayChocolate::CountPossiblePartitions(vector<int> s, int day, int month)
{
	int barSize = s.size();

	if (barSize < month)
		return 0;

	int count = 0;	

	for (int i = 0; i < barSize; i++) {
		int sum = 0;

		for (int j = i; j <= month - 1 + i && j < barSize; j++) {
			sum += s[j];
		}
		
		if (sum == day)
			count++;
	}

	return count;
}
