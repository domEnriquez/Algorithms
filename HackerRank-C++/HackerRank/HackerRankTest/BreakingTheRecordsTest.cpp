// HackerRankTest.cpp : Defines the entry point for the console application.
//
#define BOOST_TEST_MODULE HackerRankTest
#include "stdafx.h"
#include <boost/test/unit_test.hpp>
#include <vector>
#include "BreakingTheRecords.h"

using namespace HackerRank;
using namespace std;

BreakingTheRecords * br;

struct Fixture {
	Fixture() {
		br = new BreakingTheRecords;
	}
	~Fixture() {
		delete br;
	}

	vector<int> scores;
};

void assertMaxBreakRecords(vector<int> scores, int expectedCount) {
	BOOST_TEST(expectedCount == br->CountMaxBreakRecord(scores));
}

void assertMinBreakRecords(vector<int> scores, int expectedCount) {
	BOOST_TEST(expectedCount == br->CountMinBreakRecord(scores));
}

BOOST_FIXTURE_TEST_SUITE(BreakingTheRecordsTests, Fixture)

BOOST_AUTO_TEST_CASE(GivenMultipleScores_WhenCountMaxBreakRecord_ThenReturnMaxBreakRecordCount) {
	assertMaxBreakRecords({ }, 0);
	assertMaxBreakRecords({ 1 }, 0);
	assertMaxBreakRecords({ 1, 1 }, 0);
	assertMaxBreakRecords({ 1, 2 }, 1);
	assertMaxBreakRecords({ 1, 2, 3 }, 2);
	assertMaxBreakRecords({ 1, 2, 2, 3 }, 2);
	assertMaxBreakRecords({ 10, 5, 20, 20, 4, 5, 2, 25,1 }, 2);
	assertMaxBreakRecords({ 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 }, 4);
}

BOOST_AUTO_TEST_CASE(GivenMultipleScores_WhenCountMinBreakRecord_ThenReturnMinBreakRecordCount) {
	assertMinBreakRecords({ }, 0);
	assertMinBreakRecords({ 1 }, 0);
	assertMinBreakRecords({ 1 , 1 }, 0);
	assertMinBreakRecords({ 2, 1 }, 1);
	assertMinBreakRecords({ 3, 2, 1 }, 2);
	assertMinBreakRecords({ 3, 2, 2, 1 }, 2);
	assertMinBreakRecords({ 10, 5, 20, 20, 4, 5, 2, 25,1 }, 4);
	assertMinBreakRecords({ 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 }, 0);
}

BOOST_AUTO_TEST_SUITE_END()

