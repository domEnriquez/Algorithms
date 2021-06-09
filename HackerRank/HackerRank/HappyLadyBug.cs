using NUnit.Framework;
using System.Collections.Generic;

namespace HackerRank
{
    [TestFixture]
    public class HappyLadyBug
    {
        [Test]
        public void canDetermineHappyLadyBugs()
        {
            Assert.That(happyLadybugs("_"), Is.EqualTo("YES"), "1");
            Assert.That(happyLadybugs("R"), Is.EqualTo("NO"), "2");
            Assert.That(happyLadybugs("__"), Is.EqualTo("YES"), "3");
            Assert.That(happyLadybugs("RB"), Is.EqualTo("NO"), "4");
            Assert.That(happyLadybugs("RR"), Is.EqualTo("YES"), "5");
            Assert.That(happyLadybugs("RR"), Is.EqualTo("YES"), "6");
            Assert.That(happyLadybugs("RBY"), Is.EqualTo("NO"), "7");
            Assert.That(happyLadybugs("RRR"), Is.EqualTo("YES"), "8");
            Assert.That(happyLadybugs("R_R"), Is.EqualTo("YES"), "9");
            Assert.That(happyLadybugs("R_Y"), Is.EqualTo("NO"), "10");
            Assert.That(happyLadybugs("RY_"), Is.EqualTo("NO"), "11");
            Assert.That(happyLadybugs("RR_"), Is.EqualTo("YES"), "12");
            Assert.That(happyLadybugs("_RR"), Is.EqualTo("YES"), "13");
            Assert.That(happyLadybugs("_R_"), Is.EqualTo("NO"), "14");
            Assert.That(happyLadybugs("RYR_"), Is.EqualTo("NO"), "15");
            Assert.That(happyLadybugs("RR_R"), Is.EqualTo("YES"), "16");
            Assert.That(happyLadybugs("RYRB"), Is.EqualTo("NO"), "17");
            Assert.That(happyLadybugs("_R_R"), Is.EqualTo("YES"), "18");
            Assert.That(happyLadybugs("RRY_YR"), Is.EqualTo("YES"), "19");
            Assert.That(happyLadybugs("RBY_YBR"), Is.EqualTo("YES"), "20");
            Assert.That(happyLadybugs("X_Y__X"), Is.EqualTo("NO"), "21");
            Assert.That(happyLadybugs("B_RRBR"), Is.EqualTo("YES"), "22");
            Assert.That(happyLadybugs("AABBC"), Is.EqualTo("NO"), "23");
            Assert.That(happyLadybugs("AABBC_C"), Is.EqualTo("YES"), "24");
            Assert.That(happyLadybugs("DD__FQ_QQF"), Is.EqualTo("YES"), "25");
            Assert.That(happyLadybugs("AABCBC"), Is.EqualTo("NO"), "26");
            Assert.That(happyLadybugs("RBRB"), Is.EqualTo("NO"), "27");
            Assert.That(happyLadybugs("RRRR"), Is.EqualTo("YES"), "28");
            Assert.That(happyLadybugs("BBB_"), Is.EqualTo("YES"), "29");
            Assert.That(happyLadybugs("_FWYSSENEDBO_KSEVUAB_WZ_GASASVEVS_O_NSVBYFNADE_WWVSBKAE_F_VAS_F_AAAEWBE_WEAEOAYV"), Is.EqualTo("NO"), "30");
            Assert.That(happyLadybugs("ZBF_MIFUXJNQGQRFZVRQUFFFFNGFIBJ_XZVIRFGMJRJFVMNJMF"), Is.EqualTo("YES"), "31");
            Assert.That(happyLadybugs("__XWTZXUWVT__H_PUGHZ_G___H_GZWTTWGZ_XHHZWGXZWGPV_U_UWXV"), Is.EqualTo("YES"), "32");
            Assert.That(happyLadybugs("A_TOJRPRW__JOJP__WAJT"), Is.EqualTo("YES"), "26");
            Assert.That(happyLadybugs("E__TZJTD_OYGFM__QKZD_LJL_TJ_YED__DETFFYGJQ_T_JJZDJFMQO___T_JTQGKDTT_ET"), Is.EqualTo("YES"), "33");
            Assert.That(happyLadybugs("I_S_AHBBZJLQDKQZXIG_TOC_BGQMQVTEWAAWIBL_MKJQQGSZIBWSQQ__K_HEHZZZG_BBCEJOWIGCGQTBQ_Z_DHGAIQ_____LVA_"), Is.EqualTo("NO"), "34");
            Assert.That(happyLadybugs("MZSVIFE_CZSSI_EESIMSZZEMZMIICCF"), Is.EqualTo("NO"), "35");
            Assert.That(happyLadybugs("AGUPF__PGFP_AFKGFUFUAP_"), Is.EqualTo("NO"), "36");
            Assert.That(happyLadybugs("IIIAA"), Is.EqualTo("YES"), "37");
            Assert.That(happyLadybugs("QZQZQ"), Is.EqualTo("NO"), "38");
            Assert.That(happyLadybugs("RYRYRRY"), Is.EqualTo("NO"), "39");
        }

        private string happyLadybugs(string b)
        {
            if (b.Length == 1 && b[0] != '_')
                return "NO";

            bool underscorePresent = isUnderscorePresent(b);
            List<char> foundLetters = new List<char>();

            for (int i = 0; i < b.Length - 1; i++)
            {
                if (b[i] == '_')
                    continue;

                if (b[i] == b[i + 1])
                {
                    i++;
                    addLetterToListIfNew(foundLetters, b[i]);

                    continue;
                }
                else
                {

                    if (i != 0 && b[i] == b[i - 1] || foundLetters.Contains(b[i]) && underscorePresent)
                        continue;

                    if (!underscorePresent)
                        return "NO";


                    if (foundSameLetterWithinString(b, i))
                        addLetterToListIfNew(foundLetters, b[i]);
                    else
                        return "NO";
                }

            }

            if (lastCharIsLetter(b) && lastCharIsNotInTheList(foundLetters, b))
                return "NO";

            return "YES";
        }

        private static bool isUnderscorePresent(string b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == '_')
                    return true;
            }

            return false;
        }

        private static void addLetterToListIfNew(List<char> foundLetters, char item)
        {
            if (!foundLetters.Contains(item))
                foundLetters.Add(item);
        }

        private static bool foundSameLetterWithinString(string b, int currentIndex)
        {
            for (int j = currentIndex + 2; j < b.Length; j++)
                if (b[j] == b[currentIndex])
                    return true;

            return false;
        }

        private static bool lastCharIsLetter(string b)
        {
            return b[b.Length - 1] != '_';
        }

        private static bool lastCharIsNotInTheList(List<char> foundLetters, string b)
        {
            return !foundLetters.Contains(b[b.Length - 1]);
        }








    }
}
