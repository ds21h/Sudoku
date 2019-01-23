using System;

namespace Sudoku
{
    class Sudoku
    {
        public const int AantalCellen = 81;

        public const int ResultGoed = 0;
        public const int ResultGoedVol = 99;
        public const int ResultCelNrFout = 1;
        public const int ResultCelWaardeFout = 2;
        public const int ResultConflict = 3;
        public const int ResultGegeven = 4;

        private Random mRandom = new Random();
        private Cel[] mCellen = new Cel[AantalCellen];
        private int[] mFoutCel = new int[AantalCellen];
        private int mAantalFout;

        public Sudoku()
        {
            xNieuw();
        }

        public void xNieuw()
        {
            int lTeller;

            for (lTeller = 0; lTeller < AantalCellen; lTeller++)
            {
                mCellen[lTeller] = new Cel(lTeller);
            }
            mAantalFout = 0;
        }

        public int xCelWaarde(int pCelNummer)
        {
            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                return -1;
            } else
            {
                return mCellen[pCelNummer].xWaarde();
            }
        }

        public bool xGegeven(int pCelNummer)
        {
            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                return false;
            }
            else
            {
                return mCellen[pCelNummer].xGegeven();
            }
        }

        public int[] xCelWaarden(int pCelNummer)
        {
            int[] lCelWaarden;

            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                lCelWaarden = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            }
            else
            {
                lCelWaarden = mCellen[pCelNummer].xCelWaarden();
            }
            return lCelWaarden;
        }

        public int[] xRij(int pCelNummer)
        {
            int[] lRij;

            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                lRij = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            else
            {
                lRij = mCellen[pCelNummer].xRij();
            }
            return lRij;
        }

        public int[] xKolom(int pCelNummer)
        {
            int[] lKolom;

            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                lKolom = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            else
            {
                lKolom = mCellen[pCelNummer].xKolom();
            }
            return lKolom;
        }

        public int[] xSegment(int pCelNummer)
        {
            int[] lSegment;

            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                lSegment = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            else
            {
                lSegment = mCellen[pCelNummer].xSegment();
            }
            return lSegment;
        }

        public int[] xTelCijfers()
        {
            int[] lTelling = new int[10];
            int lTeller;

            for (lTeller = 0; lTeller < mCellen.Length; lTeller++)
            {
                lTelling[mCellen[lTeller].xWaarde()]++;
            }
            return lTelling;
        }

        public void xFlipCelWaarde(int pCelNummer, int pWaarde)
        {
            if (pCelNummer >= 0 && pCelNummer < AantalCellen)
            {
                mCellen[pCelNummer].xFlipCelWaarde(pWaarde);
            }
        }

        public void xZetCelWaarden()
        {
            int lTeller;
            Cel lCel;

            for (lTeller = 0; lTeller < AantalCellen; lTeller++)
            {
                lCel = mCellen[lTeller];
                lCel.xInitCelWaarden();
                sBlokWaarden(lCel.xRij(), lCel);
                sBlokWaarden(lCel.xKolom(), lCel);
                sBlokWaarden(lCel.xSegment(), lCel);
            }
        }

        private void sBlokWaarden (int[] pCellen, Cel pCel)
        {
            Cel lCel;
            int lTeller;

            for (lTeller = 0; lTeller < pCellen.Length; lTeller++)
            {
                lCel = mCellen[pCellen[lTeller]];
                if (lCel.xPositie() != pCel.xPositie())
                {
                    pCel.sWisCelWaarde(lCel.xWaarde());
                }
            }
        }

        public void xWisCelWaarden()
        {
            int lTeller;

            for (lTeller = 0; lTeller < AantalCellen; lTeller++)
            {
                mCellen[lTeller].xWisCelWaarden();
            }
        }

        public int[] xFouteCellen()
        {
            int[] lFouteCellen;
            int lTeller;

            lFouteCellen = new int[mAantalFout];
            for (lTeller = 0; lTeller < mAantalFout; lTeller++)
            {
                lFouteCellen[lTeller] = mFoutCel[lTeller];
            }
            return lFouteCellen;
        }

        public int xZetCel(int pCelNummer, int pCelWaarde, bool pGegeven)
        {
            int lResult;

            if (pCelNummer < 0 || pCelNummer >= AantalCellen)
            {
                lResult = ResultCelNrFout;
            } else
            {
                if (pCelWaarde < 0 || pCelWaarde > 9)
                {
                    lResult = ResultCelWaardeFout;
                } else
                {
                    if (pGegeven)
                    {
                        lResult = sVulCel(pCelNummer, pCelWaarde, pGegeven);
                    } else
                    {
                        if (mCellen[pCelNummer].xGegeven())
                        {
                            lResult = ResultGegeven;
                        } else
                        {
                            lResult = sVulCel(pCelNummer, pCelWaarde, pGegeven);
                            if (lResult == ResultGoed)
                            {
                                if (sSpelVol())
                                {
                                    lResult = ResultGoedVol;
                                }
                            }
                        }
                    }
                }
            }

            return lResult;
        }

        private bool sSpelVol()
        {
            int lTeller;
            bool lVol;

            lVol = true;
            for (lTeller = 0; lTeller < mCellen.Length; lTeller++)
            {
                if (mCellen[lTeller].xWaarde() == 0)
                {
                    lVol = false;
                    break;
                }
            }
            return lVol;
        }

        private int sVulCel(int pCelNummer, int pCelWaarde, bool pGegeven)
        {
            int lResult;

            lResult = sTestCel(pCelNummer, pCelWaarde);
            if (lResult == ResultGoed)
            {
                mCellen[pCelNummer].xZetCel(pCelWaarde, pGegeven);
            }
            return lResult;
        }

        public bool xLosOp()
        {
            int lCelNummer;
            int lWaarde;
            int lResult;
            bool lOpgelost;

            lCelNummer = 0;
            lOpgelost = true;
            while (lCelNummer < 81)
            {
                if (mCellen[lCelNummer].xFixed())
                {
                    lCelNummer++;
                }
                else
                {
                    lWaarde = mCellen[lCelNummer].xRndWaarde(mRandom);
                    if (lWaarde == 0)
                    {
                        mCellen[lCelNummer].xCelVrij();
                        do
                        {
                            lCelNummer--;
                            if (lCelNummer < 0)
                            {
                                lOpgelost = false;
                                break;
                            }
                        } while (mCellen[lCelNummer].xFixed());
                        if (lCelNummer < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        lResult = sTestCel(lCelNummer, lWaarde);
                        if (lResult == ResultGoed)
                        {
                            mCellen[lCelNummer].xWaarde(lWaarde);
                            lCelNummer++;
                        }
                    }
                }
            }
            return lOpgelost;
        }

        private int sTestCel(int pCelNummer, int pCelWaarde)
        {
            int lResult;
            int lRes2;
            Cel lCel;

            mAantalFout = 0;

            if (pCelWaarde == 0)
            {
                lResult = ResultGoed;
            } else
            {
                lCel = mCellen[pCelNummer];
                lResult = sTestBlok(lCel.xRij(), lCel, pCelWaarde);
                lRes2 = sTestBlok(lCel.xKolom(), lCel, pCelWaarde);
                if (lRes2 != ResultGoed)
                {
                    lResult = lRes2;
                }
                lRes2 = sTestBlok(lCel.xSegment(), lCel, pCelWaarde);
                if (lRes2 != ResultGoed)
                {
                    lResult = lRes2;
                }
            }
            return lResult;
        }

        private int sTestBlok(int[] pCellen, Cel pCel, int pCelWaarde)
        {
            int lResult;
            int lTeller;
            Cel lCel;

            lResult = ResultGoed;
            for (lTeller = 0; lTeller < pCellen.Length; lTeller++)
            {
                lCel = mCellen[pCellen[lTeller]];
                if (lCel.xPositie() != pCel.xPositie())
                {
                    if (lCel.xWaarde() > 0)
                    {
                        if (lCel.xWaarde() == pCelWaarde)
                        {
                            lResult = ResultConflict;
                            mFoutCel[mAantalFout] = lCel.xPositie();
                            mAantalFout++;
                        }
                    }
                }
            }
            return lResult;
        }

        private int sAantalOplossingen(int pStart, int pTelling, int pMax)
        {
            int lWaarde;
            int lTelling;
            int lResult;

            if (pStart >= AantalCellen)
            { 
                return pTelling + 1;
            }
            if (mCellen[pStart].xWaarde() != 0)
            {
                return sAantalOplossingen(pStart + 1, pTelling, pMax);
            }
            lTelling = pTelling;
            for (lWaarde = 1; lWaarde <= 9 && lTelling < pMax; lWaarde++)
            {
                lResult = sTestCel(pStart, lWaarde);
                if (lResult == ResultGoed)
                {
                    mCellen[pStart].xWaarde(lWaarde);
                    lTelling = sAantalOplossingen(pStart + 1, lTelling, pMax);
                }
            }
            mCellen[pStart].xWaarde(0);
            return lTelling;
        }

        public void xGenereer(int pAantalGegeven)
        {
            int lTeller;
            int lRndCel;
            int lCelNummer;
            int lAantal;
            int lAantalGegeven;
            int[] lWerkCellen;
            int lAantalWerk;

            do
            {
                xNieuw();
                xLosOp();
                lWerkCellen = sInitGen();
                lAantalWerk = lWerkCellen.Length;
                lAantalGegeven = AantalCellen;
                for (lTeller = 0; lTeller < 40; lTeller++)
                {
                    lRndCel = mRandom.Next(lAantalWerk);
                    lCelNummer = lWerkCellen[lRndCel];
                    mCellen[lCelNummer].xCelVrij();
                    sGenVrij(ref lWerkCellen, ref lAantalWerk, lRndCel);
                    lAantalGegeven--;
                }
                lAantal = sAantalOplossingen(0, 0, 2);
            } while (lAantal != 1);

            do
            {
                if (xStap(ref lWerkCellen, ref lAantalWerk))
                {
                    lAantalGegeven--;
                }
                if (lAantalGegeven <= pAantalGegeven)
                {
                    break;
                }
            } while (lAantalWerk > 10);

            for (lTeller = 0; lTeller < AantalCellen; lTeller++)
            {
                if (mCellen[lTeller].xWaarde() > 0)
                {
                    mCellen[lTeller].xGegeven(true);
                    mCellen[lTeller].xFixed(true);
                }
            }
        }

        private int[] sInitGen()
        {
            int[] lWerkCellen;
            int lTeller;

            lWerkCellen = new int[AantalCellen];
            for (lTeller = 0; lTeller < lWerkCellen.Length; lTeller++)
            {
                lWerkCellen[lTeller] = lTeller;
            }
            return lWerkCellen;
        }

        public bool xStap(ref int[] pWerkCellen, ref int pAantalWerk)
        {
            Cel lCel;
            int lRndCel;
            int lCelNummer;
            int lAantOplossing;

            if (pAantalWerk > 0)
            {
                lRndCel = mRandom.Next(pAantalWerk);
                lCelNummer = pWerkCellen[lRndCel];
                lCel = mCellen[lCelNummer].xKopie();
                mCellen[lCelNummer].xWaarde(0);
                lAantOplossing = sAantalOplossingen(0, 0, 2);
                if (lAantOplossing == 1)
                {
                    mCellen[lCelNummer].xCelVrij();
                } else
                {
                    mCellen[lCelNummer] = lCel.xKopie();
                }
                sGenVrij(ref pWerkCellen, ref pAantalWerk, lRndCel);
            } else
            {
                lAantOplossing = 0;
            }
            return lAantOplossing == 1;
        }

        private void sGenVrij(ref int[] pWerkCellen, ref int pAantalWerk, int pCelNummer)
        {
            int lTeller;

            for (lTeller = pCelNummer; lTeller < pAantalWerk - 1; lTeller++)
            {
                pWerkCellen[lTeller] = pWerkCellen[lTeller + 1];
            }
            pAantalWerk--;
        }

        class Cel
        {
            private int mPositie;
            private int mWaarde;
            private bool mFixed;
            private bool mGegeven;
            private int[] mBeschikbaar = new int[10];

            private int[] mRij = new int[9];
            private int[] mKolom = new int[9];
            private int[] mSegment = new int[9];

            private int[] mCelWaarden = new int[10];

            public Cel(int pPositie)
            {
                int lRij;
                int lKolom;
                int lTeller;
                int lTel2;
                int lStart;

                mPositie = pPositie;
                xCelVrij();
                xWisCelWaarden();

                lRij = mPositie / 9;
                lKolom = mPositie % 9;

                lStart = lRij * 9;
                for (lTeller = 0; lTeller < mRij.Length; lTeller++)
                {
                    mRij[lTeller] = lStart + lTeller;
                }

                lStart = lKolom;
                for (lTeller = 0; lTeller < mKolom.Length; lTeller++)
                {
                    mKolom[lTeller] = lStart + (lTeller * 9);
                }

                lStart = (lKolom / 3) * 3;
                lStart = lStart + ((lRij / 3) * 27);
                lTel2 = 0;
                for (lTeller = 0; lTeller < mSegment.Length; lTeller++)
                {
                    mSegment[lTeller] = lStart + lTel2;
                    lTel2++;
                    if (lTel2 >= 3)
                    {
                        lStart += 9;
                        lTel2 = 0;
                    }
                }
            }

            public Cel xKopie()
            {
                return (Cel)this.MemberwiseClone();
            }

            public int xPositie()
            {
                return mPositie;
            }

            public int xWaarde()
            {
                return mWaarde;
            }

            public void xWaarde(int pWaarde)
            {
                mWaarde = pWaarde;
            }

            public bool xGegeven()
            {
                return mGegeven;
            }

            public void xGegeven(bool pGegeven)
            {
                mGegeven = pGegeven;
            }

            public bool xFixed()
            {
                return mFixed;
            }

            public void xFixed(bool pFixed)
            {
                mFixed = pFixed;
            }

            public int[] xCelWaarden()
            {
                return mCelWaarden;
            }

            public int[] xRij()
            {
                return mRij;
            }

            public int[] xKolom()
            {
                return mKolom;
            }

            public int[] xSegment()
            {
                return mSegment;
            }

            private void sInitCel()
            {
                int lTelCijfer;

                mBeschikbaar[0] = 9;
                for (lTelCijfer = 1; lTelCijfer < 10; lTelCijfer++)
                {
                    mBeschikbaar[lTelCijfer] = lTelCijfer;
                }

            }

            public int xRndWaarde(Random pRandom)
            {
                int lTeller;
                int lAantWaarden;
                int lRndWaarde;
                int lHitTeller;
                int lResultaat = 0;

                lAantWaarden = mBeschikbaar[0];
                if (lAantWaarden == 0)
                {
                    lResultaat = 0;
                }
                else
                {
                    lRndWaarde = pRandom.Next(lAantWaarden) + 1;
                    lHitTeller = 0;
                    for (lTeller = 1; lTeller < 10; lTeller++)
                    {
                        if (mBeschikbaar[lTeller] != 0)
                        {
                            lHitTeller++;
                            if (lHitTeller == lRndWaarde)
                            {
                                lResultaat = lTeller;
                                mBeschikbaar[lTeller] = 0;
                                mBeschikbaar[0]--;
                                break;
                            }
                        }
                    }
                }
                return lResultaat;
            }

            public void xZetCel(int pCelWaarde, bool pGegeven)
            {
                mWaarde = pCelWaarde;
                xWisCelWaarden();
                if (mWaarde == 0)
                {
                    mFixed = false;
                    mGegeven = false;
                    sInitCel();
                } else
                {
                    mFixed = true;
                    mGegeven = pGegeven;
                }
            }

            public void xCelVrij()
            {
                mWaarde = 0;
                mFixed = false;
                mGegeven = false;
                sInitCel();
            }

            public void xInitCelWaarden()
            {
                int lTeller;

                mCelWaarden[0] = 9;
                for (lTeller = 1; lTeller < mCelWaarden.Length; lTeller++)
                {
                    mCelWaarden[lTeller] = lTeller;
                }
            }

            public void xWisCelWaarden()
            {
                int lTeller;

                for (lTeller = 0; lTeller < mCelWaarden.Length; lTeller++)
                {
                    mCelWaarden[lTeller] = 0;
                }
            }

            public void sWisCelWaarde(int pWaarde)
            {
                if (pWaarde >= 1 && pWaarde <= 9)
                {
                    if (mCelWaarden[pWaarde] > 0)
                    {
                        mCelWaarden[pWaarde] = 0;
                        mCelWaarden[0]--;
                    }
                }
            }

            public void xFlipCelWaarde(int pWaarde)
            {
                if (!mFixed)
                {
                    if (pWaarde >= 1 && pWaarde <= 9)
                    {
                        if (mCelWaarden[pWaarde] == 0)
                        {
                            mCelWaarden[0]++;
                            mCelWaarden[pWaarde] = pWaarde;
                        } else
                        {
                            mCelWaarden[0]--;
                            mCelWaarden[pWaarde] = 0;
                        }
                    }
                }
            }
        }
    }
}
