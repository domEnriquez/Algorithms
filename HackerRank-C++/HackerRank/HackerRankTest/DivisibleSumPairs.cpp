
#include "stdafx.h"
#include <boost/test/unit_test.hpp>
#include "DivisibleSumPairs.h"

using namespace HackerRank;

BOOST_AUTO_TEST_SUITE(DivisibleSumPairsTest)

BOOST_AUTO_TEST_CASE(CreateDivisibleSumPairsObject) {
	DivisibleSumPairs* dsp = new DivisibleSumPairs;
}

BOOST_AUTO_TEST_CASE(GivenReqdInputs_WhenCountDivisibleSumPairs_ThenReturnCount) {
	DivisibleSumPairs* dsp = new DivisibleSumPairs;
	BOOST_TEST(1 == dsp->CountDivisibleSumPairs({ 1, 1 }, 2));
}

BOOST_AUTO_TEST_SUITE_END()