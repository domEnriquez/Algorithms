
#include "stdafx.h"
#include <boost/test/unit_test.hpp>
#include "BirthdayChocolate.h"

using namespace HackerRank;

BirthdayChocolate* bc;

void assertCountPartitions(vector<int> s, int day, int month, int expectedCount) {
	BOOST_TEST(expectedCount == bc->CountPossiblePartitions(s, day, month));
}

BOOST_AUTO_TEST_SUITE(BirthdayChocolateTests)

BOOST_AUTO_TEST_CASE(GivenReqdInputs_WhenCountPossiblePartitions_ThenReturnPartitionsCount) {
	bc = new BirthdayChocolate;

	assertCountPartitions({ 1 }, 1, 1, 1);
	assertCountPartitions({ 1 }, 2, 1, 0);
	assertCountPartitions({ 2 }, 2, 1, 1);
	assertCountPartitions({ 1 }, 1, 2, 0);
	assertCountPartitions({ 1, 1 }, 1, 1, 2);
	assertCountPartitions({ 1, 1 }, 1, 3, 0);
	assertCountPartitions({ 1, 1 }, 2, 1, 0);
	assertCountPartitions({ 1, 1 }, 2, 2, 1);
	assertCountPartitions({ 1, 2, 1, 3, 2 }, 3, 2, 2);
	assertCountPartitions({ 1, 1, 1, 1, 1, 1 }, 3, 2, 0);
	assertCountPartitions({ 4, 1 }, 4, 1, 1);
}

BOOST_AUTO_TEST_SUITE_END()